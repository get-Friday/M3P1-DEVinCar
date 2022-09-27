using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;

namespace DEVinCar.Service.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IList<CarDTO> Get()
        {
            throw new NotImplementedException();
        }
        public CarDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Post(CarDTO car)
        {
            throw new NotImplementedException();
        }
        public void Alter(CarDTO car)
        {
            throw new NotImplementedException();
        }
        public void Delete(CarDTO car)
        {
            throw new NotImplementedException();
        }
    }
}
