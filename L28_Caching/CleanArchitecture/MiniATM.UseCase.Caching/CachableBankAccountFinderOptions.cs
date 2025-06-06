namespace MiniATM.UseCase.Caching;

public class CachableBankAccountFinderOptions
{
    public string CacheKey { get; set; } = String.Empty;
    public TimeSpan CacheTimeSpan { get; set; } = TimeSpan.FromSeconds(15);
}