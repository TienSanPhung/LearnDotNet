namespace InterfaceSample;

public interface IReader
{
    string Name{get;}
    int ReadInt();
    string ReadString();

    public static void WriteName(IReader reader)
    {
        Console.WriteLine(reader.Name);
    }
}