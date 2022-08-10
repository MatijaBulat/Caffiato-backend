using Caffiato.Dtos.CaffeDtos;
using Caffiato.Services.CaffeServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffiato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaffeController : ControllerBase
    {
        private readonly ICaffeService caffeService;

        public CaffeController(ICaffeService caffeService)
        {
            this.caffeService = caffeService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetCaffeDto>>> GetCaffeById(int id)
        {
            return Ok(await caffeService.GetCaffeById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCaffeDto>>>> AddCaffe(AddCaffeDto caffe)
        {
            return Ok(await caffeService.AddCaffe(caffe));
        }

        [HttpDelete("/caffebar/api/Caffes/{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCaffeDto>>>> DeleteCaffe(int id)
        {
            var response = await caffeService.DeleteCaffe(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("/caffebar/api/Caffes/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCaffeDto>>> UpdateCaffe(UpdateCaffeDto updatedCaffe)
        {
            var response = await caffeService.UpdateCaffe(updatedCaffe);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
