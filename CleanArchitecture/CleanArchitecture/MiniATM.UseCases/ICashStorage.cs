namespace MiniATM.UseCases;

public interface ICashStorage
{
    bool IsCashAmountAvailable(double amount);
    bool Withdraw(double amount);
}