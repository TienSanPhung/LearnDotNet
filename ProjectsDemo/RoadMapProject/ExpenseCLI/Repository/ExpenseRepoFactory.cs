using ExpenseCLI.DataStore.FileDataStore;
using ExpenseCLI.Repository.FileRepository;

namespace ExpenseCLI.Repository;

public class ExpenseRepoFactory
{
    public static IRepository CreateInstance(string path, string storeType)
    {
        if(File.Exists(path)){
            if (storeType.Equals( "json", StringComparison.OrdinalIgnoreCase))
            {
                return new ExpenseRepository(new JsonDataStore(path));
            }else if (storeType.Equals( "csv", StringComparison.OrdinalIgnoreCase))
            {
                return new ExpenseRepository(new CsvDataStore(path));
            }
        }
        else
        {
            Console.WriteLine("File not exist");
        }
        return null;
    }
}