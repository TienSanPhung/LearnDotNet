namespace NFind;

public class FileLineSource : ILineSource
{
    private readonly string path;

    public FileLineSource(string path)
    {
        this.path = path;
    }
}