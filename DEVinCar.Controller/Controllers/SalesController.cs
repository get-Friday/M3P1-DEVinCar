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

    [HttpGet]
    [Route("api/user/{userId}/buy")]
    public ActionResult<SaleDTO> GetSalesByUserId(
       [FromRoute] int userId
    )
    {
        return Ok(_saleService.GetSalesByUserId(userId));
    }

    [HttpGet]
    [Route("api/user/{userId}/sales")]
    public ActionResult<SaleDTO> GetSalesBySellerId(
       [FromRoute] int userId)
    {
        return Ok(_saleService.GetSalesBySellerId(userId));
    }

    [HttpPost]
    [Route("api/user/{userId}/sales")]
    public ActionResult<SaleDTO> PostSaleUserId(
           [FromRoute] int userId,
           [FromBody] SaleDTO body)
    {
        body.SellerId = userId;
        _saleService.PostSaleUserId(body);
        return Created("api/user/{userId}/sales", body.Id);

    }

    [HttpPost]
    [Route("api/user/{userId}/buy")]
    public ActionResult<SaleDTO> PostBuyUserId(
            [FromRoute] int userId,
            [FromBody] BuyDTO body)
    {
        body.BuyerId = userId;
        _saleService.PostBuyUserId(body);
        return Created("api/user/{userId}/buy", body.Id);
    }
}
