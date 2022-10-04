using DEVinCar.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public IActionResult Login(
            [FromBody] LoginDTO body
        )
        {
            throw new NotImplementedException();
        }
    }
}
