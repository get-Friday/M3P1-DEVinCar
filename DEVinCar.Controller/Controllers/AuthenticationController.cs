using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace DEVinCar.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthenticationController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult UserLogin(
            [FromBody] LoginDTO body
        )
        {
            var user = _userService.Login(body.Email, body.Password);
            var token = _tokenService.GenerateTokenFromUser(user);
            return Ok(new { token });
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Gerente")]
        public IActionResult Register(
            [FromBody] UserDTO body
        )
        {
            _userService.Post(body);
            return Created("register", body);
        }
    }
}
