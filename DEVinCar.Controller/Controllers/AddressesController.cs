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
        return Ok(_addressService.Get(cityId, stateId, street, cep));
    }

    [HttpPatch("{addressId}")]
    public ActionResult<AddressViewModel> Patch(
        [FromRoute] int addressId,
        [FromBody] AddressPatchDTO addressPatchDTO
    )
    {
        addressPatchDTO.Id = addressId;
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
