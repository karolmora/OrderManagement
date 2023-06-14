using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CellPhone { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
