using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IStateService
    {
        IList<GetStateViewModel> Get();
        IList<GetStateViewModel> GetByName(string name);
        void PostCity(CityDTO city);
        void PostAddress(int stateId, int cityId, AddressDTO address);
        GetCityByIdViewModel GetCityById(int stateId, int cityId);
        GetStateViewModel GetStateById(int stateId);
        IList<GetCityByIdViewModel> GetCitiesByStateId(int stateId);
    }
}
