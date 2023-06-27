using OrderManagement.Shared.Enums;


namespace OrderManagement.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Flavor{ get; set; }
        public string Description { get; set; }
        public StatusOrder? Status { get; set; }
        public TypeOrder? Type { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Bill> Bill { get; set; }

    }
}
