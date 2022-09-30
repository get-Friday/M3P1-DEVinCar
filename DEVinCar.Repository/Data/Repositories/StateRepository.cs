using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class StateRepository : BaseRepository<State, int>, IStateRepository
    {
        public StateRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IEnumerable<State> GetByName(string name)
        {
            return _context.States.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));
        }
        public void PostCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }
        public void PostAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        public City GetCityById(int cityId)
        {
            return _context.Cities.Find(cityId);
        }
        public State GetStateById(int stateId)
        {
            return _context.States.Find(stateId);
        }
        public IQueryable<City> GetCitiesByStateId(int stateId)
        {
            return _context.Cities.Where(c => c.StateId == stateId).AsQueryable();
        }
    }
}
