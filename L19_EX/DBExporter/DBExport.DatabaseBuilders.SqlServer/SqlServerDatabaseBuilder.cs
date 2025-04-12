using System.Data.SqlClient;
using DBExport.DatabaseObjects;

namespace DBExport.DatabaseBuilders.SqlServer;

public class SqlServerDatabaseBuilder : IExportSourceBuilder
{
    private readonly string connectionString;

    public SqlServerDatabaseBuilder(string connectionString)
    {
        this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public ExportSource Build(string selectQuery)
    {
        try
        {
            var connect = new SqlConnection(connectionString);// dont use using statement,
                                                              // we need to keep it open to read data
            connect.Open();
            
            var cmd = connect.CreateCommand();
            cmd.CommandText = selectQuery;
            
            var reader = cmd.ExecuteReader();
            var database = new ExportSource
            {
                Connection = connect,
                Reader = reader
            };
            return database;
        }
        catch 
        {
            throw;
        }
    }
}