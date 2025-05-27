namespace MyDIProject;

public class ServiceClass : IServiceCLass
{
    public ServiceClass()
    {
        Console.WriteLine("NEW ServiceClass");
    }

    public void DoSomeThing(string message)
    {
       Console.WriteLine(message + "  ServiceClass");
    }
}