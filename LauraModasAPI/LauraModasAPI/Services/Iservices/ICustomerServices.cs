using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface ICustomerServices
    {
        public Task<List<ReadCustomerDto>> GetCustomers();
        public Task<ReadCustomerDto> GetCustomer(int id);
        public Task<CustomerModel> GetCustomerModelForId(int id);
        public Task<List<ReadCustomerDto>> GetCustomerByName(string name); 
        public Task<ReadCustomerDto> PostCustomer(CreateCustomerDto customer);
        public Task<ReadCustomerDto> AlterCustomer(int id, AlterCustomerDto customer);
        public Task<bool> DeleteCustomer(int id);
        public double GetAmount(CustomerModel customer);
    }
}
