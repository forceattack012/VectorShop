using Basket.Application.Commands;
using Basket.Domain.Entities;
using Basket.Domain.Hubs;
using Basket.Domain.Repositories;
using EventBusRabbitMQ.Event.Basket;
using EventBusRabbitMQ.Producer;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Basket.Application.Handlers
{
    public class UpdateBasketHandler : IRequestHandler<UpdateBasketCommand, BasketCart>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly EventBusRabbitMQProducer _eventBusRabbitMQProducer;
        private readonly IHubContext<BasketHub> _basketHub;

        public UpdateBasketHandler(IBasketRepository basketRepository, EventBusRabbitMQProducer eventBusRabbitMQProducer, IHubContext<BasketHub> basketHub)
        {
            _basketRepository = basketRepository;
            _eventBusRabbitMQProducer = eventBusRabbitMQProducer;
            _basketHub = basketHub;
        }

        public async Task<BasketCart> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var update = _basketRepository.UpdateBasketCart(request.BasketCart);
            if(!update)
            {
                return null;
            }

            var basket  = await _basketRepository.GetBasketByUserName(request.BasketCart.UserName);
            var basketCheckoutEvent = transformBasketCart(basket);
            sendBasketCartEventToClient(basketCheckoutEvent);
            //_eventBusRabbitMQProducer.PublishBasketCartItem(EventBusConstants.BasketCartItemQueue ,basketCheckoutEvent);

            return basket;
        }
        private BasketCartEvent transformBasketCart(BasketCart basketCart)
        {
            var basketCartEvent = new BasketCartEvent(basketCart.UserName);

            foreach(var item in basketCart.Items)
            {
                basketCartEvent.Items.Add(new EventBusRabbitMQ.Event.Basket.CartItem()
                {
                    Id = item.Id,
                    Colors = item.Colors,
                    Delivers = item.Delivers,
                    Detail = item.Detail,
                    Name = item.Name,
                    Price = item.Price,
                    Quitity = item.Quitity,
                    Type = item.Type,
                });
            }

            return basketCartEvent;
        }

        private async void sendBasketCartEventToClient(BasketCartEvent basketCartEvent)
        {
            await _basketHub.Clients.All.SendAsync("sendBasketCartEvent", basketCartEvent);
        }
    }
}
