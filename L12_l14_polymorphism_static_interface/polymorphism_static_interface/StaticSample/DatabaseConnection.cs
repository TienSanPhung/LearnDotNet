namespace StaticSample;

public class DatabaseConnection
{
    private static DatabaseConnection? _instance = null;
    private static object _lock = new();

    public static DatabaseConnection GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
                _instance.Connect();
            }
        }
        return _instance;
    }

    private void Connect()
    {
        throw new NotImplementedException();
    }
}