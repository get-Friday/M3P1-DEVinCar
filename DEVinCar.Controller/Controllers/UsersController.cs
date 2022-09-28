using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<UserDTO>> Get(
       [FromQuery] string Name,
       [FromQuery] DateTime? birthDateMax,
       [FromQuery] DateTime? birthDateMin
    )
    {
        var query = _userService.Get().AsQueryable();

        if (!string.IsNullOrEmpty(Name))
            query = query.Where(c => c.Name.Contains(Name));

        if (birthDateMin.HasValue)
            query = query.Where(c => c.BirthDate >= birthDateMin.Value);

        if (birthDateMax.HasValue)
            query = query.Where(c => c.BirthDate <= birthDateMax.Value);

        if (!query.Any())
            return NoContent();

        return Ok(query);
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
