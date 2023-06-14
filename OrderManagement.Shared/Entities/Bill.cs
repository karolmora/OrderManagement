using OrderManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime DateBill { get; set; }
        public double Total{ get; set; }
        public double Pass { get; set; }
        public int PaymentTypeId { get; set; }
        public StatusBill? Status { get; set; }
        public PaymentType? PaymentType { get; set; }
        public ICollection<Order> Order{ get; set; }

    }
}
