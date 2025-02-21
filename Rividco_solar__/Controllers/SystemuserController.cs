using Microsoft.AspNetCore.Mvc;
using Rividco_solar__.Models;
using Rividco_solar__.Services;

namespace Rividco_solar__.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemuserController : ControllerBase
    {
        private readonly ISystemuserServices systemuserServices;

        public SystemuserController(ISystemuserServices authService)
        {
            systemuserServices = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SystemuserDTO request)
        {
            var result = await systemuserServices.RegisterUser(request);
            if (result == "User registered successfully")
                return Ok(new { message = result });

            return BadRequest(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var token = await systemuserServices.LoginUser(request);
            if (token == "Invalid credentials")
                return Unauthorized(new { message = token });

            return Ok(new { token });
        }
        [HttpGet]
        public async Task<IActionResult> Getall( int page=1,int pagesize=10)
        {
            var (systemuser,TotalCount)= await systemuserServices.GetAllAsync(page,pagesize);
            var response = new
            {
                data = systemuser,
                totalItems = TotalCount,
                totalPages = (int)Math.Ceiling((double)TotalCount / pagesize),
                currentPage = page
            };

            return Ok(response);
           
        }
    }
}
