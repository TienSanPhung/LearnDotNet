using MiniATM.Entities;
using MiniATM.UseCases.Repositories;

namespace MiniATM.UseCases;

public class RepositoryBankAccountFinder(IBankAccountRepository bankAccountRepository) : IBankAccountFinder
{
    private readonly IBankAccountRepository _bankAccountRepository = bankAccountRepository;

    public async Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid customerId)
    {
        return await _bankAccountRepository.FindByCustomerIdAsync(customerId);
    }
}