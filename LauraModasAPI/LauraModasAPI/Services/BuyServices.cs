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
        public BuyServices(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
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

            buy.InstallmentValue = request.Value / request.NumberOfInstallments;
            buy.RemainingValue = request.Value;

            await _context.Buys.AddAsync(buy);
            await _context.SaveChangesAsync();

            ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

            return buyView;
        }

        public async Task<ReadBuyDto> AlterBuy(int id, AlterBuyDto request)
        {
            BuyModel buy = await GetBuyModelForId(id);

            buy.Name = request.Name;
            buy.Description = request.Description;
            buy.DateOfPayment = request.DateOfPayment;

            await _context.SaveChangesAsync();

            ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

            return buyView;
        }

        public async Task<bool> DeleteBuy(int id)
        {
            BuyModel buyDb = await GetBuyModelForId(id);

            _context.Remove(buyDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ReadBuyDto> ParcelBuy(ParcelBuyDto request)
        {
            BuyModel buy = await GetBuyModelForId(request.Id);

            buy.NumberOfInstallments = request.NumberOfInstallments;
            buy.InstallmentValue = buy.RemainingValue / request.NumberOfInstallments;
            buy.DateOfPayment = request.DateOfPayment;

            await _context.SaveChangesAsync();

            ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);
            return buyView;
        }

        public async Task<ReadBuyDto> PayBuy(int id)
        {
            BuyModel buy = await GetBuyModelForId(id);

            buy.RemainingValue -= buy.InstallmentValue;
            buy.NumberOfInstallments -= 1;

            await _context.SaveChangesAsync();

            if (buy.NumberOfInstallments <= 0)
            {
                buy.InstallmentValue = 0;
                buy.RemainingValue = 0;
                buy.NumberOfInstallments = 0;

                await _context.SaveChangesAsync();
            }

            ReadBuyDto buyView = _mapper.Map<ReadBuyDto>(buy);

            return buyView;
        }

        public async Task<List<ReadBuyDto>> GetBuyByDateRange(GetBuyByDateRangeDto dateRange)
        {
            List<BuyModel> buys = await _context.Buys.Where(x => x.DateOfPayment >= dateRange.InitialDate 
                && x.DateOfPayment <= dateRange.FinalDate)
                    .ToListAsync();

            List<ReadBuyDto> buysView = _mapper.Map<List<ReadBuyDto>>(buys);

            return buysView;
        }
    }
}
