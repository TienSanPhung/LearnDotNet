namespace DBExport.DatabaseObjects;

public interface IExportSourceBuilder
{
    ExportSource Build(string selectQuery);
}