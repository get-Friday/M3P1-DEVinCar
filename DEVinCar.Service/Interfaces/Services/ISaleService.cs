using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ISaleService
    {
        IList<SaleViewModel> GetItemsSale(int saleId);
        void PostSale(SaleCarDTO saleCar);
        void PostDelivery(DeliveryDTO delivery);
        void Alter(SaleCarDTO salesCar);
        decimal GetSuggestedPrice(int carId);
        SaleCarDTO GetSoldCar(int carId);
    }
}
