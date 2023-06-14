using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public double ValueProduct { get; set; }
        public string Flavor { get; set; }
        public string Description { get; set; }
        public int TypeProductId { get; set; }
        public int OrderId { get; set; }
        public TypeProduct? TypeProduct { get; set; }
        public Order? Order { get; set; }

    }
}
