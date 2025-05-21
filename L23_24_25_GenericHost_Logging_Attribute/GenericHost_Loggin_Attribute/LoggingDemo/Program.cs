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
        });
        ILogger logger = loggerFactory.CreateLogger("Program");
        logger.LogInformation("test logging info  từ console");
    }
}