using DIAddProject.IMyInterface;

namespace DIAddProject.MyClass;

public class MyScoped : IMyAddScoped
{
    public static int Id = 0;
    public MyScoped()
    {
        Console.WriteLine($"Scoped: {++Id}!");
    }
}