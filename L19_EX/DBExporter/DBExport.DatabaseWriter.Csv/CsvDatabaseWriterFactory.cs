using DBExport.DatabaseWriter.Abstraction;

namespace DBExport.DatabaseWriter;

public class CsvDatabaseWriterFactory: IDataWriterFactory
{
    public CsvDatabaseWriterFactory()
    {
    }

    public IDataWriter GetDataWriter()
    {
        return new CsvDataWriter();
    }
}