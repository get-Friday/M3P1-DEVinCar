using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> Get();
        UserDTO GetById(int id);
        void Post(UserDTO user);
        void Delete(int userId);
    }
}
