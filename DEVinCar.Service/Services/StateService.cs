using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;

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
            throw new NotImplementedException();
        }
        public void Post(StateDTO state)
        {
            throw new NotImplementedException();
        }
        public void PostAddress(AddressDTO address)
        {
            throw new NotImplementedException();
        }
        public CityDTO GetCityById(int cityId)
        {
            throw new NotImplementedException();
        }
        public StateDTO GetStateById(int stateId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<CityDTO> GetCitiesByStateId(int stateId)
        {
            throw new NotImplementedException();
        }
    }
}
