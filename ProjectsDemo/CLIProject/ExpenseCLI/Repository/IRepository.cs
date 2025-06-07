using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.Repository;

public interface IRepository
{
    Expense Create(Expense expense);
    List<Expense> List();
    Expense Update(Expense expense);
    void Delete(int id);
    Expense GetById(int id);
    double Summary(int? mouth);
    public List<Expense> ListWithCategory(string category);
    
}