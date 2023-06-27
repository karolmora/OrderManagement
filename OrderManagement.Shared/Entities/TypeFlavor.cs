using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class TypeFlavor
    {
        public int Id { get; set; }
        public string Description { get; set; } = null;

        public int TypeProductId { get; set; }
        //Muchos sabores pertenecen a un solo tipo de producto
        public TypeProduct? TypeProduct { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
