using DBExport.DatabaseBuilders.SqlServer;
using DBExport.DatabaseObjects;
using DBExporter.Options;

namespace DBExport.DatabaseBuilders;

public class DatabaseBuilderFactory
{
    public  static IExportSourceBuilder? connect(ServerTypes serverType, string connectionString)
    {
        return serverType switch
        {
            ServerTypes.SqlServer => new SqlServerDatabaseBuilder(connectionString),
            _ => null
        };
    }
    
}