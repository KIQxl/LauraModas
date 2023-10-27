using AutoMapper;
using LauraModasAPI.Data;
using LauraModasAPI.Dtos.LotDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class LotServices : ILotServices
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public LotServices(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<LotModel>> GetLots()
        {
            List<LotModel> lots = await _context.Lots.ToListAsync();

            return lots;
        }

        public async Task<bool> CreateLot(CreateLotDto request)
        {
            LotModel lot = _mapper.Map<LotModel>(request);

            lot.AmountValue = lot.Value * lot.Quantity;

            await _context.Lots.AddAsync(lot);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
