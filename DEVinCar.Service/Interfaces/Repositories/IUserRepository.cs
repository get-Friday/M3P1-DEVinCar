using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        IEnumerable<Sale> GetByIdbuy(int userId);
        IEnumerable<Sale> GetSalesBySellerId(int userId);
        void Post(User user);
        void PostSaleUserId(Sale sale);
        void PostBuyUserId(Sale buy);
        void Delete(User user);
    }
}
