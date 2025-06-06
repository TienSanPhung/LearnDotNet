using MiniATM.UseCases.Repositories;

namespace MiniATM.UseCases.UnitOfWork;

public interface ITransactionUnitOfWork
{
    IBankAccountRepository BankAccountRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    
    Task BeginTransactionAsync();
    Task SaveChangesAsync();
    Task CancelAsync(); // phương thức này nên được gọi khi xong việc,
                        // một triển khai của ITransactionUnitOfWork nên triển khai IDisposable để xử lý
}