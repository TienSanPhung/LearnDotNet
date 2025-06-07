namespace ExpenseCLI.CommandOptions;

public class CommandOptions
{
    
    public int Id {get;set;}
    public string Description {get;set;} = null;
    public Double Amount {get;set;} = 0;
    public string Category {get;set;} = null;
    public int Month {get;set;} = 0;
}