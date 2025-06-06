using MiniATM.Entities.Exceptions;

namespace MiniATM.Entities;

public class BankAccount
{
    private double balance;
    public required string Id {set;get;}
    public required Guid CustomerId {set;get;}

    public required double Balance
    {
        set
        {
            if (value < MinimumRequiredAmount) throw new InValidBalanceException();
            balance = value;
        }
        get
        {
            return balance;
        }
    }
    public required string Currency { get; set; }
    public bool IsLocked { get; set; }
    public required double MinimumRequiredAmount {set;get;}
}