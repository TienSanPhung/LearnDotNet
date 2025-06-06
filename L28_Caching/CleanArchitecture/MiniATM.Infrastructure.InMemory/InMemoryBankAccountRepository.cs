using MiniATM.Entities;
using MiniATM.UseCases;
using MiniATM.UseCases.Repositories;

namespace MiniATM.Infrastructure.InMemory;

public class InMemoryBankAccountRepository : IBankAccountRepository
{
    public List<BankAccount> BankAccounts ;
    
    public InMemoryBankAccountRepository(List<BankAccount> bankAccounts)
    {
        BankAccounts = bankAccounts;
    }

    public InMemoryBankAccountRepository()
    {
        BankAccounts = [
        new BankAccount()
        {
            Id = "001",
            Balance = 10000,
            Currency = "VND",
            CustomerId = Guid.Empty,
            IsLocked = false,
            MinimumRequiredAmount = 0
        },
        new BankAccount()
        {
            Id = "002",
            Balance = 20000,
            Currency = "VND",
            CustomerId = Guid.Empty,
            IsLocked = false,
            MinimumRequiredAmount = 0
        }];
    }

   
    
    public Task<BankAccount?> FindByIdAsync(string accountId)
    {
        return Task.FromResult(BankAccounts.Where(ba => ba.Id == accountId).FirstOrDefault());
    }

    public Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid id)
    {
        return Task.FromResult(BankAccounts.Where(x => x.CustomerId == id));
    }

    public Task UpdateAsync(BankAccount formBankAccount)
    {
        var bankAccount = BankAccounts.Where(x => x.Id == formBankAccount.Id).FirstOrDefault();
        if (bankAccount != null)
        {
            BankAccounts.Remove(bankAccount);
            BankAccounts.Add(formBankAccount);
        }
        return Task.CompletedTask;
    }
}