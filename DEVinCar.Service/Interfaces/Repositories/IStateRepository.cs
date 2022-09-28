using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IStateRepository
    {
        IEnumerable<State> Get();
        IEnumerable<State> GetByName(string name);
        City GetCityById(int cityId);
        State GetStateById(int stateId);
        void PostCity(City city);
        void PostAddress(Address address);
        IEnumerable<City> GetCitiesByStateId(int stateId);
    }
}
