namespace PDFParserConsole;

public abstract class DocumentParser
{
    protected string FilePath;

    /// <summary>Template Method định nghĩa trình tự parse tài liệu.</summary>
    public void Parse(string path)
    {
        FilePath = path;
        Open(path);
        ReadHeader();
        ReadXrefAndTrailer();
        ParseBody();
        string text = ExtractText();
        OnParseCompleted(text);
    }

    protected abstract void Open(string path);
    protected abstract void ReadHeader();
    protected abstract void ReadXrefAndTrailer();
    protected abstract void ParseBody();
    protected abstract string ExtractText();

    protected virtual void OnParseCompleted(string text)
    {
        Console.WriteLine("\n--- Extracted Text ---\n");
        Console.WriteLine(text);
    }
}