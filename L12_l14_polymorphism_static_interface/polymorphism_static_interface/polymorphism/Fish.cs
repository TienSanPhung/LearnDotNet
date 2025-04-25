namespace polymorphism;

public class Fish : Animal
{
    public sealed override void Move()
    {
        Console.WriteLine("Swim");
    }
}