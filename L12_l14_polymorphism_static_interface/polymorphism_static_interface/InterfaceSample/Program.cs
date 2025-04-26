using System.Text;

namespace InterfaceSample;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        IReader reader1 = new DatabaseConsole();
        Run(reader1);
            
    }

    static void Run(IReader reader)
    {
        reader.WriteName();
        IReader.WriteName(reader);
        Console.WriteLine(reader.Name);
        int i = reader.ReadInt();
        string s = reader.ReadString();
        Console.WriteLine($"int: {i}, string: {s}");
    }
}