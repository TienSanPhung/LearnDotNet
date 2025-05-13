using Microsoft.Data.SqlClient;
using RepoSample.Entity;
using RepoSample.Repository;
using RepoSample.Repository.SQLServer;

namespace RepoSample.UnitofWork.Sql;

public class SqlServerCheckoutUnitOfWork : ICheckoutUnitOfWork
{
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    private SqlOrderRepository? _orderRepository;
    private  SqlProductRepository?_productRepository ;

    public SqlServerCheckoutUnitOfWork(SqlConnection connection)
    {
        this._connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _transaction = connection.BeginTransaction();
    }

    public SqlOrderRepository OrderRepository
    {
        get
        {
            _orderRepository ??= new SqlOrderRepository(_connection, _transaction);
            return _orderRepository;;
        }
    }
    public SqlProductRepository ProductRepository
    {
        get
        {
            _productRepository ??= new SqlProductRepository(_connection, _transaction);
            return _productRepository;;
        }
    }
    

    public void CreateOrder(Order order)
    {
        foreach (var item in order.OrderItems)
        {
            var product = ProductRepository.FindById(item.ProductId)?? throw new Exception($"Product not found: {item.ProductId}");
            if (product.Quantity - item.Quantity < 0)
            {
                throw new Exception($"Product {product.Name} not enough quantity");
            }
            product.Quantity -= item.Quantity;
            ProductRepository.Update(product);
        }
        OrderRepository.Add(order);
    }

    public void SaveChanges()
    {
        _transaction.Commit();
    }
}