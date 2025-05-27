namespace MyDIProject;

public class NullClass : INullClass
{
    public void DoSomeThing(string message)
    {
        Console.WriteLine(message + "  NullClass");
    }
}