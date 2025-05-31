namespace MiniATM.UseCases;

public interface ICashStorage
{
    bool IsCashAmountAvailable(double amount);
    void Withdraw(double amount);
}