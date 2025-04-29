using System.Runtime.InteropServices;

namespace NFind;

public class FileLineSource : ILineSource
{
    private readonly string path;
    private readonly string fileName;
    private StreamReader? reader;
    private int lineNumber;

    public FileLineSource(string path, string fileName )
    {
        this.path = path;
        this.fileName = fileName;
        
    }

    public string Name => fileName;

    public Line? ReadLine()
    {
        if (reader == null)
        {
            throw new InvalidOleVariantTypeException();
        }
        var s = reader.ReadLine();
        if (s == null)
        {
            return null;       
        }
        else
        {
            return new Line() { LineNumber = ++lineNumber, Text = s };
        }
    }

    public void Open()
    {
        if (reader != null)
        {
            throw new InvalidOleVariantTypeException();
        }
        lineNumber = 0;
        reader = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
    }

    public void Close()
    {
        if(reader!=null)
        {
            reader.Close();
            reader = null;
           
        }
        
    }
}