using LauraModasAPI.Dtos.InstallmentDtos;
using LauraModasAPI.Models;

namespace LauraModasAPI.Services.Iservices
{
    public interface IInstallmentServices
    {
        public Task<ReadInstallment> Parcel(CreateInstallment request);
        public Task<InstallmentModel> GetInstallment(int id);
        public Task<ReadInstallment> PayInstallment(int id);
        public Task<ReadInstallment> GetReadInstallment(int id);
    }
}
