namespace PersonalBlog.UseCases;

public interface IAdminManager
{
    public Task<Task> ChangesPassword(string oldPassword, string newPassword);
    public Task<bool> AuthenAdmin(string Password);
    public Task<Task> ResetPassword();
}