using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Event.Basket;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Basket.Infrastructure.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.BasketCartItemQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ReceivedEventAsync;

            channel.BasicConsume(queue: EventBusConstants.BasketCartItemQueue, autoAck: true, consumer: consumer, noLocal: false, exclusive: false, arguments: null);
        }

        private void ReceivedEventAsync(object sender, BasicDeliverEventArgs e)
        {
            if(e.RoutingKey == EventBusConstants.BasketCartItemQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var basket = JsonConvert.DeserializeObject<BasketCartEvent>(message);
                //sendBasketCartEventToClient(basket);
            }
        }

        //private async void sendBasketCartEventToClient(BasketCartEvent basketCartEvent)
        //{
        //    await _basketHub.Clients.All.SendAsync("sendBasketCartEvent", basketCartEvent);
        //}

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
