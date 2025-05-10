using Microsoft.Extensions.Configuration;

namespace RepoSample;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("ConnectionStrings.json",optional:true).Build();
        string connectionString = config.GetConnectionString("Shop");
        
    }
}