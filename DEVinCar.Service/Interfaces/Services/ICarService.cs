using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ICarService
    {
        IList<CarDTO> Get(string? name, decimal? priceMin, decimal? priceMax);
        CarDTO GetById(int id);
        void Post(CarDTO car);
        void Alter(CarDTO car);
        void Delete(int carId);
    }
}
