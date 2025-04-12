using System.IO.Compression;
using DBExport.DatabaseBuilders;
using DBExport.DatabaseObjects;
using DBExport.DatabaseWriter;
using DBExporter.Options;

namespace DBExporter;

class Program
{
    static void Main(string[] args)
    {
        DatabaseExportOptions? options = null;
        try
        {
            var optionBuilder = new DatabaseExportOptionsBuilder(args, [SourceOptionsValidator.Instance,]);
            options = optionBuilder.Build();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
        }

        if (options == null)
        {
            return;
        }
        var databaseBuilder = DatabaseBuilderFactory.connect(options.DatabaseOptions.ServerType, options.DatabaseOptions.ConnectionString);
        if (databaseBuilder == null)
        {
            Console.WriteLine("Could not find database builder");
            return;
        }

        try
        {
            using var database = databaseBuilder.Build(options.DatabaseOptions.SelectQuery);
            if (options.ExportOptions.ZipCompressed)
            {
                ExportToZipFile(database, options.ExportOptions);
            }
            else
            {
                using var stream = new FileStream(options.ExportOptions.FileName,FileMode.Create,FileAccess.Write,FileShare.None);
                Export(database, stream, options.ExportOptions);
                stream.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
           
        }
    }

    private static void Export(ExportSource database, Stream stream, ExportOptions optionsExportOptions)
    {
        var writer = optionsExportOptions.ExportFormats switch
        {
            ExportFormats.Csv => new CsvDatabaseWriterFactory(),
            _=> throw new NotImplementedException($"Export format {optionsExportOptions.ExportFormats} not suported"),
        };
    }

    private static void ExportToZipFile(ExportSource database, ExportOptions optionsExportOptions)
    {
        using FileStream zipFile = new(optionsExportOptions.FileName, FileMode.Create);
        using (ZipArchive archive = new(zipFile, ZipArchiveMode.Update))
        {
            var entryName = Path.GetFileName(optionsExportOptions.FileName);
            if(Path.GetExtension(entryName).EndsWith(".zip",StringComparison.OrdinalIgnoreCase))
            {
                entryName = Path.GetFileNameWithoutExtension(entryName);
            }
            ZipArchiveEntry zipEntry = archive.CreateEntry(entryName);
            var stream = zipEntry.Open();
                Export(database, stream, optionsExportOptions);
                stream.Flush();
        }
        zipFile.Close();
    }
}