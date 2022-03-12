using Catalog.Domain.Entities;
using Catalog.Domain.Settings;
using Catalog.Infrasturcture.Data.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Catalog.Infrasturcture.Data
{
    public class CatalogContext : ICatalogContext
    {
        private IMongoCollection<Product> _productCollection;

        public CatalogContext(IOptions<CatalogDatabaseSettings> catalogDatabaseSettings)
        {
            var client = new MongoClient(catalogDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(catalogDatabaseSettings.Value.DatabaseName);
            _productCollection = database.GetCollection<Product>(catalogDatabaseSettings.Value.CollectionName);
            CatalogContextSeed.SendData(_productCollection);
        }
        public IMongoCollection<Product> Product => _productCollection;
    }
}
