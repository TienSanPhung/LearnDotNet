using DBExport.DatabaseObjects;

namespace DBExport.DatabaseWriter.Abstraction;

public interface IDataWriter
{
    void WriteData(ExportSource database, Stream stream);
}