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
            try
            {
                CustomerModel customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));

                ReadCustomerDto customerView = _mapper.Map<ReadCustomerDto>(customer);

                if (customer != null)
                {
                    return customerView;
                } else
                {
                    throw new Exception("Cliente não encontrado.");
                }
                

            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            
        }

        public async Task<CustomerModel> GetCustomerModelForId(int id)
        {
            try
            {
                CustomerModel customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));

                if (customer == null)
                {
                    throw new Exception("Não encontrado");
                }

                return customer;
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<ReadCustomerDto>> GetCustomers()
        {
            try
            {
                List<CustomerModel> customers = await _context.Customers.ToListAsync();

                List<ReadCustomerDto> customersView = _mapper.Map<List<ReadCustomerDto>>(customers);

                if (customers.Count != 0)
                {
                    return customersView;
                } else
                {
                    throw new Exception("Sua lista de clientes está vazia.");
                }
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<ReadCustomerDto>> GetCustomerByName(string name)
        {
            try
            {
                List<CustomerModel> customers = _context.Customers.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();

                if(customers.Count == 0)
                {
                    throw new Exception("Houve um erro");
                }

                List<ReadCustomerDto> customersView = _mapper.Map<List<ReadCustomerDto>>(customers);

                return customersView;


            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<ReadCustomerDto> PostCustomer(CreateCustomerDto request)
        {
            try
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

            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<ReadCustomerDto> AlterCustomer(int id, AlterCustomerDto request)
        {
            try
            {
                CustomerModel customerDb = await GetCustomerModelForId(id);

                if (customerDb == null)
                {
                    throw new Exception("Cliente não encontrado.");
                }

                customerDb.Name = request.Name;
                customerDb.Phone = request.Phone;

                await _context.SaveChangesAsync();

                ReadCustomerDto customerView = _mapper.Map<ReadCustomerDto>(customerDb);

                return customerView;
            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                CustomerModel customerDB = await GetCustomerModelForId(id);

                if (customerDB != null)
                {
                    _context.Customers.Remove(customerDB);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new Exception("Cliente não encontrado");
                }
            } catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
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
