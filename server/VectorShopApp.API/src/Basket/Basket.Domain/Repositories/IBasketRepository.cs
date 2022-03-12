using Basket.Domain.Entities;
using Basket.Domain.Repositories.Base;


namespace Basket.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasketByUserName(string userName);
        bool UpdateBasketCart(BasketCart basketCart);
        Task<bool> DeleteBasketCartByUserName(string userName);
    }
}
