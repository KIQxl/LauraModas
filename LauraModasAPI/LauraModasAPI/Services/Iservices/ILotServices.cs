using LauraModasAPI.Dtos.LotDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface ILotServices
    {
        public Task<List<LotModel>> GetLots();
        public Task<bool> CreateLot(CreateLotDto request);
    }
}
