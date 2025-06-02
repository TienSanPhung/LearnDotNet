using System.ComponentModel.DataAnnotations;

namespace MiniATM.Infrastructure.SqlServer.Repository.DataContext;

public class Customer
{
    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
}