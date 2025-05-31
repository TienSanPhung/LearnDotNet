using MiniATM.Entities;

namespace MiniATM.UseCases.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> FindByIdAsync(Guid id);
}