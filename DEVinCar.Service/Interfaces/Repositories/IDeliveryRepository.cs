using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IDeliveryRepository
    {
        IEnumerable<Delivery> Get();
    }
}
