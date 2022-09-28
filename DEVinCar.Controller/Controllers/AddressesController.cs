using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public ActionResult<List<AddressViewModel>> Get(
        [FromQuery] int? cityId,
        [FromQuery] int? stateId,
        [FromQuery] string street,
        [FromQuery] string cep
    )
    {
        var query = _addressService.Get().AsQueryable();

        if (cityId.HasValue)
            query = query.Where(a => a.CityId == cityId);
        
        // if (stateId.HasValue)
        //     query = query.Where(a => a.City.StateId == stateId);

        if (!string.IsNullOrEmpty(street))
            query = query.Where(a => a.Street.ToUpper().Contains(street.ToUpper()));

        if (!string.IsNullOrEmpty(cep))
            query = query.Where(a => a.Cep == cep);

        if (!query.ToList().Any())
            return NoContent();

        return Ok(query);
    }

    [HttpPatch("{addressId}")]
    public ActionResult<AddressViewModel> Patch(
        [FromRoute] int addressId,
        [FromBody] AddressPatchDTO addressPatchDTO
    )
    {
        _addressService.Alter(addressPatchDTO);
        return NoContent();
    }

    [HttpDelete("{addressId}")]

    public ActionResult Delete(
        [FromRoute] int addressId
    )
    {
        _addressService.Delete(addressId);
        return NoContent();
    }
}
