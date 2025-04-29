namespace NFind;

public class ConsoleLineSource : ILineSource
{
    private int number = 0;
    public ConsoleLineSource()
    {
    }

    public string Name => string.Empty;

    public Line? ReadLine()
    {
        var s = Console.ReadLine();
        if (s == null)
        {
            return null;       
        }
        else
        {
            return new Line() { LineNumber = number++, Text = s };
        }
        
    }

    public void Open()
    {
    }

    public void Close()
    {
    }
}