using MiniATM.Entities;

namespace MiniATM.UseCases;

public interface IBankAccountFinder
{
    Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid id);
}