using PBlog.DomainEntities;

namespace PersonalBlog.UseCases.IRepository;

public interface IAdminRepository
{
    public Task<Admin> GetAdmin();
    public Task SetPassword(string Password);
    public Task ReSetPassword();
}