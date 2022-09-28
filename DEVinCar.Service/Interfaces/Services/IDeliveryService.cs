using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IDeliveryService
    {
        IList<DeliveryDTO> Get(int? addressId, int? saleId);
    }
}
