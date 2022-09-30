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
            [FromQuery] int? saleId
        )
        {
            return Ok(_deliveryService.Get(addressId, saleId));
        }
    }
}

