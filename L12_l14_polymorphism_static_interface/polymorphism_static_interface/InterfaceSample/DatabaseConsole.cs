namespace InterfaceSample;

public class DatabaseConsole : IReader
{
    public string Name => "DatabaseConsole";
    public int ReadInt()
    {
        return 1000;
    }

    public string ReadString()
    {
        return "ASDJALJAKS DJKASJDK";
    }
}