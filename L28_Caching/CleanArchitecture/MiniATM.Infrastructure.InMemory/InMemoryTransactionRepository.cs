using MiniATM.Entities;
using MiniATM.UseCases.Repositories;

namespace MiniATM.Infrastructure.InMemory;

public class InMemoryTransactionRepository :  ITransactionRepository
{
    public List<Transaction> Transactions ;
    public InMemoryTransactionRepository()
    {
        Transactions = [];
    }

    public InMemoryTransactionRepository(List<Transaction> transactions)
    {
        Transactions = transactions;
    }

    public Task Add(Transaction transaction)
    {
        Transactions.Add(transaction);
        return Task.CompletedTask;
    }
}