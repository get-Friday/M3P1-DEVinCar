using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface ICarRepository
    {
        IEnumerable<Car> Get();
        Car GetById(int id);
        void Post(Car car);
        void Alter(Car car);
        void Delete(int id);
    }
}
