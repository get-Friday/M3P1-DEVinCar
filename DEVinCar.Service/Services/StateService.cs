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
        public IList<StateDTO> Get()
        {
            return _stateRepository.Get()
                .Select(s => new StateDTO(s))
                .ToList();
        }
        public void Post(StateDTO state)
        {
            _stateRepository.Post(new State(state));
        }
        public void PostAddress(AddressDTO address)
        {
            _stateRepository.PostAddress(new Address(address));
        }
        public GetCityByIdViewModel GetCityById(int cityId)
        {
            City city = _stateRepository.GetCityById(cityId);
            State state = _stateRepository.GetStateById(city.StateId);

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
        public IList<CityDTO> GetCitiesByStateId(int stateId)
        {
            return _stateRepository.GetCitiesByStateId(stateId)
                .Select(c => new CityDTO(c))
                .ToList();
        }
    }
}
