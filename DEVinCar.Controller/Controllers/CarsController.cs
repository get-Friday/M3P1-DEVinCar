using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/car")]
[Authorize(Roles = "Gerente")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMemoryCache _memoryCache;

    public CarController(ICarService carService, IMemoryCache memoryCache)
    {
        _carService = carService;
        _memoryCache = memoryCache;
    }

    [HttpGet("{carId}")]
    public ActionResult<CarDTO> GetById(
        [FromRoute] int carId
    )
    {
        if (!_memoryCache.TryGetValue($"car:{carId}", out CarDTO car))
        {
            car = _carService.GetById(carId);
            _memoryCache.Set($"car:{carId}", car, new TimeSpan(0, 5, 0));
        }

        return Ok(car);
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
        _memoryCache.Remove($"car:{carId}");
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
        _memoryCache.Set($"car:{carId}", carDto, new TimeSpan(0, 5, 0));
        return NoContent();
    }
}
