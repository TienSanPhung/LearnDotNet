namespace DelegateSample.EX3;

public class PluginDispatcher
{
    private readonly List<PluginHandler> _plugins = new();
    public void Register(PluginHandler plugin) => _plugins.Add(plugin);
    public void Dispatch(string data) => _plugins.ForEach(p => p(data));
}