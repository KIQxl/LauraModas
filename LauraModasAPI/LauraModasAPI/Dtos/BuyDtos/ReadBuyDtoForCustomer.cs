using LauraModasAPI.Models.Enums;

namespace LauraModasAPI.Dtos.BuyDtos
{
    public class ReadBuyDtoForCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public PurchaseEnum? Status { get; set; }

        public DateTime Date { get; set; }
        public int CustomerModelId { get; set; }
    }
}
