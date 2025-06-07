using System.Security.Cryptography;
using System.Text;

namespace PBlog.DomainEntities;

public class Admin
{
    public required string Password { get; set; } = HashPassword.HashPasswordSHA256("admin");
    
}