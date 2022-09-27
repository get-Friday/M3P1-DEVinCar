using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ISaleService
    {
        IList<SaleViewModel> GetItemsSale(int saleId);
        void PostSale(SaleCarDTO saleCar);
        void PostDelivery(DeliveryDTO delivery);
        void AlterCarAmount(SaleCarDTO salesCar);
        void AlterUnitPrice(SaleCarDTO salesCar);
    }
}
