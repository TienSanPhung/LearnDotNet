namespace DBExport.DatabaseWriter.Abstraction;

public interface IDataWriterFactory
{
    IDataWriter GetDataWriter();
}