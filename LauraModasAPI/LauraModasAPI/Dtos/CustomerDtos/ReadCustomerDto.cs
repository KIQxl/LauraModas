using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Dtos.CustomerDtos
{
    public class ReadCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Amount { get; set; }
        public ICollection<ReadBuyDtoForCustomer> Buys { get; set; }
    }
}
