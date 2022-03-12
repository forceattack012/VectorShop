using Catalog.Domain.Entities;

namespace Catalog.Application.DTOs
{
    public class ProductDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Quitity { get; set; }
        public decimal Price { get; set; }
        public List<string>? Colors { get; set; }
        public List<string>? Delivers { get; set; }
        public byte[]? Image { get; set; }

        public ProductDTO(Product product) => (Id, Name, Quitity, Price, Colors, Delivers, Image) = 
            (product.Id, product.Name, product.Quitity, product.Price, product.Colors, product.Delivers, product.Image);
    }
}
