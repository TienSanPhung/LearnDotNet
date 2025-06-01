namespace MiniATM.UseCases;

public interface ICashWithdrawalManager
{
    Task<TransactionResult> WithdrawAsync(string accountId,double amount);
}