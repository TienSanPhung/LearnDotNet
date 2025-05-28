using DIAddProject.IMyInterface;

namespace DIAddProject.MyClass;

public class MySingleton : IMyAddSingleton
{
    public static int Id = 0;
    public MySingleton()
    {
        Console.WriteLine($"MySingleton: {++Id}!");
    }
}