using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ISaleService
    {
        IList<SaleViewModel> GetItemsSale(int saleId);
        IList<SaleDTO> GetSalesByUserId(int userId);
        IList<SaleDTO> GetSalesBySellerId(int userId);
        void PostSale(SaleCarDTO saleCar);
        void PostSaleUserId(SaleDTO sale);
        void PostBuyUserId(BuyDTO buy);
        void PostDelivery(DeliveryDTO delivery);
        void Alter(SaleCarDTO salesCar);
        decimal GetSuggestedPrice(int carId);
        SaleCarDTO GetSoldCar(int carId);
    }
}
