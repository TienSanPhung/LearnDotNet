using MiniATM.Entities;
using MiniATM.UseCases.Repositories;

namespace MiniATM.Infrastructure.InMemory;

public class InMemoryCustomerRepository : ICustomerRepository
{
    public List<Customer> Customers ;
    public InMemoryCustomerRepository()
    {
        Customers = [
        new Customer()
        {
            Id = Guid.Empty,
            Name = "SAN .NET",
        }
        ];
    }

    public InMemoryCustomerRepository(List<Customer> customers)
    {
        Customers = customers;
    }

    public Task<Customer?> FindByIdAsync(Guid id)
    {
        return Task.FromResult(Customers.Where(x => x.Id == id).FirstOrDefault());
    }
}