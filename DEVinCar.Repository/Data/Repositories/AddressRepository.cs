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
        public IQueryable<Address> GetIncludeCity()
        {
            return _context.Addresses.Include(a => a.City).AsQueryable();
        }
        public bool HasDeliveryRelated(int addressId)
        {
            return _context.Deliveries.Any(d => d.AddressId == addressId);
        }
    }
}
