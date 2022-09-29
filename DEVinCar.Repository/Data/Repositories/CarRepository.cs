using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(DevInCarDbContext context) : base(context)
        {
        }
        public bool HasBeenSold(int carId)
        {
            return _context.SaleCars.Any(c => c.Id == carId);
        }
    }
}
