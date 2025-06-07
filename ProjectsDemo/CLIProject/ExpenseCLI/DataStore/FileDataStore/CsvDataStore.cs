using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.DataStore.FileDataStore;

public class CsvDataStore : IDataStore
{
    readonly string _path;

    public CsvDataStore(string path)
    {
        this._path = path;
    }

    public List<Expense> GetExpenses()
    {
        if (File.Exists(_path))
        {
            List<Expense> expenses = new List<Expense>();
            var lines = File.ReadAllLines(_path);
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                Expense expense = new Expense
                {
                    Id = int.Parse(parts[0]),
                    Description = parts[1],
                    Amount = double.Parse(parts[2]),
                    Date = DateTime.Parse(parts[3]),
                    Category = parts[4]
                };
                expenses.Add(expense);
            }
            return expenses;
            
        }
        else
        {
            return new List<Expense>();
        }
    }

    public void SaveChange(List<Expense> expenses)
    {
        using (var writer = new StreamWriter(_path))
        {
            writer.WriteLine("Id,Description,Amount,Date,Category");
            foreach (var expense in expenses)
            {
                writer.WriteLine($"{expense.Id},{expense.Description},{expense.Amount},{expense.Date.ToShortDateString()},{expense.Category}");
            }
        }
    }
}