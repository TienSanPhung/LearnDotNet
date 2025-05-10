namespace RepoSample.Repository;

public class ProductFindCreterias : PagingCreterias
{
    public string Name = String.Empty ;
    public double MinPrice { get; set; } =double.MinValue;
    public double MaxPrice { get; set; } =double.MaxValue;
    public IEnumerable<Guid> Ids {set;get;} = Enumerable.Empty<Guid>();
    public static ProductFindCreterias Empty = new (){};
    
}