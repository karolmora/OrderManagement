using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        //Un solo tipo de producto pertenecen a muchos sabores 
        public ICollection<TypeFlavor>? TypeFlavors { get; set; }
    }
}
