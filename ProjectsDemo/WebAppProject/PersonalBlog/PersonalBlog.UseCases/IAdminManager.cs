namespace PersonalBlog.UseCases;

public interface IAdminManager
{
    public Task<Task> ChangesPassword(string oldPassword, string newPassword);
    public Task<Task> ResetPassword();
}