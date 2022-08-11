using Caffiato.Dtos.AddressDtos;
using Caffiato.Services.AddressService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffiato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> GetAddressById(int id)
        {
            return Ok(await addressService.GetAddressById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAddressDto>>>> AddAddress(AddAddressDto address)
        {
            return Ok(await addressService.AddAddress(address));
        }

        [HttpPut("/caffebar/api/Addresses/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAddressDto>>> UpdateAddress(UpdateAddressDto updatedAddress)
        {
            var response = await addressService.UpdateAddress(updatedAddress);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAddressDto>>>> DeleteAddress(int id)
        {
            var response = await addressService.DeleteAddress(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
