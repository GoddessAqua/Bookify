using Microsoft.Extensions.Caching.Distributed;

namespace Bookify.Infrastructure.Caching
{
    internal class CacheServiceBase
    {
        private readonly IDistributedCache _cache;
    }
}