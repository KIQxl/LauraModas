using AutoMapper;
using LauraModasAPI.Dtos.BuyDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Profiles
{
    public class BuyProfile : Profile
    {
        public BuyProfile() 
        {
            CreateMap<CreateBuyDto, BuyModel>();
            CreateMap<BuyModel, ReadBuyDto>()
                .ForMember(dto => dto.CustomerModel, opts => opts.MapFrom(buy => buy.CustomerModel));
            CreateMap<AlterBuyDto, BuyModel>();
            CreateMap<BuyModel, ReadBuyDtoForCustomer>();
        }

    }
}
