// ReSharper disable All
namespace ExpenseCLI.CommandOptions;

public class CommandOptionBuilder
{
    readonly string[] _args;

    public CommandOptionBuilder(string[] args)
    {
        this._args = args;
    }
    
    public CommandOptions Build()
    {
        var options = Parse(_args);
        return options;
    }

    protected CommandOptions Parse(string[] args)
    {
        var options = new CommandOptions();
        for (int i = 1; i < args.Length; i++)
        {
            
             if (args[i].Equals("--description", StringComparison.OrdinalIgnoreCase))
             {
                 options.Description = args[i + 1];
                 if (string.IsNullOrEmpty(options.Description))
                 {
                     throw new ArgumentException("khoản chi phí không được để trống");
                 }
             }else if (args[i].Equals("--amount", StringComparison.OrdinalIgnoreCase))
             {
                 try
                 {
                     options.Amount = double.Parse(args[i + 1]);
                     if (options.Amount < 0)
                     {
                         throw new ArgumentException("Tền tiêu không được âm");
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     throw;
                 }
             }else if (args[i].Equals("--category", StringComparison.OrdinalIgnoreCase))
             {
                 options.Category = args[i + 1];
                 if (string.IsNullOrEmpty(options.Category))
                 {
                     throw new ArgumentException("loại phí không được để trống");
                 }
             }else if (args[i].Equals("--id", StringComparison.OrdinalIgnoreCase))
             {
                 try
                 {
                     options.Id =  int.Parse(args[i + 1]);
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     throw;
                 }
                
             }else if (args[i].Equals("--month", StringComparison.OrdinalIgnoreCase))
             {
                 try
                 {
                     options.Month =  int.Parse(args[i + 1]);
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     throw;
                 }
             }
            
        }
        
        return options;
    }
}