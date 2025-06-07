using System.Security.Cryptography;
using System.Text;

namespace PBlog.DomainEntities;

public class Admin
{
    public required string Password { get; set; } = HashPasswordSHA256("admin");
    static string HashPasswordSHA256(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}