using Basket.Domain.Entities;
using MediatR;

namespace Basket.Application.Queries
{
    public class GetBasketByUserNameQuery : IRequest<BasketCart>
    {
        public string UserName { get; set; }

        public GetBasketByUserNameQuery(string userName) => UserName = userName;
    }
}
