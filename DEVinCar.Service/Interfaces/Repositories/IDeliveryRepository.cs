using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IDeliveryRepository
    {
        IQueryable<Delivery> Get();
        void Post(Delivery delivery);
    }
}
