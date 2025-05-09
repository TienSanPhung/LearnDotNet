using RepoSample.Entity;

namespace RepoSample.Repository;

public interface IProductRepository
{
    Product? FindById(Guid id);
    IEnumerable<Product> Find(ProductFindCreterias creterias, ProductSortBy sortBy = ProductSortBy.NameAscending);
    Product? Add(Product product);
    int Update(Product product);
    int DeleteAll();
}