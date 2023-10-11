using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Models.Enums;

namespace LauraModasAPI.Dtos.BuyDtos
{
    public class ReadBuyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public int NumberOfInstallments { get; set; }
        public double InstallmentValue { get; set; }
        public double RemainingValue { get; set; }
        public DateTime Date { get; set; }
        public int CustomerModelId { get; set; }
        public virtual ReadCustomerDtoForBuy CustomerModel { get; set; }
    }
}
