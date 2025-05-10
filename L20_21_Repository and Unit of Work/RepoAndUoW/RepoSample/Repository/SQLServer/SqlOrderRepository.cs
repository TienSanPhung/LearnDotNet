using System.Data;
using Microsoft.Data.SqlClient;
using RepoSample.Entity;

namespace RepoSample.Repository.SQLServer;

public class SqlOrderRepository : IOrderRepository
{
    private readonly string FIND_BY_ID_CMD = "SELECT CustomerId, OrderReference FROM Orders WHERE OrderId = @orderId";
    private readonly string FIND_Reference_CMD = "SELECT OrderId, CustomerId, OrderReference FROM Orders WHERE OrderId = @orderId";
    private readonly string DELETE_ALL_ORDER_ORDER_ITEM_CMD = "DELETE FROM Orders; DELETE FROM OrderItems";
    
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    public SqlOrderRepository(SqlConnection connection, SqlTransaction? transaction)
    {
        this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        this._transaction = transaction;
    }
    
    public IEnumerable<Order> Find(OrderFindCreterias creterias, OrderSortBy sortby = OrderSortBy.ReferenceAscending)
    {
        throw new NotImplementedException();
    }

    public Order? Add(Order order)
    {
        throw new NotImplementedException();
    }
    
    public Order? FindById(Guid id)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = FIND_BY_ID_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("@oderId",SqlDbType.UniqueIdentifier)).Value = id;
        using var reader = cmd.ExecuteReader();
        if (reader.Read() && reader!=null)
        {
            return new Order()
            {
                Id = id,
                CustomerId = reader.GetGuid(0),
                OrderReference = reader.GetString(1)
            };
        }
        else
        {
            return null;
        }
    }

    public Order? FindReference(string reference)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = FIND_Reference_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("@oderReference",SqlDbType.VarChar,20)).Value = reference;
        using var reader = cmd.ExecuteReader();
        if (reader.Read() && reader!=null)
        {
            return new Order()
            {
                Id = reader.GetGuid(0),
                CustomerId = reader.GetGuid(1),
                OrderReference = reference
            };
        }
        else
        {
            return null;
        }
    }


    public int DeleteAll()
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = DELETE_ALL_ORDER_ORDER_ITEM_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        return cmd.ExecuteNonQuery();
    }
}