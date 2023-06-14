using OrderManagement.Shared.Enums;


namespace OrderManagement.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public StatusOrder? Status { get; set; }
        public TypeOrder? Type { get; set; }
        public int CustomerId { get; set; }
        public int BillId { get; set; }
        public Customer? Customer { get; set; }
        public Bill? Bill { get; set; }
        public ICollection<Product>? Product { get; set; }
    }
}
