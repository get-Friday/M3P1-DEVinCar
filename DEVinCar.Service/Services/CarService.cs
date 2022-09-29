using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;
using System.Xml.Linq;

namespace DEVinCar.Service.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IList<CarDTO> Get(string? name, decimal? priceMin, decimal? priceMax)
        {
            var query = _carRepository
                .Get()
                .Select(c => new CarDTO(c));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));

            if (priceMin > priceMax)
                throw new Exception(); // Minimal price cant be higher than maximum price

            if (priceMin.HasValue)
                query = query.Where(c => c.SuggestedPrice >= priceMin);

            if (priceMax.HasValue)
                query = query.Where(c => c.SuggestedPrice <= priceMax);

            if (!query.ToList().Any())
                throw new Exception(); // No car found

            return query.ToList();
        }

        public CarDTO GetById(int id)
        {
            return new CarDTO(_carRepository.GetById(id));
        }

        public void Post(CarDTO car)
        {
            if (HasCarWithThisName(car.Name))
                throw new Exception(); // Car with this name already exists

            if (car.SuggestedPrice <= 0)
                throw new Exception(); // Invalid car price

            _carRepository.Post(new Car(car));
        }

        public void Alter(CarDTO car)
        {
            if (CarNotFound(car.Id))
                throw new Exception(); // Car not found

            if (AllFieldsEmpty(car))
                throw new Exception(); // Please fill all fields

            if (HasDifferentCarWithThisName(car.Name, car.Id))
                throw new Exception(); // Car with this name already exists 

            if (car.SuggestedPrice <= 0)
                throw new Exception(); // Invalid car price


            _carRepository.Alter(new Car(car));
        }

        public void Delete(int carId)
        {
            if (CarNotFound(carId))
                throw new Exception(); // Car not found

            if (_carRepository.HasBeenSold(carId))
                throw new Exception(); // Cannot delete sold car

            Car car = _carRepository.GetById(carId);
            _carRepository.Delete(car);
        }

        private bool CarNotFound(int id)
        {
            return _carRepository.GetById(id) == null;
        }

        private bool HasCarWithThisName(string name)
        {
            return _carRepository.Get().Any(c => c.Name == name);
        }

        private bool HasDifferentCarWithThisName(string name, int carId)
        {
            return _carRepository.Get().Any(c => c.Name == name && c.Id != carId);
        }

        private bool AllFieldsEmpty(CarDTO car)
        {
            return (
                String.IsNullOrEmpty(car.Name) &&
                car.SuggestedPrice.Equals(null)
            );
        }
    }
}
