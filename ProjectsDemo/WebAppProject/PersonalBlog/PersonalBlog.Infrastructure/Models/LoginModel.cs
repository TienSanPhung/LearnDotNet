using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Infrastructure.Models;

public class LoginModel
{
    [Required]
    public string Password { get; set; }

}