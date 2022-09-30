using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext context) : base(context)
        {
        }
        public bool EmailDuplicated(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
