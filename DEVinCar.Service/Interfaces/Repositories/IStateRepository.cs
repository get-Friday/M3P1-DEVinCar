using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IStateRepository
    {
        IQueryable<State> Get();
        IEnumerable<State> GetByName(string name);
        City GetCityById(int cityId);
        State GetStateById(int stateId);
        void PostCity(City city);
        void PostAddress(Address address);
        IQueryable<City> GetCitiesByStateId(int stateId);
    }
}
