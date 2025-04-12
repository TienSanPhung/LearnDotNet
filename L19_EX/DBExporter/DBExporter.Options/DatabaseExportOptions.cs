namespace DBExporter.Options;

public class DatabaseExportOptions
{
    public DatabaseOptions DatabaseOptions { get; set; } = new();
    public ExportOptions ExportOptions { get; set; } = new();
}