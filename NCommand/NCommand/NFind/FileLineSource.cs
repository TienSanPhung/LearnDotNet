namespace NFind;

public class FileLineSource : ILineSource
{
    private readonly string path;

    public FileLineSource(string path)
    {
        this.path = path;
    }

    public Line? ReadLine()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }
}