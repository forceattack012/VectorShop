using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using Basket.Infrastructure.Data.Interfaces;
using Basket.Infrastructure.Repositories.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _basketContext;
        public BasketRepository(IBasketContext basketContext)
        {
            _basketContext = basketContext;
        }

        public bool UpdateBasketCart(BasketCart basketCart)
        {
            var update = _basketContext.Redis.StringSet(basketCart.UserName, JsonConvert.SerializeObject(basketCart));
            return update;
        }

        public async Task<bool> DeleteBasketCartByUserName(string userName)
        {
            var delete = await _basketContext.Redis.KeyDeleteAsync(userName);
            return delete;
        }

        public async Task<BasketCart?> GetBasketByUserName(string userName)
        {
            var basket = await _basketContext.Redis.StringGetAsync(userName);
            if(basket.IsNull)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }
    }
}
