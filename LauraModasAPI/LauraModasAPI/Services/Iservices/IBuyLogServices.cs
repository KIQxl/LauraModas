using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface IBuyLogServices
    {
        public Task<List<BuyLogModel>> GetLogs();
        public Task<List<BuyLogModel>> GetLogsByDataRange(GetBuyByDateRangeDto dateRange);
    }
}
