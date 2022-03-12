using Basket.Domain.Entities;
using MediatR;


namespace Basket.Application.Commands
{
    public class UpdateBasketCommand : IRequest<BasketCart>
    {
        public BasketCart BasketCart { get; set; }
        public UpdateBasketCommand(BasketCart basketCart) => BasketCart = basketCart;
    }
}
