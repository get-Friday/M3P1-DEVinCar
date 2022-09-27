using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Repository.Data.Repositories
{
    public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
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
        public void PostSale(SaleCar saleCar)
        {
            _context.SaleCars.Add(saleCar);
            _context.SaveChanges();
        }
        public void PostDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
        }
        public void AlterCarAmount(SaleCar salesCar)
        {
            _context.SaleCars.Update(salesCar);
            _context.SaveChanges();
        }
        public void AlterUnitPrice(SaleCar salesCar)
        {
            _context.SaleCars.Update(salesCar);
            _context.SaveChanges();
        }
    }
}
