using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<UserDTO>> Get(
       [FromQuery] string name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin
    )
    {
        return Ok(_userService.Get(name, birthDateMax, birthDateMin));
    }

    [HttpGet("{id}")]
    public ActionResult<UserDTO> GetById(
        [FromRoute] int id
    )
    {
        return Ok(_userService.GetById(id));
    }
    
    [HttpPost]
    public ActionResult Post(
        [FromBody] UserDTO userDto
    )
    {
        _userService.Post(userDto);
        return Created("api/user", userDto.Id);
    }

    [HttpDelete("{userId}")]
    public ActionResult Delete(
        [FromRoute] int userId
    )
    {
        _userService.Delete(userId);
        return NoContent();
    }
}
