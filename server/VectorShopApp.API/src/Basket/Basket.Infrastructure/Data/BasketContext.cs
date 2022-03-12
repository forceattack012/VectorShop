using Basket.Infrastructure.Data.Interfaces;
using StackExchange.Redis;

namespace Basket.Infrastructure.Data
{
    public class BasketContext : IBasketContext
    {
        private readonly IConnectionMultiplexer _redis;
        public BasketContext(IConnectionMultiplexer redis)
        {
            _redis = redis;
            Redis = _redis.GetDatabase();
        }
        public IDatabase Redis { get; }
    }
}
