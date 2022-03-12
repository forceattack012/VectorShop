﻿using Catalog.Application.DTOs;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
