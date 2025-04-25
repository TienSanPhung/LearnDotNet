namespace StaticSample;

public static class PersonExt
{
    public static void Print(this Person person)
    {
        Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
    }
}