using RepoSample.Entity;

namespace RepoSample.UnitofWork;

public interface ICheckoutUnitOfWork
{
    void CreateOrder(Order order);
    void SaveChanges();
}