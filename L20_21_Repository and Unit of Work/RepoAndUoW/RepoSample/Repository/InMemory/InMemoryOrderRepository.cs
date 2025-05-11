using RepoSample.Entity;

namespace RepoSample.Repository.InMemory;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> orders = [];
    public Order? FindById(Guid id)
    {
        
        return orders.Where(o => o.Id == id).FirstOrDefault();
    }

    public Order? FindReference(string reference)
    {
        return orders.Where(o => o.OrderReference == reference).FirstOrDefault();
    }

    public IEnumerable<Order> Find(OrderFindCreterias creterias, OrderSortBy sortby = OrderSortBy.ReferenceAscending)
    {
        var query = from o in orders select o;
        if (creterias.Ids.Any())
        {
            query = query.Where(p => creterias.Ids.Contains(p.Id));
        }
        if (creterias.CustomerIds.Any())
        {
            query = query.Where(p => creterias.CustomerIds.Contains(p.CustomerId));
        }
        if (creterias.Skip > 0 )
        {
            query = query.Skip(creterias.Skip);
        }

        if (creterias.Take > 0 && creterias.Skip < int.MaxValue)
        {
            query = query.Take(creterias.Take);
        }
        if (sortby == OrderSortBy.ReferenceAscending)
        {
            query = query.OrderBy(o => o.OrderReference);
        }
        else
        {
            query = query.OrderByDescending(o => o.OrderReference);
        }
        return query;
        
    }

    public Order? Add(Order order)
    {
        ArgumentNullException.ThrowIfNull(order,nameof(order));
        if (orders.Any(o => o.OrderReference == order.OrderReference))
        {
            throw new Exception("Duplicated order reference");
        }
        orders.Add(order);
        return order;
    }

    public int DeleteAll()
    {
        int count = orders.Count;
        orders.Clear();
        return count;
    }
}