namespace NFind;

public class FilterLineSource : ILineSource
{
    private readonly ILineSource parent;
    private readonly Func<Line, bool> f;

    public FilterLineSource(ILineSource parent, Func<Line, bool> f = null)
    {
        this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        this.f = f;
    }

    public string Name => parent.Name;

    public Line? ReadLine()
    {
        if (f == null) parent.ReadLine();
        var line = parent.ReadLine();
        if (line == null)
        {
            return null;
        }
        else
        {
            while (line != null && f(line) == false)
            {
                line = parent.ReadLine();
            }

            return line;
        }
    }

    public void Open()
    {
        parent.Open();
    }

    public void Close()
    {
        parent.Close();
    }
}