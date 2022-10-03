using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
    {
        public SaleCarRepository(DevInCarDbContext context) : base(context)
        {
        }
        public SaleCar GetSoldCar(int saleId)
        {
            return _context.SaleCars.Find(saleId);
        }
        public bool HasBeenSold(int carId)
        {
            return _context.SaleCars.Any(c => c.Id == carId);
        }
    }
}
