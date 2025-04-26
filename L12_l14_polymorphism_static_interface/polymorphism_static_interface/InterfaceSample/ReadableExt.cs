namespace InterfaceSample;

public static class ReadableExt
{
    public static void WriteName(this IReader reader)
    {
        Console.WriteLine(reader.Name);
    }
}