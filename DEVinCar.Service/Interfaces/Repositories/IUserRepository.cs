using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IUserRepository
    {
        IQueryable<User> Get();
        User GetById(int id);
        void Post(User user);
        void Delete(User user);
        bool EmailDuplicated(string email);
    }
}
