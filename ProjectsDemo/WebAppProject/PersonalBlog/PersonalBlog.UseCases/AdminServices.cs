using Microsoft.Extensions.Logging;
using PBlog.DomainEntities;
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
        var passOldHash = HashPassword.HashPasswordSHA256(oldPassword);
        var admin = await _AdminRepository.GetAdmin();
        if (admin.Password != passOldHash)
        {
            _Logger.LogInformation("The old password is incorrect.");
            return Task.CompletedTask;
        }
        var passNewHash = HashPassword.HashPasswordSHA256(newPassword);
        await _AdminRepository.SetPassword(passNewHash);
        return Task.CompletedTask;
    }

    public async Task<bool> AuthenAdmin(string Password)
    {
        if (!string.IsNullOrEmpty(Password))
        {
            var admin = await  _AdminRepository.GetAdmin();
            if (admin.Password == HashPassword.HashPasswordSHA256(Password))
            {
                _Logger.LogInformation("The password is correct.");
                return true;
            }
            else
            {
                _Logger.LogInformation("The password is incorrect.");
                return false;
            }
        }
        return false;
    }

    public async Task<Task> ResetPassword()
    {
            _Logger.LogInformation("The password and new password are required."); 
            await _AdminRepository.ReSetPassword();
            return Task.CompletedTask;
    }
}