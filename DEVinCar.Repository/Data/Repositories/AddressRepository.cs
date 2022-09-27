using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}
