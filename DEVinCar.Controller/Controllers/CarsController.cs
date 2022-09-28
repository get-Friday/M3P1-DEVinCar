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
        var query = _carService.Get().AsQueryable();

        if (!string.IsNullOrEmpty(name))
            query = query.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));
        
        if (priceMin > priceMax)
            return BadRequest();
        
        if (priceMin.HasValue)
            query = query.Where(c => c.SuggestedPrice >= priceMin);
        
        if (priceMax.HasValue)
            query = query.Where(c => c.SuggestedPrice <= priceMax);
        
        if (!query.ToList().Any())
            return NoContent();
        
        return Ok(query.ToList());
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
