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
        services.AddTransient<IArticleRepository>(services => new ArticleRepository(services.GetService<BlogDbContext>()));
        services.AddTransient<IAdminRepository>(services => new AdminRepository(services.GetService<BlogDbContext>()));
        services.AddTransient<IArticleManager>(services => new ArticleServices(
            services.GetService<Logger<ArticleServices>>(),services.GetService<IArticleRepository>()));
        services.AddTransient<IAdminManager>(services => new AdminServices(
            services.GetService<Logger<AdminServices>>(),services.GetService<IAdminRepository>()));
    }
}