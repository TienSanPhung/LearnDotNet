using System.Text;
using ExpenseCLI.CommandOptions;
using ExpenseCLI.DomainEntity;
using ExpenseCLI.Repository;

namespace ExpenseCLI;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            string path = @"C:\Users\pts20\Desktop\.net\LearnDotNet\ProjectsDemo\RoadMapProject\ExpenseCLI\JsonData.txt";
            var repository = ExpenseRepoFactory.CreateInstance(path, "json");
            CLIProcess(args,repository);
           var options = new CommandOptionBuilder(args);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    static void CLIProcess(string[] args, IRepository repository)
    {
        
        var options = new CommandOptionBuilder(args);
        var op =options.Build();
        if (args[0].Equals("add"))
        {
           
            Expense expense = new Expense()
            {
                Description = op.Description,
                Amount = op.Amount,
                Category = op.Category,
                Date = DateTime.Now
            };
            repository.Create(expense);
            Console.WriteLine("Add success");
            
        }else if (args[0].Equals("update"))
        {
           
            Expense expense = new Expense()
            {
                Description = op.Description,
                Amount = op.Amount,
                Category = op.Category,
            };
            repository.Update(expense);
            Console.WriteLine("Update success");
            
        }else if (args[0].Equals("delete"))
        {
           
            repository.Delete(op.Id);
            Console.WriteLine("Delete success");
            
        }else if (args[0].Equals("list"))
        {
            if (string.IsNullOrEmpty(op.Category))
            {
                var listExpenses = repository.List();
                PrintExpense(listExpenses);
            }
            else
            {
                var listExpenses = repository.ListWithCategory(op.Category);
                PrintExpense(listExpenses);
            }
            
            
        }else if (args[0].Equals("summary"))
        {
           
            var expense = repository.Summary(op.Month);
            Console.WriteLine($"# Total expenses: {expense}");
        }
    }

    static void PrintExpense(List<Expense> listExpenses)
    {
        Console.WriteLine("------------- EXPENSE ---------------");
        Console.WriteLine($"{"ID",-5} {"Description",-30} {"Amount",-15} {"Date",-30} {"Category",-20}");
        Console.WriteLine();
        foreach (var item in listExpenses)
        {
            Console.WriteLine($"{item.Id,-5} {item.Description,-30} {item.Amount,-15} {item.Date,-30} {item.Category,-20}");
        }
    }
}