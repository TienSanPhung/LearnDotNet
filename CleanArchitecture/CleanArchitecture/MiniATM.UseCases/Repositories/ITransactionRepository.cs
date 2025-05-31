using  MiniATM.Entities;

namespace MiniATM.UseCases.Repositories;
public interface ITransactionRepository
{
    Task Add(Transaction transaction);
}