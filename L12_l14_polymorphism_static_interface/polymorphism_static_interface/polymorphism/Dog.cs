namespace polymorphism;

public class Dog : Animal
{
    public override void Move()
    {
        Console.WriteLine("Run");
    }

    public new void A()
    {
        Console.WriteLine("Dog.A");
    }
}