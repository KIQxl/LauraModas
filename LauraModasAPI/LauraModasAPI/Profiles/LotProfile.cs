using AutoMapper;
using LauraModasAPI.Dtos.LotDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Profiles
{
    public class LotProfile : Profile
    {
        public LotProfile()
        {
            CreateMap<CreateLotDto, LotModel>();
            CreateMap<LotModel, CreateLotDto>();
        }
    }
}
