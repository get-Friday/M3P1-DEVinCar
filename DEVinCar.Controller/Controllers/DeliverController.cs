using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Controller.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliverController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public ActionResult<DeliveryDTO> Get(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId)
        {
            var query = _deliveryService.Get().AsQueryable();

            if (addressId.HasValue)
                query = query.Where(d => d.AddressId == addressId);

            if (saleId.HasValue)
                query = query.Where(d => d.SaleId == saleId);
                      
            if (!query.ToList().Any())
                return NoContent();

            return Ok(query);
       
        }
    }
}

