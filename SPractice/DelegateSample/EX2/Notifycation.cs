namespace DelegateSample;

public class Notifycation
{
    public event Action<string> OnNotify;
    public void Notify(string msg) => OnNotify?.Invoke(msg);
}