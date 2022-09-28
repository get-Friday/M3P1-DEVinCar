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
                throw new Exception(); //BadRequest()

            if (priceMin.HasValue)
                query = query.Where(c => c.SuggestedPrice >= priceMin);

            if (priceMax.HasValue)
                query = query.Where(c => c.SuggestedPrice <= priceMax);

            if (!query.ToList().Any())
                throw new Exception(); //NoContent()

            return query.ToList();
        }
        public CarDTO GetById(int id)
        {
            return new CarDTO(_carRepository.GetById(id));
        }
        // TODO
        // Verificar se já existe um carro com esse nome return badRequest
        // Verificar se o SuggestedPrice <= 0 return badRequest
        public void Post(CarDTO car)
        {
            _carRepository.Post(new Car(car));
        }
        // TODO
        // Verificar se carro existe se não retornar NotFound
        // Verificar se carDto.Name.Equals(null) || carDto.SuggestedPrice.Equals(null) return BadRequest
        // Verificar se carDto.SuggestedPrice <= 0 return BadRequest
        // Verificar se nome do carro a editar já existe: Cars.Any(c => c.Name == carDto.Name && c.Id != carId) return BadRequest
        public void Alter(CarDTO car)
        {
            _carRepository.Alter(new Car(car));
        }
        // TODO
        // Verificar se o carro já está vendido retornar badRequest
        public void Delete(int carId)
        {
            Car car = _carRepository.GetById(carId);
            _carRepository.Delete(car);
        }
    }
}
