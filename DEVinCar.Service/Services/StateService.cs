using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Services
{
    internal class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public IList<GetStateViewModel> Get(string name)
        {
            var query = _stateRepository.Get();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name == name);

            return _stateRepository.Get()
                .Select(s => new GetStateViewModel(
                        s.Id,
                        s.Name,
                        s.Initials
                    )
                    {
                        Cities = _stateRepository.GetCitiesByStateId(s.Id)
                            .Select(c => c.Name)
                            .ToList()
                    })
                .ToList();
        }
        public IList<GetStateViewModel> GetByName(string name)
        {

            return _stateRepository.GetByName(name)
                .Select(s => new GetStateViewModel(
                        s.Id,
                        s.Name,
                        s.Initials
                    )
                {
                    Cities = _stateRepository.GetCitiesByStateId(s.Id)
                            .Select(c => c.Name)
                            .ToList()
                })
                .ToList();
        }
        
        public void PostCity(CityDTO city)
        {
            if (StateNotFound(city.StateId))
                throw new Exception(); // State {id} not found

            if (DuplicatedCityName(city.Name, city.StateId))
                throw new Exception(); // Cannot create city with the name "{name}" in this state

            _stateRepository.PostCity(new City(city));
        }

        public void PostAddress(int stateId, int cityId, AddressDTO addressDTO)
        {
            if (CityNotFound(cityId))
                throw new Exception(); // City {id} not found

            if (StateNotFound(stateId))
                throw new Exception(); // State {id} not found

            City city = _stateRepository.GetCityById(cityId);

            if (city.StateId != stateId)
                throw new Exception(); // Invalid State {StateId} for city {CityId}

            Address address = new()
            {
                CityId = cityId,
                Street = addressDTO.Street,
                Number = addressDTO.Number,
                Cep = addressDTO.Cep,
                Complement = addressDTO.Complement,
                City = city
            };
            _stateRepository.PostAddress(address);
        }

        public GetCityByIdViewModel GetCityById(int stateId, int cityId)
        {
            if (CityNotFound(cityId))
                throw new Exception(); // City {id} not found

            if (StateNotFound(stateId))
                throw new Exception(); // State {id} not found

            City city = _stateRepository.GetCityById(cityId);

            if (city.StateId != stateId)
                throw new Exception(); // Invalid State {StateId} for city {CityId}

            State state = _stateRepository.GetStateById(stateId);

            return new GetCityByIdViewModel(
                city.Id,
                city.Name,
                state.Id,
                state.Name,
                state.Initials
            );
        }
        public GetStateViewModel GetStateById(int stateId)
        {
            State state = _stateRepository.GetStateById(stateId);

            GetStateViewModel stateViewModel = new(
                state.Id,
                state.Name,
                state.Initials
            )
            {
                Cities = _stateRepository.GetCitiesByStateId(stateId)
                    .Select(c => c.Name)
                    .ToList()
            };

            return stateViewModel;
        }

        public IList<GetCityByIdViewModel> GetCitiesByStateId(int stateId, string? name)
        {
            var query = _stateRepository.GetCitiesByStateId(stateId);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));

            if (!query.Any())
                throw new Exception(); // No City found

            State state = _stateRepository.GetStateById(stateId);
            return query
                .Select(c => new GetCityByIdViewModel(
                    c.Id,
                    c.Name,
                    state.Id,
                    state.Name,
                    state.Initials
                    ))
                .ToList();
        }

        // Regras de negócio abaixo
        private bool StateNotFound(int id)
        {
            return _stateRepository.GetStateById(id) == null;
        }

        private bool CityNotFound(int id)
        {
            return _stateRepository.GetCityById(id) == null;
        }

        private bool DuplicatedCityName(string cityName, int stateId)
        {
            return _stateRepository.GetCitiesByStateId(stateId).Any(c => c.Name == cityName);
        }
    }
}
