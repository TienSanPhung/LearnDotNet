using System.Collections.Immutable;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HR;

class Program
{
    static void Main(string[] args)
    {
        var buider = new ConfigurationBuilder();
        buider.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
       IConfiguration configuration = buider.Build();
        
        string connectionString = configuration.GetConnectionString("HR");
        using var sql = new SqlConnection(connectionString);
        sql.Open();
        
        ListCountries(sql);
        sql.Close();
    }

    public static void ListCountries(SqlConnection sql)
    {
        
        var cmd = new SqlCommand("SELECT * FROM countries", sql);
        var reader = cmd.ExecuteReader();
        int c = 0;
        while (reader.Read())
        {
            Console.WriteLine($"Id: {reader["country_id"]}, Name: {reader["country_name"]}");
            c ++;
        }
        Console.WriteLine($"total: {c} rows");
        reader.Close();
    }
}