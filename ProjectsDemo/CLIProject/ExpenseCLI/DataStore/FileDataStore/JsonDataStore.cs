using System.Text.Json;
using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.DataStore.FileDataStore;

public class JsonDataStore : IDataStore 
{
    readonly string _path;
    public List<Expense> Expenses = new List<Expense>();
    public JsonDataStore(string path)
    {
        this._path = path;
    }

    public List<Expense> GetExpenses()
    {
        if (File.Exists(_path))
        {
            var json = File.ReadAllText(_path);
            if (String.IsNullOrEmpty(json))
            {
                Expenses = new List<Expense>();
            }
            else
            {
                Expenses = JsonSerializer.Deserialize<List<Expense>>(json);
            }
        }
        else
        {
            SaveChange(Expenses);
        }
        return Expenses;
    }

    public void SaveChange(List<Expense> expenses)
    {
        var options = new JsonSerializerOptions{WriteIndented = true};
        string json = JsonSerializer.Serialize(expenses, options);
        File.WriteAllText(_path, json);
    }
}