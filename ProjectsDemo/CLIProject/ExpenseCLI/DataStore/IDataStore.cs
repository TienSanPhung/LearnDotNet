using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.DataStore;

public interface IDataStore
{
    List<Expense> GetExpenses();
    void SaveChange(List<Expense> expenses);
}