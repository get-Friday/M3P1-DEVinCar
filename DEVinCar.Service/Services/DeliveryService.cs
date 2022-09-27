using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;

namespace DEVinCar.Service.Services
{
    internal class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _DeliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _DeliveryRepository = deliveryRepository;
        }
        public IList<DeliveryDTO> Get()
        {
            return _DeliveryRepository
                .Get()
                .Select(d => new DeliveryDTO(d))
                .ToList();
        }
    }
}
