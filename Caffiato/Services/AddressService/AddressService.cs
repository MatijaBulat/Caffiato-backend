using AutoMapper;
using Caffiato.Dtos.AddressDtos;

namespace Caffiato.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly CaffiatoDBContext caffiatoDBContext;
        private readonly IMapper mapper;

        public AddressService(CaffiatoDBContext caffiatoDBContext, IMapper mapper)
        {
            this.caffiatoDBContext = caffiatoDBContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetAddressDto>> AddAddress(AddAddressDto address)
        {
            var serviceResponse = new ServiceResponse<GetAddressDto>();
            caffiatoDBContext.Addresses.Add(mapper.Map<Address>(address));
            await caffiatoDBContext.SaveChangesAsync();
            serviceResponse.Data = await caffiatoDBContext.Addresses
                .OrderBy(a => a.Id)
                .Select(a => mapper.Map<GetAddressDto>(a))
                .LastAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAddressDto>>> DeleteAddress(int id)
        {
            ServiceResponse<IEnumerable<GetAddressDto>> response = new ServiceResponse<IEnumerable<GetAddressDto>>();
            try
            {
                Address address = await caffiatoDBContext.Addresses.FirstOrDefaultAsync(a => a.Id == id);
                if (address != null)
                {
                    caffiatoDBContext.Addresses.Remove(address);
                    await caffiatoDBContext.SaveChangesAsync();
                    response.Data = caffiatoDBContext.Addresses.Select(a => mapper.Map<GetAddressDto>(a)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Address not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetAddressDto>> GetAddressById(int id)
        {
            var serviceResponse = new ServiceResponse<GetAddressDto>();
            var address = await caffiatoDBContext.Addresses.FindAsync(id);
            serviceResponse.Data = mapper.Map<GetAddressDto>(address);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAddressDto>> UpdateAddress(UpdateAddressDto updatedAddress)
        {
            ServiceResponse<GetAddressDto> response = new ServiceResponse<GetAddressDto>();

            try
            {
                var address = await caffiatoDBContext.Addresses.FirstOrDefaultAsync(a => a.Id == updatedAddress.Id);

                if (address != null)
                {
                    address.StreetNumber = updatedAddress.StreetNumber;
                    address.StreetName = updatedAddress.StreetName;
                    address.City = updatedAddress.City;
                    address.PostCode = updatedAddress.PostCode;

                    await caffiatoDBContext.SaveChangesAsync();

                    response.Data = mapper.Map<GetAddressDto>(address);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Address not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
