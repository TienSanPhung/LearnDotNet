using System.Data;
using System.Data.Common;

namespace DBExport.DatabaseObjects;

public class ExportSource : IDisposable
{
    private bool disposeValue;
    
    public required DbConnection Connection { get; init; }
    public required DbDataReader Reader { get; init; }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposeValue)
        {
            if (disposing)
            {
                if(!Reader.IsClosed){
                    Reader.Close();
                }

                if (Connection.State == System.Data.ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            // Dispose unmanaged resources
            disposeValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
