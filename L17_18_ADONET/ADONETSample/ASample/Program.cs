using Microsoft.Data.SqlClient;

namespace ASample;

class Program
{
    static void Main(string[] args)
    {
        DbConnection();
    }

    public static void DbConnection()
    {
        using  var connect = new SqlConnection("Server=localhost,1433;Database=HR;User Id=SA;Password=Daicabavi1;TrustServerCertificate=true;");
        connect.Open();
         var cmd = connect.CreateCommand();
         cmd.CommandText = "Select country_id, country_name from countries";
        using  var reader = cmd.ExecuteReader();
        int c = 0;
         while (reader.Read())
         {
             Console.WriteLine($"ID: {reader["country_id"]}, Name: {reader["country_name"]}");
             c ++;
         }
        Console.WriteLine($"total: {c} rows");
        reader.Close();
        using var Total = new SqlCommand("SELECT COUNT(*) FROM countries",connect);
        int c1 = (int)Total.ExecuteScalar();
        Console.WriteLine($"total with sqlcommand: {c1} rows");
    }
}