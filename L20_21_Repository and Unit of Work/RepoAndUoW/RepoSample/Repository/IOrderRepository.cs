using RepoSample.Entity;

namespace RepoSample.Repository;

public interface IOrderRepository
{
    Order? FindById(Guid id);
    Order? FindReference(string reference);
    IEnumerable<Order> Find(OrderFindCreterias creterias, OrderSortBy sortby = OrderSortBy.ReferenceAscending);
    Order? Add(Order order);
    int DeleteAll();
    
}