namespace MiniATM.UseCase.Caching;

public class CachableBankAccountFinderOptions
{
    public string CacheKey { get; set; } = "CUSTOMER|ID:";
    public TimeSpan CacheTimeSpan { get; set; } = TimeSpan.FromSeconds(120);
}