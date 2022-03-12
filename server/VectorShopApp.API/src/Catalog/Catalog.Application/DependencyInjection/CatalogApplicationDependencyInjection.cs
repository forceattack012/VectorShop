using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Catalog.Application.DependencyInjection
{
    public static class CatalogApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
