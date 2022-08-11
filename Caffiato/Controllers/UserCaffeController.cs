using AutoMapper;
using Caffiato.Dtos.UserCaffeDtos;
using Caffiato.Services.UserCaffeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffiato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCaffeController : ControllerBase
    {
        private readonly IUserCaffeService userCaffeService;

        public UserCaffeController(IUserCaffeService userCaffeService)
        {
            this.userCaffeService = userCaffeService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetUserCaffeDto>>> GetUserCaffeById(int id)
        {
            return Ok(await userCaffeService.GetUserCaffeById(id));
        }

        [HttpGet("{email:regex(^([[0-9a-zA-Z]]([[-\\.\\w]]*[[0-9a-zA-Z]])*@([[0-9a-zA-Z]][[-\\w]]*[[0-9a-zA-Z]]\\.)+[[a-zA-Z]]{{2,9}})$)}")]
        public async Task<ActionResult<ServiceResponse<GetUserCaffeDto>>> GetUserCaffeByEmail(string email)
        {           
            return Ok(await userCaffeService.GetUserCaffeByEmail(email));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserCaffeDto>>> AddUserCaffe(AddUserCaffeDto user)
        {
            return Ok(await userCaffeService.AddUserCaffe(user));
        }

    }
}
