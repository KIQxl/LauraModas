﻿using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface IBuyServices
    {

        public Task<List<ReadBuyDto>> GetBuys();
        public Task<ReadBuyDto> GetBuy(int id);
        public Task<BuyModel> GetBuyModelForId(int id); 
        public Task<List<ReadBuyDto>> GetBuysByCustomerName(string name);
        public Task<ReadBuyDto> PostBuy(CreateBuyDto request);
        public Task<ReadBuyDto> AlterBuy(int id, AlterBuyDto request);
        public Task<ReadBuyDto> ParcelBuy(ParcelBuyDto request);
        public Task<ReadBuyDto> PayBuy(int id);
        public Task<List<ReadBuyDto>> GetBuyByDateRange(GetBuyByDateRangeDto dateRange);
        public Task<bool> DeleteBuy(int id);
    }
}
