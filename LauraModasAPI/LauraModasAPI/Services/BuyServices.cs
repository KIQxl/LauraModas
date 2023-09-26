using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class BuyServices : IBuyServices
    {
        readonly DataContext _context;
        readonly IMapper _mapper;
        IInstallmentServices _installmentServices;
        public BuyServices(DataContext context, IMapper mapper, IInstallmentServices installmentServices)
        {
            this._context = context;
            this._mapper = mapper;
            this._installmentServices = installmentServices;
        }
        public async Task<List<ReadBuyDto>> GetBuys()
        {
                List<BuyModel> buys = await _context.Buys.ToListAsync();

                List<ReadBuyDto> buysView = _mapper.Map<List<ReadBuyDto>>(buys);

                return buysView;           
        }
        public async Task<ReadBuyDto> GetBuy(int id)
        {
                BuyModel buy = await _context.Buys.FirstOrDefaultAsync(b => b.Id.Equals(id));

                ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

                return buyView;            
        }

        public async Task<BuyModel> GetBuyModelForId(int id)
        {           
                BuyModel buy = _context.Buys.FirstOrDefault(b => b.Id.Equals(id));
                
                return buy;
        }

        public async Task<List<ReadBuyDto>> GetBuysByName(string name)
        {
                List<BuyModel> buys = _context.Buys.Where(b => b.Name.ToUpper().Contains(name.ToUpper())).ToList();

                List<ReadBuyDto> buysViews = _mapper.Map<List<ReadBuyDto>>(buys);

                return buysViews;
        }


        public async Task<ReadBuyDto> PostBuy(CreateBuyDto request)
        {
                BuyModel buy = _mapper.Map<BuyModel>(request);

                _context.Buys.Add(buy);

                InstallmentModel installment = await _installmentServices.GetInstallment(request.CustomerModelId);

                installment.TotalValue += request.Value;
                installment.RemainingValue += request.Value;

                await _context.SaveChangesAsync();

                await _installmentServices.Parcel(new CreateInstallment
                {
                    CustomerId = request.CustomerModelId,
                    NumberOfInstallments = 1
                });

                ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

                return buyView;

        }

        public async Task<ReadBuyDto> AlterBuy(int id, AlterBuyDto request)
        {
            BuyModel buy = await GetBuyModelForId(id);

            buy.Name = request.Name;
            buy.Name = request.Name;
            buy.Description = request.Description;

            await _context.SaveChangesAsync();

            ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

            return buyView;
        }

        public async Task<bool> DeleteBuy(int id)
        {
            BuyModel buyDb = await GetBuyModelForId(id);
            InstallmentModel installment = await _installmentServices.GetInstallment(buyDb.CustomerModelId);
            installment.TotalValue -= buyDb.Value;
            installment.RemainingValue -= buyDb.Value;

            _context.Remove(buyDb);
            await _context.SaveChangesAsync();

            await _installmentServices.Parcel(new CreateInstallment
            {
                CustomerId = buyDb.CustomerModelId,
                NumberOfInstallments = 1
            });

            return true;
        }


    }
}
