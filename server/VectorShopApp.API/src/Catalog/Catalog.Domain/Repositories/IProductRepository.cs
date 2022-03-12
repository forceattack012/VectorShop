using Catalog.Domain.Repositories.Base;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product> 
    {
        Task<List<Product>> GetProductByName(string name);
    }
}
