using Microsoft.EntityFrameworkCore;

namespace MiniATM.Infrastructure.SqlServer.Repository.DataContext;

public class MiniATMContext : DbContext
{
    private string _connectionString;
    public MiniATMContext()
    {
        _connectionString = @"Server=localhost,1433;Database=MiniATM;Use Id=SA;Password=Daicabavi1;TrustServerCertificate=True";
    }public MiniATMContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
}