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
        public double Value { get; set; }
        // FK de flavor
        public int TypeFlavorId { get; set; }
        public TypeFlavor? TypeFlavor { get; set; }
        public ICollection<Order> Order { get; set;}
    }
}
