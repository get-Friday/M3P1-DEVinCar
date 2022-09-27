using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ISaleService
    {
        IList<SaleDTO> GetItemsSale(int saleId);
        void PostSale(SaleCarDTO saleCar);
        void PostDelivery(DeliveryDTO delivery);
        void AlterCarAmount(SaleCarDTO salesCar);
        void AlterUnitPrice(SaleCarDTO salesCar);
    }
}
