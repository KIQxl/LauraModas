using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class InstallmentServices : IInstallmentServices
    {
        public readonly DataContext _context;
        public readonly ICustomerServices _customerServices;
        public readonly IMapper _mapper;

        public InstallmentServices(DataContext context, ICustomerServices customerServices, IMapper mapper)
        {
            this._context = context;
            this._customerServices = customerServices;
            this._mapper = mapper;
        }

        public async Task<ReadInstallment> Parcel(CreateInstallment request)
        {
            InstallmentModel installment = await GetInstallment(request.CustomerId);

            CustomerModel customer = await _customerServices.GetCustomerModelForId(request.CustomerId);

            double totalValue = _customerServices.GetAmount(customer);

            double newInstallmentValue = installment.RemainingValue / request.NumberOfInstallments;

            installment.TotalValue = totalValue;
            installment.NumberOfInstallments = request.NumberOfInstallments;
            installment.CustomerName = customer.Name;
            installment.InstallmentValue = newInstallmentValue;

            await _context.SaveChangesAsync();

            ReadInstallment installmentView = _mapper.Map<ReadInstallment>(installment);

            return installmentView;

        }

        public async Task<InstallmentModel> GetInstallment(int id)
        {
            InstallmentModel installment = await _context.Installments.FirstOrDefaultAsync(i => i.CustomerId == id);

            return installment;
        }

        public async Task<ReadInstallment> PayInstallment(int id)
        {
            CustomerModel customer = await _customerServices.GetCustomerModelForId(id);

            if (customer == null)
            {
                throw new Exception("Cliente não encontrado");
            }

            InstallmentModel installment = await GetInstallment(id);

            if (installment.NumberOfInstallments <= 0 || installment.RemainingValue <= 0)
            {
                installment.RemainingValue = 0;
                installment.InstallmentValue = 0;
                installment.NumberOfInstallments = 0;
                await _context.SaveChangesAsync();

                ReadInstallment installmentPaid = _mapper.Map<ReadInstallment>(installment);

                return installmentPaid;
            }

            installment.NumberOfInstallments -= 1;
            installment.RemainingValue -= installment.InstallmentValue;

            await _context.SaveChangesAsync();

            ReadInstallment installmentView = _mapper.Map<ReadInstallment>(installment);

            return installmentView;
        }

        public async Task<ReadInstallment> GetInstallmentForId(int id)
        {

            InstallmentModel installment = await GetInstallment(id);

            ReadInstallment installmentView = _mapper.Map<ReadInstallment>(installment);

            return installmentView;            
        }
    }
}
