using System.Text;
using Microsoft.Extensions.Logging;

namespace LoggingDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Trace);
            builder.AddFilter((level)=>level == LogLevel.Debug || level == LogLevel.Warning, LogLevel.Information);
        });
        
        ILogger logger = loggerFactory.CreateLogger("Program");
        
        
        string n = "con bò";
        logger.LogTrace("test LogTrace từ console");
        logger.LogDebug("test LogDebug  từ console");
        logger.LogInformation("test logging info  từ console {n:X}", n);
        logger.LogWarning("test logging info  từ console {n:X}", n);
        
        
    }
}