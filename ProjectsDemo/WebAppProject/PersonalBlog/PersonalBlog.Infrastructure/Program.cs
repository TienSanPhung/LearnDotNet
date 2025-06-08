using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Infrastructure.SqlServer.ConText;
using PersonalBlog.Infrastructure.SqlServer.Repository;
using PersonalBlog.UseCases;
using PersonalBlog.UseCases.IRepository;

namespace PersonalBlog.Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
               options.LoginPath = "/Admin/Login";
                options.LogoutPath = "/Admin/Logout";
                options.AccessDeniedPath = "/Admin/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "PersonalBlog"; 
            });
        RegisterInfrastructureServices(builder.Configuration, builder.Services);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }

    static void RegisterInfrastructureServices(ConfigurationManager configuration, IServiceCollection services)
    {
        
        services.AddDbContext<BlogDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("PersonalBlog")));
        services.AddTransient<IArticleRepository>(services => new ArticleRepository(services.GetRequiredService<BlogDbContext>()));
        services.AddTransient<IAdminRepository>(services => new AdminRepository(services.GetRequiredService<BlogDbContext>()));
        services.AddTransient<IArticleManager>(services => new ArticleServices(
            services.GetRequiredService<ILogger<ArticleServices>>(),services.GetRequiredService<IArticleRepository>()));
        services.AddTransient<IAdminManager>(services => new AdminServices(
            services.GetRequiredService<ILogger<AdminServices>>(),services.GetRequiredService<IAdminRepository>()));
    }
}