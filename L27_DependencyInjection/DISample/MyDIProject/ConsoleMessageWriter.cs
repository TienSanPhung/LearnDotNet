namespace MyDIProject;

public class ConsoleMessageWriter : IMessageWriter
{
    readonly INullClass _nullClass;

    public ConsoleMessageWriter(INullClass nullClass)
    {
        this._nullClass = nullClass;
    }
    public void WriteMessage(string message)
    {
        _nullClass.DoSomeThing(" này truyền từ ConsoleMessageWriter đến");
        Console.WriteLine(message + " from ConsoleMessageWriter");
    }
}
