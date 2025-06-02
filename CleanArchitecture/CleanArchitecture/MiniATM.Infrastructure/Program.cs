using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniATM.Infrastructure.CashStorage;
using MiniATM.Infrastructure.Models;
using MiniATM.Infrastructure.SqlServer.Repository;
using MiniATM.Infrastructure.SqlServer.Repository.DataContext;
using MiniATM.Infrastructure.SqlServer.Repository.MapperProfile;
using MiniATM.UseCases;
using MiniATM.UseCases.Repositories;
using MiniATM.UseCases.UnitOfWork;

namespace MiniATM.Infrastructure;

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

    private static void RegisterInfrastructureServices(ConfigurationManager configuration, IServiceCollection services)
    {
        var repositoryOptions = configuration.GetSection("RepositoryOptions").Get<RepositoryOptions>() ??
                                throw new Exception("No RepositoryOptions found");

        if (repositoryOptions.RepositoryType == RepositoryTypes.SqlServer)
        {
            services.AddAutoMapper(typeof(SqlServer2EntityProfile));

            services.AddDbContext<MiniATMContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MiniATMDatabase")));

            services.AddTransient<IBankAccountRepository>(services => new SqlServerBankAccountRepository(
                services.GetRequiredService<MiniATMContext>(), services.GetRequiredService<IMapper>()
            ));
            services.AddTransient<ICustomerRepository>(services => new SqlServerCustomerRepository(
                services.GetRequiredService<MiniATMContext>(), services.GetRequiredService<IMapper>()
            ));
            services.AddTransient<ITransactionRepository>(services => new SqlServerTransactionRepository(
                services.GetRequiredService<MiniATMContext>(), services.GetRequiredService<IMapper>()
            ));
            services.AddTransient<IBankAccountFinder>(services => new RepositoryBankAccountFinder(
                services.GetRequiredService<IBankAccountRepository>()
            ));
            services.AddTransient<ITransactionUnitOfWork>(services => new SqlServerTransactionUnitOfWork(
                services.GetRequiredService<MiniATMContext>(), services.GetRequiredService<IMapper>()
            ));

            services.AddSingleton<ICashStorage>(services => new InMemoryCashStorage(
                services.GetRequiredService<ILogger<InMemoryCashStorage>>(),
                5000
            ));
            services.AddTransient<ICashWithdrawalManager>(services => new CashWithdrawalManager(
                services.GetRequiredService<ITransactionUnitOfWork>(),
                services.GetRequiredService<ICashStorage>(),
                true
            ));
            services.AddTransient<ITransferManager>(services => new TransferManager(
                services.GetRequiredService<ITransactionUnitOfWork>()
            ));

        }
        else
        {
            // we need to implement remote repositories and register here
        }
    }
}