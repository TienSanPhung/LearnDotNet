using ExpenseCLI.DataStore;
using ExpenseCLI.DomainEntity;

namespace ExpenseCLI.Repository.FileRepository;

public class ExpenseRepository : IRepository
{
    
    readonly IDataStore _datastore;
    private List<Expense> _expenses = new List<Expense>();

    public ExpenseRepository( IDataStore dataStore)
    {
        
        this._datastore = dataStore;
        _expenses = _datastore.GetExpenses();
    }

    public Expense Create(Expense expense)
    {
        expense.Id = _expenses.Any()  ?  _expenses.Max(x=> x.Id) + 1 : 0 ;
        _expenses.Add(expense);
        _datastore.SaveChange(_expenses);
        return expense;
    }

    public List<Expense> List()
    {
        return _expenses;
    }
    public List<Expense> ListWithCategory(string category)
    {
        return _expenses.Where(x => x.Category.Equals(category)).ToList();
    }

    public Expense Update(Expense expense)
    {
        Expense E = _expenses.FirstOrDefault(x => x.Id == expense.Id);
        if (E != null)
        {
            E.Description = expense.Description ?? E.Description;
            E.Amount = expense.Amount == 0 ? E.Amount : expense.Amount;
            E.Date = DateTime.Now;
            E.Category = expense.Category  ?? E.Category ;
            _datastore.SaveChange(_expenses);
        }
        return E;
    }

    public void Delete(int id)
    {
        _expenses.RemoveAll(x => x.Id == id);
        _datastore.SaveChange(_expenses);
    }

    public Expense GetById(int id)
    {
       return _expenses.FirstOrDefault(x => x.Id == id);
    }

    public double Summary(int? mouth)
    {
        if (mouth == 0)
        {
            return _expenses.Sum(x => x.Amount);
        }else
        {
            return _expenses.Where(x => x.Date.Month == mouth && x.Date.Year == System.DateTime.Now.Year)
                .Sum(x => x.Amount);
        }
    }
}