using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddOcelot(configuration);


var app = builder.Build();


app.UseRouting();
app.UseWebSockets();
app.UseOcelot().Wait();

app.UseEndpoints(endpoints => {
    endpoints.MapGet("/", async context => {
        await context.Response.WriteAsync("Hello World!");
    });
});


app.Run();

