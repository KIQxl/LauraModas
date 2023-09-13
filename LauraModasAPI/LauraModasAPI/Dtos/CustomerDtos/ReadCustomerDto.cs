using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Dtos.CustomerDtos
{
    public class ReadCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<ReadBuyDtoForCustomer> Buys { get; set; }
        public ReadInstallment Installment { get; set; }
    }
}
