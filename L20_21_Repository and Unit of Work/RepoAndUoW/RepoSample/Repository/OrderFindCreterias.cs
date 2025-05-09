namespace RepoSample.Repository;

public class OrderFindCreterias : PagingCreterias
{
    public IEnumerable<Guid> Ids { get; set; } = Enumerable.Empty<Guid>();
    public IEnumerable<Guid> CustomerIds { get; set; } = Enumerable.Empty<Guid>();
    
}