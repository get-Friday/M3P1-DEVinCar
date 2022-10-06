using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/state")]
[Authorize]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;

    public StatesController(IStateService stateService)
    {
        _stateService = stateService;
    }

    [HttpPost("{stateId}/city")]
    public ActionResult<int> PostCity(
        [FromRoute] int stateId,
        [FromBody] CityDTO cityDTO
    )
    {
        cityDTO.StateId = stateId;
        _stateService.PostCity(cityDTO);
        return Created("api/{stateId}/city", cityDTO.Id);
    }

    [HttpPost("{stateId}/city/{cityId}/address")]
    public ActionResult<int> PostAdress(
        [FromRoute] int stateId,
        [FromRoute] int cityId,
        [FromBody] AddressDTO body
    )
    {
        body.CityId = cityId;
        _stateService.PostAddress(stateId, cityId, body);
        return Created($"api/state/{stateId}/city/{cityId}/", body.Id);
    }

    [HttpGet("{stateId}/city/{cityId}")]

    public ActionResult<GetCityByIdViewModel> GetCityById
    (
        [FromRoute] int stateId,
        [FromRoute] int cityId
    )
    {
        return Ok(_stateService.GetCityById(stateId, cityId));
    }

    [HttpGet("{stateId}")]
    public ActionResult<GetStateViewModel> GetStateById(
        [FromRoute] int stateId
    )
    {
        return Ok(_stateService.GetStateById(stateId));
    }

    [HttpGet]
    public ActionResult<List<GetStateViewModel>> Get(
        [FromQuery] string name
    ) 
    {
        return Ok(_stateService.Get(name));
    }

    [HttpGet("{stateId}/city")]
    public ActionResult<CityDTO> GetCityByStateId(
        [FromRoute] int stateId,
        [FromQuery] string? name
    )
    {
        return Ok(_stateService.GetCitiesByStateId(stateId, name));
    }

}

