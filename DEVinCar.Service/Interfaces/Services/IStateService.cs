using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IStateService
    {
        IList<StateDTO> Get();
        void Post(StateDTO state);
        void PostAddress(AddressDTO address);
        GetCityByIdViewModel GetCityById(int cityId);
        GetStateViewModel GetStateById(int stateId);
        IList<CityDTO> GetCitiesByStateId(int stateId);
    }
}
