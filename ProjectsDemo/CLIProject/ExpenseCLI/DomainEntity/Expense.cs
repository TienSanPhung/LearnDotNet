namespace ExpenseCLI.DomainEntity;

public class Expense
{
    public int Id {get;set;}
    public required string Description {get;set;} = String.Empty;
    public Double Amount {get;set;} = 0;
    public DateTime Date {get;set;} = DateTime.Now;
    public string Category {get;set;} = String.Empty;
}