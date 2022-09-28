using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface ISaleRepository
    {
        IEnumerable<Sale> GetItemsSale(int saleId);
        IEnumerable<Sale> GetSalesByUserId(int userId);
        IEnumerable<Sale> GetSalesBySellerId(int userId);
        void PostSale(SaleCar saleCar);
        void PostDelivery(Delivery delivery);
        void PostSaleUserId(Sale sale);
        void PostBuyUserId(Sale buy);
        void Alter(SaleCar salesCar);
        decimal GetSuggestedPrice(int carId);
        SaleCar GetSoldCar(int carId);
    }
}
