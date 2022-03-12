using Catalog.Application.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public string Id { get; set; }

        public GetProductByIdQuery(string id) => Id = id;
    }
}
