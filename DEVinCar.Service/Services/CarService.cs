using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;

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
            return _carRepository
                .Get()
                .Select(c => new CarDTO(c))
                .ToList();
        }
        public CarDTO GetById(int id)
        {
            return new CarDTO(_carRepository.GetById(id));
        }
        public void Post(CarDTO car)
        {
            _carRepository.Post(new Car(car));
        }
        public void Alter(CarDTO car)
        {
            _carRepository.Alter(new Car(car));
        }
        public void Delete(CarDTO car)
        {
            _carRepository.Delete(new Car(car));
        }
    }
}
