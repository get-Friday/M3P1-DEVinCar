using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{carId}")]
    public ActionResult<CarDTO> GetById(
        [FromRoute] int carId
    )
    {
        return Ok(_carService.GetById(carId));
    }

    [HttpGet]
    public ActionResult<List<CarDTO>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax
    )
    {
        return Ok(_carService.Get(name, priceMin, priceMax));
    }

    [HttpPost]
    public ActionResult<CarDTO> Post(
        [FromBody] CarDTO body
    )
    {
        _carService.Post(body);
        return Created("api/car", body);
    }

    [HttpDelete("{carId}")]
    public ActionResult Delete(
        [FromRoute] int carId
    )
    {
        _carService.Delete(carId);
        return NoContent();
    }

    [HttpPut("{carId}")]
    public ActionResult Put(
        [FromBody] CarDTO carDto, 
        [FromRoute] int carId
    )
    {
        carDto.Id = carId;
        _carService.Alter(carDto);
        return NoContent();
    }
}
