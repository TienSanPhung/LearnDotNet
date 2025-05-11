using RepoSample.Entity;

namespace RepoSample.Repository.InMemory;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> products = [];
    
    public Product? FindById(Guid id)
    {
        return products.Where(p => p.Id == id).FirstOrDefault();
    }

    public IEnumerable<Product> Find(ProductFindCreterias creterias, ProductSortBy sortBy = ProductSortBy.NameAscending)
    {
        var query = from o in products select o;
        if (creterias.Ids.Any())
        {
            query = query.Where(p => creterias.Ids.Contains(p.Id));
        }
        if (creterias.MinPrice !=double.MinValue)
        {
            query = query.Where(p => p.Price >= creterias.MinPrice);
        }
        if (creterias.MaxPrice !=double.MaxValue)
        {
            query = query.Where(p => p.Price <= creterias.MaxPrice);
        }

        if (!String.IsNullOrEmpty(creterias.Name))
        {
            query = query.Where(p => p.Name.Contains(creterias.Name, StringComparison.OrdinalIgnoreCase));
        }

        if (creterias.Skip > 0)
        {
            query = query.Skip(creterias.Skip);
        }
        if (creterias.Take > 0 && creterias.Take < int.MaxValue)
        {
            query = query.Take(creterias.Take);
            
        }
        
        return query;
    }

    public Product? Add(Product product)
    {
        products.Add(product);
        return product;
    }

    public int Update(Product product)
    {
        var p = products.Where(p => p.Id == product.Id).FirstOrDefault();
        if (p != null)
        {
            products.Remove(p);
            products.Add(product);
            return 1;
        }
        return 0;
    }

    public int DeleteAll()
    {
        int count = products.Count;
        products.Clear();
        return count;
    }
}