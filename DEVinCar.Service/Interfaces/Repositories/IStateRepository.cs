using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IStateRepository
    {
        IEnumerable<State> Get();
        void Post(State state);
        void PostAddress(Address address);
        City GetCityById(int cityId);
        State GetStateById(int stateId);
        IEnumerable<City> GetCitiesByStateId(int stateId);
    }
}
