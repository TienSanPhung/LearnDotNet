namespace StaticSample;

public class AccessCounter
{
    private int counter = 0;
    private static AccessCounter instance = new AccessCounter();
    public int Counter { get; }

    public int Inc()
    {
        counter++;
        return counter;
    }
    public static AccessCounter GetInstance()
    {
        return instance;
    }
}