namespace RepoSample.Repository;

public class PagingCreterias
{
    public int Skip {set;get;}
    public int Take {set;get;} = int.MaxValue;
}