using Catalog.Domain.Entities;
using Catalog.Domain.Enums;
using MongoDB.Driver;

namespace Catalog.Infrasturcture.Data
{
    public static class CatalogContextSeed
    {
        public static void SendData(IMongoCollection<Product> mongoCollection)
        {
            var existingProduct = mongoCollection.Find(_ => true).Any();
            if(!existingProduct)
            {
                mongoCollection.InsertManyAsync(InsertProducts());
            }
        }
        private static List<Product> InsertProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "1",
                    Name = "Nokia",
                    Type = CatalogType.Mobile,
                    Detail = "Nokia Moblie Phone",
                    Colors = new List<string>()
                    {
                        "Red",
                        "Green"
                    },
                    Quitity = 100,
                    Price = 2000,
                    Delivers = new List<string>()
                    {
                        "Free"
                    }
                },
                new Product()
                {
                    Id = "2",
                    Name = "IPhone",
                    Type = CatalogType.Mobile,
                    Detail = "IPhone X20 Moblie Phone",
                    Colors = new List<string>()
                    {
                        "Red",
                        "Green",
                        "Blue"
                    },
                    Quitity = 100,
                    Price = 20000,
                    Delivers = new List<string>()
                    {
                        "No Free"
                    }
                }
            };
        }
    }
}
