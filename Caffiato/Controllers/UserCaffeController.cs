using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caffiato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCaffeController : ControllerBase
    {
        private readonly CaffiatoDBContext caffiatoDBContext;

        public UserCaffeController(CaffiatoDBContext caffiatoDBContext)
        {
            this.caffiatoDBContext = caffiatoDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCaffe>>> GetUserCaffes()
        {
            return Ok(await caffiatoDBContext.UserCaffes.Include(u => u.Caffes).ToListAsync());
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<IEnumerable<UserCaffe>>> GetUserById(int id)
        //{

        //}
    }
}
