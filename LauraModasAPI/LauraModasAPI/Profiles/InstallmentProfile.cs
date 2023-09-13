using AutoMapper;
using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Profiles
{
    public class InstallmentProfile : Profile
    {
        public InstallmentProfile() 
        { 
            CreateMap<InstallmentModel, ReadInstallment>();
            CreateMap<ReadInstallment, InstallmentModel>();
        }
    }
}
