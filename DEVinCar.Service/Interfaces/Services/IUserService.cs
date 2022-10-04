using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> Get(string? name, DateTime? birthDateMax, DateTime? birthDateMin);
        UserDTO GetById(int id);
        void Post(UserDTO user);
        void Delete(int userId);
        LoginDTO Login(string email, string password);
    }
}
