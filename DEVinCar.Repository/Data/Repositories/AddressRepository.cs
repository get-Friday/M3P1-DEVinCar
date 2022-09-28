using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Repository.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
        }
        public IEnumerable<Address> GetWithCity()
        {
            return _context.Addresses.Include(a => a.City);
        }
    }
}
