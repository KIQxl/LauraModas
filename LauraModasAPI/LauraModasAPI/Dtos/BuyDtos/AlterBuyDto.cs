using LauraModasAPI.Models.Enums;

namespace LauraModasAPI.Dtos.BuyDtos
{
    public class AlterBuyDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public PurchaseEnum? Status { get; set; }
    }
}
