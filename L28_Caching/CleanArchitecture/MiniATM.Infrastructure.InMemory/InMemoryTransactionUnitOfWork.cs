

using MiniATM.Infrastructure.InMemory;
using MiniATM.UseCases.Repositories;
using MiniATM.UseCases.UnitOfWork;

public class InMemoryTransactionUnitOfWork : ITransactionUnitOfWork
{
    public IBankAccountRepository BankAccountRepository { get; } = new InMemoryBankAccountRepository();
    public ITransactionRepository TransactionRepository { get; } = new InMemoryTransactionRepository();
    public Task BeginTransactionAsync()
    {
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }

    public Task CancelAsync()
    {
        return Task.CompletedTask;
    }
}