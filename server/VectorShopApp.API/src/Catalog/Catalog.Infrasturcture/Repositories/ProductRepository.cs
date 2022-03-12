using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrasturcture.Data.Interfaces;
using System.Linq;

using MongoDB.Driver;

namespace Catalog.Infrasturcture.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICatalogContext _catalogContext;
        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync() => await _catalogContext.Product.Find(_ => true).ToListAsync();

        public async Task<Product> GetByIdAsync(string id) => await _catalogContext.Product.Find(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<List<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> nameFilter = Builders<Product>.Filter.Eq(r => r.Name, name);
            return await _catalogContext.Product.Find(nameFilter).ToListAsync();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
