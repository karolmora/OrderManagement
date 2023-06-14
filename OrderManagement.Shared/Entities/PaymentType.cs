using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Bill> Bill { get; set; }
    }
}
