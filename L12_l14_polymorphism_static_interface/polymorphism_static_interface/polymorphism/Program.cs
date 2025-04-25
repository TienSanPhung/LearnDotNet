namespace polymorphism;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var animal = Random(random.Next(0,3));
        animal.Move();
        
        Animal animal2 = new Dog();
        animal2.A();
        Dog animal3 = new Dog();
        animal3.A();
        Animal sonofthefish = new SonOfTheFish();
        sonofthefish.Move();
    }
    static Animal  Random(int id)
    {
        switch (id)
        {
            case 0: return new Dog();
            case 1: return new Fish();
            case 2: return new Bird();
            default: return new Animal();
                
        }

    }
}