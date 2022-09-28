using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.DTOs;
using DEVinCar.Service.Models;

namespace DEVinCar.Service.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<UserDTO> Get()
        {
            return _userRepository.Get()
                .Select(u => new UserDTO(u))
                .ToList();
        }
        public UserDTO GetById(int id)
        {
            return new UserDTO(_userRepository.GetById(id));
        }

        public void Post(UserDTO user)
        {
            _userRepository.Post(new User(user));
        }

        public void Delete(int userId)
        {
            User user = _userRepository.GetById(userId);
            _userRepository.Delete(user);
        }
    }
}
