namespace PersonalBlog.Infrastructure.Models;

public class ChangesPasswordModel
{
    public string oldPassword { get; set; }
    public string newPassword { get; set; }
}