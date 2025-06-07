using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MiniATM.Entities;
using MiniATM.UseCases;

namespace MiniATM.UseCase.Caching;

public class CachableBankAccountFinder : IBankAccountFinder
{
    
    private static readonly JsonSerializerOptions serializeOptions  = new (){};
    
    
    readonly IBankAccountFinder _parentFinder;
    readonly IDistributedCache _cache;
    readonly CachableBankAccountFinderOptions _options;
    readonly ILogger<CachableBankAccountFinder> _logger;
    readonly DistributedCacheEntryOptions _cacheEntryOptions;
    public CachableBankAccountFinder(IBankAccountFinder parentFinder, IDistributedCache cache, CachableBankAccountFinderOptions options,ILogger<CachableBankAccountFinder> logger)
    {
        this._parentFinder = parentFinder ?? throw new ArgumentNullException(nameof(parentFinder));
        this._cache = cache ?? throw new ArgumentNullException(nameof(cache));
        this._options = options;
        this._logger = logger;
        _cacheEntryOptions =  new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = options.CacheTimeSpan
        };
    }

    public async Task<IEnumerable<BankAccount>> FindByCustomerIdAsync(Guid id)
    {
        var cacheKey = $"{_options.CacheKey}#{id}";
        var cacheData =  await _cache.GetStringAsync(cacheKey);
        if (cacheData == null)
        {
            // cache miss
            _logger.LogInformation("LOADING ACCOUNT FROM PARENT...  ");
            var accounts = await _parentFinder.FindByCustomerIdAsync(id) ?? throw new ArgumentNullException(); 
            cacheData = JsonSerializer.Serialize(accounts, serializeOptions);
            _logger.LogInformation("Storing {data} to cache...", cacheData);
            await _cache.SetStringAsync(cacheKey, cacheData, _cacheEntryOptions);
            return accounts;
        }
        else
        {
            var accounts = JsonSerializer.Deserialize<IEnumerable<BankAccount>>(cacheData) ?? [];
            return  accounts;
        }
    }
}