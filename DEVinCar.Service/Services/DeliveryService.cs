using DEVinCar.Service.DTOs;
using DEVinCar.Service.Exceptions;
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
        public IList<DeliveryDTO> Get(int? addressId, int? saleId)
        {
            var query = _DeliveryRepository.Get()
                .Select(d => new DeliveryDTO(d));

            if (addressId.HasValue)
                query = query.Where(d => d.AddressId == addressId);

            if (saleId.HasValue)
                query = query.Where(d => d.SaleId == saleId);

            if (!query.ToList().Any())
                throw new ObjectNotFoundException("Delivery not found.");

            return query.ToList();
        }
    }
}
