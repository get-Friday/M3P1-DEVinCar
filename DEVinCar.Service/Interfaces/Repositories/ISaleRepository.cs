using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface ISaleRepository
    {
        IEnumerable<Sale> GetItemsSale(int saleId);
        IEnumerable<Sale> GetSalesByUserId(int userId);
        IEnumerable<Sale> GetSalesBySellerId(int userId);
        void PostSaleUserId(Sale sale);
        void PostBuyUserId(Sale buy);
    }
}
