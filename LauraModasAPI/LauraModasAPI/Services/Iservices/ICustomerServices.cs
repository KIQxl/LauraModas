using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface ICustomerServices
    {
        public Task<List<CustomerModel>> GetCustomers();
        public Task<CustomerModel> GetCustomer(int id);
        public Task<CustomerModel> PostCustomer(CustomerModel customer);
        public Task<CustomerModel> AlterCustomer(int id, CustomerModel customer);
        public Task<bool> DeleteCustomer(int id);
    }
}
