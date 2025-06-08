using System.Security.Cryptography;
using System.Text;

namespace PBlog.DomainEntities;

public class Admin
{
    public int Id { get; set; } = 1;
    public required string Password { get; set; } = HashPassword.HashPasswordSHA256("admin");
    
}