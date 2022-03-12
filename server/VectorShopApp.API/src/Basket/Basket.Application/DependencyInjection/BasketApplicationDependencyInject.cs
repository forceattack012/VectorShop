using EventBusRabbitMQ.Producer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Application.DependencyInjection
{
    public static class BasketApplicationDependencyInject
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<EventBusRabbitMQProducer>();

            return services;
        }
    }
}
