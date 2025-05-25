using System.Text.Json;
using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.DataStore.FileDataStore;

public class JsonDataStore : IDataStore 
{
    readonly string _path;

    public JsonDataStore(string path)
    {
        this._path = path;
    }

    public List<Expense> GetExpenses()
    {
        if (File.Exists(_path))
        {
            var json = File.ReadAllText(_path);
            if (json == null)
            {
                return new List<Expense>();
            }
            else
            {
                return JsonSerializer.Deserialize<List<Expense>>(json)?? new List<Expense>();
            }
        }
        return new List<Expense>();
    }

    public void SaveChange(List<Expense> expenses)
    {
        var options = new JsonSerializerOptions{WriteIndented = true};
        string json = JsonSerializer.Serialize(expenses, options);
        File.WriteAllText(_path, json);
    }
}