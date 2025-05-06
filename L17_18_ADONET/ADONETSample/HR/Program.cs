
using System.Data;
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
        var transaction = sql.BeginTransaction();
        //ListCountries(sql);
        CreateEmployees(
            "Nguyen", 
            "A", 
            "JohnDoe@gmail.com", 
            "123456789", 
            DateTime.Today, 
            9, 
            10000, 
            100, 
            6, sql, transaction);
        transaction.Commit();
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

    public static int CreateEmployees(
        string firstName,string lastName, string email, string phoneNumber, DateTime hireDate,
        int jobId, double salary, int managerId, int departmentId,
        SqlConnection sql, SqlTransaction transaction
        )
    {
        var cmd = new SqlCommand(@"INSERT INTO employees (
                       first_name, 
                       last_name, 
                       email, 
                       phone_number, 
                       hire_date, 
                       job_id, 
                       salary, 
                       manager_id, 
                       department_id) 
                        VALUES (
                                @first_name, 
                                @last_name, 
                                @email, 
                                @phone_number, 
                                @hire_date, 
                                @job_id, 
                                @salary, 
                                @manager_id, 
                                @department_id)", 
                        sql, transaction);
        cmd.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar,20)).Value = firstName;
        cmd.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar,25)).Value = lastName;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar,100)).Value = email;
        cmd.Parameters.Add(new SqlParameter("@phone_number", SqlDbType.VarChar,20)).Value = phoneNumber;
        cmd.Parameters.Add(new SqlParameter("@hire_date", SqlDbType.Date,20)).Value = hireDate;
        cmd.Parameters.Add(new SqlParameter("@job_id", SqlDbType.Int)).Value = jobId;
        cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.Decimal)).Value = salary;
        cmd.Parameters.Add(new SqlParameter("@manager_id", SqlDbType.Int)).Value = managerId;
        cmd.Parameters.Add(new SqlParameter("@department_id", SqlDbType.Int)).Value = departmentId;
        var result = cmd.ExecuteNonQuery();
        return result;
    }
}