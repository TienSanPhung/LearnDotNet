using Microsoft.Extensions.Logging;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.UseCases;

public class AdminServices : IAdminManager
{
    readonly ILogger<AdminServices> _Logger;
    readonly IAdminRepository _AdminRepository;

    public AdminServices(ILogger<AdminServices> logger, IAdminRepository adminRepository)
    {
        this._Logger = logger;
        this._AdminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
    }


    public async Task<Task> ChangesPassword(string oldPassword, string newPassword)
    {
        if (String.IsNullOrEmpty(oldPassword) || String.IsNullOrEmpty(newPassword))
        {
           _Logger.LogInformation("The password and new password are required."); 
           return Task.CompletedTask;
        }
        await _AdminRepository.SetPassword(newPassword);
        return Task.CompletedTask;
    }

    public async Task<Task> ResetPassword()
    {
            _Logger.LogInformation("The password and new password are required."); 
            await _AdminRepository.ReSetPassword();
            return Task.CompletedTask;
    }
}