using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using RepoSample.Entity;

namespace RepoSample.Repository.SQLServer;

public class SqlOrderRepository : IOrderRepository
{
    private readonly string INSERT_ORDER_CMD = "INSERT INTO Orders VALUES (@OrderId,@CustomerId,@OrderReference)";
    private readonly string INSERT_ORDER_ITEM_CMD = "INSERT INTO OrderItems VALUES (@OrderItemId,@OrderId,@ProductId,@Quantity,@Price)";
    
    private readonly string FIND_BY_ID_CMD = "SELECT CustomerId, OrderReference FROM Orders WHERE OrderId = @orderId";
    private readonly string FIND_Reference_CMD = "SELECT OrderId, CustomerId, OrderReference FROM Orders WHERE OrderId = @orderId";
    private readonly string SELECT_CMD = "SELECT";
    private readonly string FIND_ALL_CMD = "OrderId, CustomerId, OrderReference FROM Orders WHERE (1=1)";
    private readonly string FIND_iTEM_CMD = "SELECT OrderItemId, OrderId, ProductId, Quantity, Price FROM OrderItems WHERE OrderId = @orderId";
    
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
        var cmd = _connection.CreateCommand();
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        StringBuilder sql = new StringBuilder(SELECT_CMD);
        if (creterias.Take > 0)
        {
            sql.Append("TOP ");
            sql.Append(creterias.Take);
            sql.Append(' ');
        }
        sql.Append(FIND_ALL_CMD);
        if (creterias.Ids.Any())
        {
            sql.Append(" AND OrderId IN (");
            sql.Append(String.Join(',',creterias.Ids.Select(id => $"'{id}'")));
            sql.Append(')');
        }

        if (creterias.CustomerIds.Any())
        {
            sql.Append(" AND CustomerId IN (");
            sql.Append(String.Join(',',creterias.CustomerIds.Select(id => $"'{id}'")));
            sql.Append(')');
        }

        if (sortby == OrderSortBy.ReferenceAscending)
        {
            sql.Append(" ORDER BY OrderReference");
        }
        else
        {
            sql.Append(" ORDER BY OrderReference DESC");
        }

        if (creterias.Skip > 0)
        {
            sql.Append(" OFFSET ");
            sql.Append(creterias.Skip);
            sql.Append(" ROWS ");
        }
        cmd.CommandText = sql.ToString();
        using var reader = cmd.ExecuteReader();
        var orders = new List<Order>();
        if (reader != null)
        {
            while (reader.Read())
            {
                orders.Add(new Order()
                {
                    Id = reader.GetGuid(0),
                    CustomerId = reader.GetGuid(1),
                    OrderReference = reader.GetString(2)
                });
            }
            reader.Close();
        }

        foreach (var order in orders)
        {
            LoadOrderItems(order);
        }
        return orders;
    }

    private void LoadOrderItems(Order order)
    {
        var cmd = _connection.CreateCommand();
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.CommandText = FIND_iTEM_CMD;
        cmd.Parameters.Add(new SqlParameter("@orderId",SqlDbType.UniqueIdentifier)).Value = order.Id;
        using var reader = cmd.ExecuteReader();
        if (reader != null)
        {
            while (reader.Read())
            {
                order.OrderItems.Add(new OrderItem()
                {
                    Id = reader.GetGuid(0),
                    OrderId = reader.GetGuid(1),
                    ProductId = reader.GetGuid(2),
                    Quantity = reader.GetInt32(3),
                    Price = reader.GetDouble(4)
                });
            }
            reader.Close();
        }
    }

    public Order? Add(Order order)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = INSERT_ORDER_CMD;
        if (_transaction!=null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("@OrderId",SqlDbType.UniqueIdentifier)).Value = order.Id;
        cmd.Parameters.Add(new SqlParameter("@CustomerId",SqlDbType.UniqueIdentifier)).Value = order.CustomerId;
        cmd.Parameters.Add(new SqlParameter("@OrderReference",SqlDbType.VarChar,20)).Value = order.OrderReference;
        if (cmd.ExecuteNonQuery() > 0)
        {
            cmd.CommandText = INSERT_ORDER_ITEM_CMD;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@OrderItemId",SqlDbType.UniqueIdentifier));
            cmd.Parameters.Add(new SqlParameter("@OrderId",SqlDbType.UniqueIdentifier)).Value = order.Id;
            cmd.Parameters.Add(new SqlParameter("@ProductId",SqlDbType.UniqueIdentifier));
            cmd.Parameters.Add(new SqlParameter("@Quantity",SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@Price",SqlDbType.Decimal));
            foreach (var item in order.OrderItems)
            {
                cmd.Parameters["OderItemId"].Value = item.Id;
                cmd.Parameters["ProductId"].Value = item.ProductId;
                cmd.Parameters["Quantity"].Value = item.Quantity;
                cmd.Parameters["Price"].Value = item.Price;
                if (cmd.ExecuteNonQuery() == 0)
                {
                    throw  new Exception("Error while inserting order item");
                }
            }
            
            return order;
        }
        else
        {
            return null;
        }
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
            reader.Close();
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
            reader.Close();
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