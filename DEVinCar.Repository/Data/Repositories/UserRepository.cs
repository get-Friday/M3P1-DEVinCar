using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}
