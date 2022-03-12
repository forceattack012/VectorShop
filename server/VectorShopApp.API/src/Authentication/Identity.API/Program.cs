using Identity.API.Models;
using Identity.Application.DependencyInjection;
using Identity.Application.Services;
using Identity.Infrastucture.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MapGet("/", async() =>
{
    return Results.Ok("hello Identity Server");
});

app.MapPost("/api/authen/login", async (Login login,ILoginService _loginService) => {

    if(string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.Password))
    {
        return Results.BadRequest("Username or Password Invalid");
    } 
    var result = await _loginService.Login(login.UserName, login.Password);

    return Results.Ok(result);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();
//app.UseAuthorization();
app.Run();
