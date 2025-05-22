
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var builder = new ConfigurationBuilder().
            AddJsonFile("ConfigFile/appsettings.json",optional: false).
            AddJsonFile("ConfigFile/appsettings.options.json",optional: true).
            AddXmlFile("ConfigFile/appsettings.xml",optional: false).
            AddKeyPerFile(@"C:\Users\pts20\Desktop\.net\LearnDotNet\L26_Configuration\CConfiguration\ConfigurationSample\ConfigFile\KeyPerFile",optional: true).
            //AddEnvironmentVariables().
            AddCommandLine(args).
            Build();
        
        
        PrintConfigProviders(builder);
        Console.WriteLine();
        
        PrintConfigValue(builder);
        Console.WriteLine();
        
        var config = builder.GetRequiredSection("JsonConfigSample").Get<BindingConfig>();
        Print(config);
        
        
        
    }

    static void PrintConfigProviders(IConfigurationRoot builder)
    {
        foreach (var provider in builder.Providers)
        {
            Console.WriteLine($"providers: {provider.GetType().Name}");
        }
    }

    static void PrintConfigValue(IConfigurationRoot builder)
    {
        foreach (var config in builder.AsEnumerable())
        {
            Console.WriteLine($"{config.Key} = {config.Value}");
        }
    }

    static void Print(BindingConfig? config)
    {
        if (config != null)
        {
            Console.WriteLine($"-> StringConfig: {config.StringConfig}");
            Console.WriteLine($"-> IntergerConfig: {config.IntergerConfig}");
            Console.WriteLine($"-> BoolConfig: {config.BoolConfig}");
        }
    }
}