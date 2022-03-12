using Basket.Domain.Repositories;
using Basket.Domain.Settings;
using Basket.Infrastructure.Data;
using Basket.Infrastructure.Data.Interfaces;
using Basket.Infrastructure.RabbitMQ;
using Basket.Infrastructure.Repositories;
using EventBusRabbitMQ;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using StackExchange.Redis;
using System.Security.Claims;

namespace Basket.Infrastructure.DependencyInjection
{
    public static class BasketDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, EventBus eventBus)
        {
            var multiplexer = ConnectionMultiplexer.Connect(connectionString);
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);
            services.AddTransient<IBasketContext, BasketContext>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddSingleton<IRabbitMQConnection>(r =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = eventBus.HostName,
                    UserName = eventBus.UserName,
                    Password = eventBus.Password,
                };
                return new RabbitMQConnection(factory);
            });
            services.AddSignalR();
            services.AddSingleton<EventBusRabbitMQConsumer>();

            return services;
        }

        public static IServiceCollection AddInfrastructureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:8083";
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });

            return services;
        }
    }
}
