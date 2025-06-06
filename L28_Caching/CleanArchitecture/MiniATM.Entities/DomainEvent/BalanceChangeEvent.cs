namespace MiniATM.Entities.DomainEvent;

public class BalanceChangeEvent : DomainEvent
{
    public required string AccountId {get;set;}
    public required double NewBalance {get;set;}
    public required double OldBalance {get;set;}
    
}