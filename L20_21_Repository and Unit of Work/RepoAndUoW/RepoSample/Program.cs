using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepoSample.Entity;
using RepoSample.Repository;
using RepoSample.Repository.InMemory;
using RepoSample.Repository.SQLServer;
using RepoSample.UnitofWork;
using RepoSample.UnitofWork.Sql;

namespace RepoSample;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("ConnectionStrings.json",optional:true).Build();
        string connectionString = config.GetConnectionString("Shop") ?? string.Empty;
        if (connectionString.Length >0)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var tran = conn.BeginTransaction();
            
            IProductRepository productRepository = new SqlProductRepository(conn, tran);
            IOrderRepository orderRepository = new SqlOrderRepository(conn, tran);
            
            orderRepository.DeleteAll();
            productRepository.DeleteAll();
            
            
            InsertProduct(productRepository);
            QueryProduct(productRepository);
            tran.Commit();
            
            CreateOder(conn);
            QueryOder(orderRepository);
        }
        else
        {
            var inMemoryProduct = new InMemoryProductRepository();
            var inMemoryOrder = new InMemoryProductRepository();
            
            InsertProduct(inMemoryProduct);
            QueryProduct(inMemoryProduct);
        }
    }

    private static void QueryOder(IOrderRepository orderRepository)
    {
        
    }

    private static void CreateOder(SqlConnection conn)
    {
        var orderCreate = new SqlServerCheckoutUnitOfWork(conn);
        var orderId = Guid.NewGuid();
        orderCreate.CreateOrder(new Order()
        {
            Id = orderId,
            CustomerId = Guid.Empty,
            OrderReference = "00001",
            OrderItems = [
                new OrderItem()
                {
                    Id = new Guid("00000000-0000-0000-0001-000000000001"),
                    OrderId = orderId,
                    Price = 100,
                    ProductId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Quantity = 3
                },
                new OrderItem()
                {
                    Id = new Guid("00000000-0000-0000-0001-000000000002"),
                    OrderId = orderId,
                    Price = 200,
                    ProductId = new Guid("00000000-0000-0000-0000-000000000002"),
                    Quantity = 2
                }
            ]
        });
        orderCreate.SaveChanges();
    }

    private static void QueryProduct(IProductRepository productRepository)
    {
        Console.WriteLine("-----------Rau có giá lớn hơn 250--------------");
        var ProductMoreThan250 = productRepository.Find(new ProductFindCreterias()
        {
            MinPrice = 250
        });
        PrintProduct(ProductMoreThan250);
        
        Console.WriteLine("-----------Rau có giá nhỏ hơn 250------------");
        var ProductLessThan250 = productRepository.Find(new ProductFindCreterias()
        {
            MaxPrice  = 250
        });
        PrintProduct(ProductLessThan250);
        
        Console.WriteLine("-----------Loại rau nhà rau Húng--------------");
        var ProductNameHung = productRepository.Find(new ProductFindCreterias()
        {
            Name = "Húng"
        });
        PrintProduct(ProductNameHung);
    }

    private static void PrintProduct(IEnumerable<Product> product)
    {
        if (product == null)
        {
            Console.WriteLine("Không có sản phẩm nào");
            return;
        }
        foreach (var p in product)
        {
            Console.WriteLine($"Id: {p.Id,20}, Name: {p.Name,20}, Price: {p.Price,20}");
        }
    }

    private static void InsertProduct(IProductRepository productRepository)
    {
        productRepository.Add(new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Name = "Rau Muống",
            Price = 100,
            Quantity = 100
        });
        productRepository.Add(new()
        {
            Id = new Guid("00000000-0000-0000-0000-000000000002"),
            Name = "Rau Húng",
            Price = 200,
            Quantity = 200
        });
        productRepository.Add(new()
        {
            Id =new Guid("00000000-0000-0000-0000-000000000003"),
            Name = "Rau Bí",
            Price = 251,
            Quantity = 300
        });
        productRepository.Add(new()
        {
            Id =new Guid("00000000-0000-0000-0000-000000000004"),
            Name = "Rau Húng Bạc Hà",
            Price = 400,
            Quantity = 400
        });
    }
}