using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Entities
{
    public class CartItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quitity { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Delivers { get; set; }

    }
}
