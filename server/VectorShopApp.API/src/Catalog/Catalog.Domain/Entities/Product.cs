

using Catalog.Domain.Enums;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Quitity { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public CatalogType Type { get; set; }
        public List<string>? Colors { get; set; }
        public List<string>? Delivers { get; set; }
        public byte[]? Image { get; set; }

    }
}
