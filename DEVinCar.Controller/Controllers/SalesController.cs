using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleService _saleService;
    public SalesController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet("{saleId}")]
    public ActionResult<SaleViewModel> GetItensSale(
        [FromRoute] int saleId
    )
    {
        return Ok(_saleService.GetItemsSale(saleId));
    }

    [HttpPost("{saleId}/item")]
    public ActionResult<SaleCarDTO> PostSale(
       [FromBody] SaleCarDTO body,
       [FromRoute] int saleId
    )
    {
        body.SaleId = saleId;
        body.UnitPrice ??= _saleService.GetSuggestedPrice(body.CarId);
        body.Amount ??= 1;
        _saleService.PostSale(body);
        return Created("api/sales/{saleId}/item", body.CarId);
    }

    [HttpPost("{saleId}/deliver")]
    public ActionResult<DeliveryDTO> PostDeliver(
        [FromRoute] int saleId,
        [FromBody] DeliveryDTO body
    )
    {
        body.SaleId = saleId;
        if (body.DeliveryForecast == null)
            body.DeliveryForecast = DateTime.Now.AddDays(7);

        _saleService.PostDelivery(body);
        return Created("{saleId}/deliver", body.Id);
    }

    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]
    public ActionResult PatchCarAmount(
            [FromRoute] int saleId,
            [FromRoute] int carId,
            [FromRoute] int amount
            )
    {
        SaleCarDTO sale = _saleService.GetSoldCar(saleId);
        sale.Amount = amount;
        sale.CarId = carId;
        _saleService.Alter(sale);
        return NoContent();
    }

    [HttpPatch("{saleId}/car/{carId}/price/{unitPrice}")]
    public ActionResult PatchUnitPrice(
           [FromRoute] int saleId,
           [FromRoute] int carId,
           [FromRoute] decimal unitPrice
           )
    {
        SaleCarDTO sale = _saleService.GetSoldCar(saleId);
        sale.UnitPrice = unitPrice;
        sale.CarId = carId;
        _saleService.Alter(sale);
        return NoContent();
    }

}

