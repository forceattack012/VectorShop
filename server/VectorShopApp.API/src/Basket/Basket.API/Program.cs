using Basket.Infrastructure.DependencyInjection;
using Basket.Application.DependencyInjection;
using MediatR;
using Basket.Application.Queries;
using Basket.Domain.Entities;
using Basket.Application.Commands;
using Basket.Domain.Settings;
using Basket.Infrastructure.RabbitMQ.Extension;
using Basket.Domain.Hubs;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Func<string> getRedisConectionString = () =>
{
    ConfigurationManager configuration = builder.Configuration;
    return configuration.GetSection("Redis:ConnectionString").Value;
};

Func<EventBus> getEventBusSetting = () =>
{
    ConfigurationManager configuration = builder.Configuration;
    return new EventBus()
    {
        HostName = configuration.GetSection("EventBus:HostName").Value,
        Password = configuration.GetSection("EventBus:Password").Value,
        UserName = configuration.GetSection("EventBus:Password").Value
    };
};

ConfigurationManager configuration = builder.Configuration;
var connection = getRedisConectionString();
var eventBusSetting = getEventBusSetting();

builder.Services.AddInfrastructure(connection, eventBusSetting);
builder.Services.AddInfrastructureAuthentication();
builder.Services.AddApplication();

var app = builder.Build();

app.MapGet("/api/basket/{userName}", [Authorize] async (IMediator mediator, string userName) =>
{
    var query = new GetBasketByUserNameQuery(userName);
    var basket = await mediator.Send(query);

    if (basket is BasketCart)
    {
        return Results.Ok(basket);
    }
    return Results.NotFound();
});

app.MapPost("/api/basket", [Authorize] async (IMediator mediator, BasketCart requestBasket) =>
{
    var command = new UpdateBasketCommand(requestBasket);
    var basket = await mediator.Send(command);

    return Results.Ok(basket);
});

app.MapDelete("/api/basket/{userName}", [Authorize] async (IMediator mediator, string userName) =>
{
    var command = new DeleteBasketByUserNameCommand(userName);
    var delete = await mediator.Send(command);

    return Results.Ok(delete);
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(configure =>
{
    configure.MapHub<BasketHub>("/basketHub");
});

app.UseRabbitListener();
app.Run();

