using LauraModasAPI.Data;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LauraModasAPI.Services
{
    public class CustomerServices : ICustomerServices
    {
        readonly DataContext _context;
        public CustomerServices(DataContext context)
        {
            this._context = context;
        }

        public async Task<CustomerModel> GetCustomer(int id)
        {
            try
            {
                CustomerModel customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(id));

                if (customer != null)
                {
                    return customer;
                } else
                {
                    throw new Exception("Cliente não encontrado.");
                }
                

            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            
        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
            try
            {
                List<CustomerModel> customers = await _context.Customers.ToListAsync();

                if (customers.Count != 0)
                {
                    return customers;
                } else
                {
                    throw new Exception("Sua lista de clientes está vazia.");
                }
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<CustomerModel> PostCustomer(CustomerModel customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);

                await _context.SaveChangesAsync();

                return customer;
            } catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<CustomerModel> AlterCustomer(int id, CustomerModel customer)
        {
            try
            {
                CustomerModel customerDB = await GetCustomer(id);

                if (customerDB != null)
                {
                    customerDB.Name = customer.Name;
                    customerDB.Phone = customer.Phone;

                    await _context.SaveChangesAsync();

                    return customerDB;
                }
                else
                {
                    throw new Exception("Cliente não encontrado.");
                }
            } catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            try
            {
                CustomerModel customerDB = await GetCustomer(id);

                if (customerDB != null)
                {
                    _context.Customers.Remove(customerDB);
                    _context.SaveChanges();

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
    }
}
