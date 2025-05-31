namespace MiniATM.UseCases;

public interface ITranferManager
{
    Task<TransactionResult> TransferAsync(string fromAccountId,string toAccountId,double amount);
}