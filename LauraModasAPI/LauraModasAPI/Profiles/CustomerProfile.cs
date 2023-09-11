using AutoMapper;
using LauraModasAPI.Dtos.CustomerDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<CreateCustomerDto, CustomerModel>().ReverseMap();
            CreateMap<CustomerModel, ReadCustomerDto>().ForMember(dto => dto.Buys, opts => opts.MapFrom(customer => customer.BuysModel));
            CreateMap<CustomerModel, ReadCustomerDtoForBuy>();
            CreateMap<AlterCustomerDto, CustomerModel>();
        }
    }
}
