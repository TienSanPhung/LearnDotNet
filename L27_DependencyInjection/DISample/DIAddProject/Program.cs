
using DIAddProject.IMyInterface;
using DIAddProject.MyClass;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable All

namespace DIAddProject;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMyAddTransient>(service => new MyTransient());
        serviceCollection.AddSingleton<IMyAddSingleton>(service => new MySingleton());
        serviceCollection.AddScoped<IMyAddScoped>(service => new MyScoped());
        
        var service = serviceCollection.BuildServiceProvider();
        
        
        object? ojb;
        
        Console.WriteLine("Get Singleton Service:");
        ojb = service.GetService<IMyAddSingleton>();
        ojb = service.GetService<IMyAddSingleton>();
        ojb = service.GetService<IMyAddSingleton>();
        
        Console.WriteLine("Get Scoped Service:");
        ojb = service.GetService<IMyAddScoped>();
        ojb = service.GetService<IMyAddScoped>();
        ojb = service.GetService<IMyAddScoped>();
        
        Console.WriteLine("Get Transient Service:");
        ojb = service.GetService<IMyAddTransient>();
        ojb = service.GetService<IMyAddTransient>();
        ojb = service.GetService<IMyAddTransient>();
        
        Console.WriteLine();
        Console.WriteLine("------------Create Scoped --------------");
        Console.WriteLine();
        
        var scoped = service.CreateScope();
        
        Console.WriteLine("Get Singleton Service:");
        ojb = scoped.ServiceProvider.GetService<IMyAddSingleton>();
        ojb = scoped.ServiceProvider.GetService<IMyAddSingleton>();
        ojb = scoped.ServiceProvider.GetService<IMyAddSingleton>();
        
        Console.WriteLine("Get Scoped Service:");
        ojb = scoped.ServiceProvider.GetService<IMyAddScoped>();
        ojb = scoped.ServiceProvider.GetService<IMyAddScoped>();
        ojb = scoped.ServiceProvider.GetService<IMyAddScoped>();
        
        Console.WriteLine("Get Transient Service:");
        ojb = scoped.ServiceProvider.GetService<IMyAddTransient>();
        ojb = scoped.ServiceProvider.GetService<IMyAddTransient>();
        ojb = scoped.ServiceProvider.GetService<IMyAddTransient>();
    }
}