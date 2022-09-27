using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;

namespace DEVinCar.Service.Services
{
    internal class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public IList<SaleDTO> GetItemsSale(int saleId)
        {
            throw new NotImplementedException();
        }
        public void PostSale(SaleCarDTO saleCar)
        {
            throw new NotImplementedException();
        }
        public void PostDelivery(DeliveryDTO delivery)
        {
            throw new NotImplementedException();
        }
        public void AlterCarAmount(SaleCarDTO salesCar)
        {
            throw new NotImplementedException();
        }
        public void AlterUnitPrice(SaleCarDTO salesCar)
        {
            throw new NotImplementedException();
        }
    }
}
