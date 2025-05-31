namespace MiniATM.UseCases;

public interface ICashWithDrawManager
{
    Task<TransactionResult> WithdrawAsync(string accountId,double amount);
}