using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface ISaleRepository
    {
        IEnumerable<Sale> GetItemsSale(int saleId);
        void PostSale(SaleCar saleCar);
        void PostDelivery(Delivery delivery);
        void Alter(SaleCar salesCar);
        decimal GetSuggestedPrice(int carId);
        SaleCar GetSoldCar(int carId);
    }
}
