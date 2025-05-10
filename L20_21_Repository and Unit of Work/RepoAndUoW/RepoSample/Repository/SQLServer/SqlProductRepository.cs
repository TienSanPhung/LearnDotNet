using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using RepoSample.Entity;

namespace RepoSample.Repository.SQLServer;

public class SqlProductRepository : IProductRepository
{
    private readonly string INSERT_CMD = "INSERT INTO Products VALUES (@product.Id,@product.Name,@product.Price,@product.Quantity)";
    private readonly string UPDATE_CMD = "UPDATE  Products SET Product.Name = @product.Name, Product.Price = @product.Price, Product.Quantity= @product.Quantity";
    private readonly string DELETE_ALL_CMD = "DELETE From Products";
    private readonly string SELECT_CMD = "SELECT";
    private readonly string FIND_ALL_CMD = "ProductId,ProductName,ProductPrice,Quantity FROM Product WHERE (1=1) ";
    private readonly string FIND_BY_ID_CMD = "SELECT ProductName,ProductPrice,Quantity FROM Product WHERE Product.ID = @product.Id ";
    
    
    
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    
    public SqlProductRepository(SqlConnection connection, SqlTransaction? transaction)
    {
        this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        this._transaction = transaction ;
    }
    public IEnumerable<Product> Find(ProductFindCreterias creterias, ProductSortBy sortBy = ProductSortBy.NameAscending)
    {
        var cmd = _connection.CreateCommand();
       // cmd.CommandText = SELECT_CMD;
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
            sql.Append(" AND ProductId IN (");
            sql.Append(String.Join(',',creterias.Ids.Select(id => $"'{id}'")));
            sql.Append(')');
        }

        if (creterias.MaxPrice !=double.MaxValue)
        {
            sql.Append(" AND ProductPrice <= @MaxPrice ");
            cmd.Parameters.Add(new SqlParameter("@MaxPrice",SqlDbType.Decimal)).Value = creterias.MaxPrice;
        }
        if (creterias.MinPrice !=double.MinValue)
        {
            sql.Append(" AND ProductPrice >= @MinPrice ");
            cmd.Parameters.Add(new SqlParameter("@MinPrice",SqlDbType.Decimal)).Value = creterias.MinPrice;
        }

        if (String.IsNullOrEmpty(creterias.Name))
        {
            sql.Append(" AND ProductName Like @Name ");
            cmd.Parameters.Add(new SqlParameter("@Name",SqlDbType.VarChar,255)).Value = "%" + creterias.Name + "%";
        }

        if (sortBy == ProductSortBy.NameAscending)
        {
            sql.Append(" ORDER BY ProductName");
        }
        else if(sortBy == ProductSortBy.NameDescending)
        {
            sql.Append(" ORDER BY ProductName DESC");
        }
        else if(sortBy == ProductSortBy.PriceAscending)
        {
             sql.Append(" ORDER BY ProductPrice");
        }
        else
        {
            sql.Append(" ORDER BY ProductPrice DESC");
        }

        if (creterias.Skip > 0)
        {
            sql.Append(" OFFSET ");
            sql.Append(creterias.Skip);
            sql.Append(" ROWS ");
        }
        cmd.CommandText = sql.ToString();
        using var reader = cmd.ExecuteReader();
        var order = new List<Product>();
        if (reader != null)
        {
            while (reader.Read())
            {
                order.Add(new Product()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2),
                    Quantity = reader.GetInt32(3)
                });
                
            }
            reader.Close();
        }
        return order;
    }
    public Product? FindById(Guid id)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = FIND_BY_ID_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("@product.Id",SqlDbType.UniqueIdentifier)).Value = id;
        using var reader = cmd.ExecuteReader();
        if (reader.Read() && reader!=null)
        {
            return new Product()
            {
                Id = id,
                Name = reader.GetString(0),
                Price = reader.GetDouble(1),
                Quantity = reader.GetInt32(2)
            };
            reader.Close();
        }
        else
        {
            return null;
        }
    }

    

    public Product? Add(Product product)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = INSERT_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("@product.Id",SqlDbType.UniqueIdentifier)).Value = product.Id;
        cmd.Parameters.Add(new SqlParameter("@product.Name",SqlDbType.VarChar,255)).Value = product.Name;
        cmd.Parameters.Add(new SqlParameter("@product.Price",SqlDbType.Decimal)).Value = product.Price;
        cmd.Parameters.Add(new SqlParameter("@product.Quantity",SqlDbType.Int)).Value = product.Quantity;
        if (cmd.ExecuteNonQuery() > 0)
        {
            return product;
        }
        else
        {
            return null;
        }
    }

    public int Update(Product product)
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = UPDATE_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        cmd.Parameters.Add(new SqlParameter("product.Name",SqlDbType.VarChar,255)).Value = product.Name;
        cmd.Parameters.Add(new SqlParameter("product.Price",SqlDbType.Decimal)).Value = product.Price;
        cmd.Parameters.Add(new SqlParameter("product.Quantity",SqlDbType.Int)).Value = product.Quantity;
        
        return cmd.ExecuteNonQuery();
    }

    public int DeleteAll()
    {
        var cmd = _connection.CreateCommand();
        cmd.CommandText = DELETE_ALL_CMD;
        if (_transaction != null)
        {
            cmd.Transaction = _transaction;
        }
        return cmd.ExecuteNonQuery();
    }
}