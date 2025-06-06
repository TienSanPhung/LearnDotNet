using MiniATM.Entities;

namespace MiniATM.UseCases.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccount> FindByIdAsync(string accountId);
    Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid id);
    Task UpdateAsync(BankAccount bankAccount);
}