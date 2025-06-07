using Microsoft.EntityFrameworkCore;
using PBlog.DomainEntities;

namespace PersonalBlog.Infrastructure.SqlServer.ConText;

public class BlogDbContext : DbContext
{
    private readonly string connectionString;

    public BlogDbContext()
    {
        connectionString = @"Server=localhost,1433;Database=Blog;User Id=SA;Password=Daicabavi1;TrustServerCertificate=True;";
    }

    public BlogDbContext( string connectionString) 
    {
        this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Admin> Admins { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>()
            .HasNoKey(); // Xác định rằng thực thể này không có khóa chính
    }

}