using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IEnumerable<Sale> GetSalesByUserId(int userId)
        {
            return _context.Sales.Where(s => s.BuyerId == userId);
        }
        public IEnumerable<Sale> GetSalesBySellerId(int userId)
        {
            return _context.Sales.Where(s => s.SellerId == userId);
        }
        public void PostSaleUserId(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }
        public void PostBuyUserId(Sale buy)
        {
            _context.Sales.Add(buy);
            _context.SaveChanges();
        }
    }
}
