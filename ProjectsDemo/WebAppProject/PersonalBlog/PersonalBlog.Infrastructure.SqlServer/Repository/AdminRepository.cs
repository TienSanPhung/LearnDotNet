using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PBlog.DomainEntities;
using PersonalBlog.Infrastructure.SqlServer.ConText;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.Infrastructure.SqlServer.Repository;

public class AdminRepository : IAdminRepository
{
    readonly BlogDbContext _Context;

    public AdminRepository( BlogDbContext context)
    {
        this._Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async  Task<Admin> GetAdmin()
    {
        return await _Context.Admins.Where(x => x.Id == 1).FirstOrDefaultAsync();
    }

    public async Task SetPassword(string Password)
    {
       var admin = await _Context.Admins.Where(x => x.Id == 1).FirstOrDefaultAsync();
       
       admin.Password = Password;
       _Context.Admins.Update(admin);
       await _Context.SaveChangesAsync();
    }

    public async Task ReSetPassword()
    {
        var admin = await _Context.Admins.Where(x => x.Id == 1).FirstOrDefaultAsync();
        admin.Password = HashPassword.HashPasswordSHA256("admin");
        await _Context.SaveChangesAsync();
    }
}