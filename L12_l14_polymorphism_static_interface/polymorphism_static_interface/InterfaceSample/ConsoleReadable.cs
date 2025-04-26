namespace InterfaceSample;

public class ConsoleReadable: IReader
{
    public string Name => "ConsoleReadable";

    public int ReadInt()
    {
        Console.WriteLine("nhập int: ");
        return int.Parse(Console.ReadLine());
    }

    public string ReadString()
    {
        Console.WriteLine("nhập string: ");
        return Console.ReadLine();
    }
}