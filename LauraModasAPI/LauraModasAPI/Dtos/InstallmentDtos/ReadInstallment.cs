using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Dtos.InstallmentDtos
{
    public class ReadInstallment
    {
        public int CustomerId { get; set; }
        public int NumberOfInstallments { get; set; }
        public double TotalValue { get; set; }
        public double InstallmentValue { get; set; }
        public double RemainingValue { get; set; }
        public DateOnly DateOfPayment { get; set; }
        public virtual ReadCustomerDtoForBuy Customer { get; set; }
    }
}
