using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class CustomerServices : ICustomerServices
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        public CustomerServices(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ReadCustomerDto> GetCustomer(int id)
        {
            CustomerModel customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
            ReadCustomerDto customerView = _mapper.Map<ReadCustomerDto>(customer);

            return customerView;
        }

        public async Task<CustomerModel> GetCustomerModelForId(int id)
        {
            CustomerModel customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return customer;
        }

        public async Task<List<ReadCustomerDto>> GetCustomers()
        {
            List<CustomerModel> customers = await _context.Customers.ToListAsync();
            List<ReadCustomerDto> customersView = _mapper.Map<List<ReadCustomerDto>>(customers);
 
            return customersView;
        }

        public async Task<List<ReadCustomerDto>> GetCustomerByName(string name)
        {
            List<CustomerModel> customers = _context.Customers.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();
            List<ReadCustomerDto> customersView = _mapper.Map<List<ReadCustomerDto>>(customers);

            return customersView;
        }

        public async Task<ReadCustomerDto> PostCustomer(CreateCustomerDto request)
        {
           
            CustomerModel customer = _mapper.Map<CustomerModel>(request);
            InstallmentModel installment = new InstallmentModel
            {
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                TotalValue = 0,
                NumberOfInstallments = 0,
                InstallmentValue = 0,
                RemainingValue = 0,
            };

            customer.Installment = installment;

            await _context.Installments.AddAsync(installment);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            ReadCustomerDto customerView = _mapper.Map<ReadCustomerDto>(customer);

            return customerView;
        }

        public async Task<ReadCustomerDto> AlterCustomer(int id, AlterCustomerDto request)
        {
            CustomerModel customerDb = await GetCustomerModelForId(id);

            customerDb.Name = request.Name;
            customerDb.Phone = request.Phone;

            await _context.SaveChangesAsync();

            ReadCustomerDto customerView = _mapper.Map<ReadCustomerDto>(customerDb);

            return customerView;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            CustomerModel customerDB = await GetCustomerModelForId(id);
            _context.Customers.Remove(customerDB);
            await _context.SaveChangesAsync();

            return true;
        }

        public double GetAmount(CustomerModel customer)
        {
            double amount = 0;

            foreach(var buy in customer.BuysModel)
            {
                amount += buy.Value;
            }

            return amount;
        }
    }
}
