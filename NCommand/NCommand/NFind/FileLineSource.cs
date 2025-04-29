using System.Runtime.InteropServices;

namespace NFind;

public class FileLineSource : ILineSource
{
    private readonly string _path;
    private StreamReader? _reader;
    private int _lineNumber;

    public FileLineSource(string path)
    {
        this._path = path;
    }

    public Line? ReadLine()
    {
        if (_reader == null)
        {
            throw new InvalidOleVariantTypeException();
        }
        var s = _reader.ReadLine();
        if (s == null)
        {
            return null;       
        }
        else
        {
            return new Line() { LineNumber = ++_lineNumber, Text = s };
        }
    }

    public void Open()
    {
        if (_reader != null)
        {
            throw new InvalidOleVariantTypeException();
        }
        _lineNumber = 0;
        _reader = new StreamReader(new FileStream(_path, FileMode.Open, FileAccess.Read));
    }

    public void Close()
    {
        if(_reader!=null)
        {
            _reader.Close();
            _reader = null;
           
        }
        
    }
}