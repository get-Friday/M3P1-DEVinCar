using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ICarService
    {
        IList<CarDTO> Get();
        CarDTO GetById(int id);
        void Post(CarDTO car);
        void Alter(CarDTO car);
        void Delete(int carId);
    }
}
