using Catalog.Application.DependencyInjection;
using Catalog.Application.DTOs;
using Catalog.Application.Queries;
using Catalog.Domain.Settings;
using Catalog.Infrasturcture.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<CatalogDatabaseSettings>(configuration.GetSection("CatalogDatabaseSettings"));
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/products", async (IMediator mediator) =>
{
    var query = new GetAllProductQuery();
    var procuts = await mediator.Send(query);
    return procuts;
});

app.MapGet("/api/product/{id}", async (string id, IMediator mediator) =>
 {
     var query = new GetProductByIdQuery(id);
     return await mediator.Send(query) is ProductDTO product ? Results.Ok(product) : Results.NotFound();
 });

app.Run();

