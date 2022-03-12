using Catalog.Domain.Repositories;
using Catalog.Domain.Repositories.Base;
using Catalog.Infrasturcture.Data;
using Catalog.Infrasturcture.Data.Interfaces;
using Catalog.Infrasturcture.Repositories;
using Catalog.Infrasturcture.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Catalog.Infrasturcture.DependencyInjection
{
    public static class CatalogDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICatalogContext, CatalogContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

            return services;
        }
    }
}
