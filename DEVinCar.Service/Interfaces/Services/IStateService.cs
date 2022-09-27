using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IStateService
    {
        IList<StateDTO> Get();
        void Post(StateDTO state);
        void PostAddress(AddressDTO address);
        CityDTO GetCityById(int cityId);
        StateDTO GetStateById(int stateId);
        IEnumerable<CityDTO> GetCitiesByStateId(int stateId);
    }
}
