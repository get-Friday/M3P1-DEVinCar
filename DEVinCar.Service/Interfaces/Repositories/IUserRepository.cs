using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IUserRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
        void Post(User user);
        void Delete(User user);
    }
}
