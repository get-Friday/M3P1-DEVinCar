using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class DeliveryRepository : BaseRepository<Delivery, int>, IDeliveryRepository
    {
        public DeliveryRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}
