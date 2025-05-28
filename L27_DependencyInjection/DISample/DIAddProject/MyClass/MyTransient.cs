using DIAddProject.IMyInterface;

namespace DIAddProject.MyClass;

public class MyTransient : IMyAddTransient
{
    public static int Id = 0;
    public MyTransient()
    {
        Console.WriteLine($"Transient: {++Id}!");
    }
}