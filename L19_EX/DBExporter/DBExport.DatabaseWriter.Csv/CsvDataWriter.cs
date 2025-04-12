using System.Data.Common;
using System.Globalization;
using CsvHelper;
using DBExport.DatabaseObjects;
using DBExport.DatabaseWriter.Abstraction;


namespace DBExport.DatabaseWriter;

public class CsvDataWriter : IDataWriter
{
    public CsvDataWriter()
    {
    }

    public void WriteData(ExportSource database, Stream stream)
    {
        using var writer = new StreamWriter(stream, leaveOpen: true);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        
        var columns = database.Reader.GetColumnSchema();
        while (database.Reader.Read())
        {
            for (int i = 0; i < columns.Count; i++)
            {
                csv.WriteField(database.Reader[i].ToString(), true);
            }

            csv.NextRecord();
        }

        csv.Flush();
    }
}