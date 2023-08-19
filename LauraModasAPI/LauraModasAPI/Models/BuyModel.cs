using LauraModasAPI.Models.Enums;

namespace LauraModasAPI.Models
{
    public class BuyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public PurchaseEnum? Status { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}
