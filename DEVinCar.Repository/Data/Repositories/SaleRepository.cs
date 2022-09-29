using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Repository.Data.Repositories
{
    public class SaleRepository : BaseRepository<SaleCar, int>, ISaleRepository
    {
        public SaleRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IEnumerable<Sale> GetItemsSale(int saleId)
        {
            return _context.Sales
                .Include(s => s.Cars)
                .Include(s => s.UserBuyer)
                .Include(s => s.UserSeller)
                .Where(s => s.Id == saleId);
        }
        public void PostDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
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
