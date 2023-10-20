using LauraModasAPI.Data;
using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;
using LauraModasAPI.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace LauraModasAPI.Services
{
    public class BuyLogServices : IBuyLogServices
    {

        public readonly DataContext _context;
        public BuyLogServices(DataContext context) 
        {
            this._context = context;
        }

        public async Task<List<BuyLogModel>> GetLogs()
        {
            List<BuyLogModel> logs = await _context.BuyLogs.ToListAsync();

            return logs;
        }

        public async Task<List<BuyLogModel>> GetLogsByDataRange(GetBuyByDateRangeDto dateRange)
        {
            List<BuyLogModel> logs = await _context.BuyLogs.Where(l => l.DateOfPayment >= dateRange.InitialDate 
                && l.DateOfPayment <= dateRange.FinalDate)
                    .ToListAsync();

            return logs;
        }
    }
}
