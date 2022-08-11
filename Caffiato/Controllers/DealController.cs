using Caffiato.Dtos.DealDtos;
using Caffiato.Services.DealService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffiato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService dealService;

        public DealController(IDealService dealService)
        {
            this.dealService = dealService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetDealDto>>> GetDealById(int id)
        {
            return Ok(await dealService.GetDealById(id));
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetDealDto>>>> GetDeals()
        {
            return Ok(await dealService.GetDeals());
        }

        [HttpPost("/caffebar/api/Deals")]
        public async Task<ActionResult<ServiceResponse<List<GetDealDto>>>> AddDeal(AddDealDto deal)
        {
            return Ok(await dealService.AddDeal(deal));
        }

        [HttpPut("/caffebar/api/Deals/{id}")]
        public async Task<ActionResult<ServiceResponse<GetDealDto>>> UpdateDeal(UpdateDealDto updatedDeal)
        {
            var response = await dealService.UpdateDeal(updatedDeal);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateActivity/{id}")]
        public async Task<ActionResult<ServiceResponse<GetDealDto>>> UpdateDealActivity(UpdateDealActivityDto updatedDeal)
        {
            var response = await dealService.UpdateDealActivity(updatedDeal);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("/caffebar/api/Deals/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetDealDto>>>> DeleteDeal(int id)
        {
            var response = await dealService.DeleteDeal(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
