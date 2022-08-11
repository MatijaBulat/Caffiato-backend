using Caffiato.Dtos.AddressDtos;

namespace Caffiato.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<GetAddressDto>> GetAddressById(int id);
        Task<ServiceResponse<GetAddressDto>> AddAddress(AddAddressDto address);
        Task<ServiceResponse<GetAddressDto>> UpdateAddress(UpdateAddressDto updatedAddress);
        Task<ServiceResponse<List<GetAddressDto>>> DeleteAddress(int id);
    }
}
