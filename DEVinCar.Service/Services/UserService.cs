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
        public IList<UserDTO> Get(string? name, DateTime? birthDateMax, DateTime? birthDateMin)
        {
            var query = _userRepository.Get();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));

            if (birthDateMin.HasValue)
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);

            if (birthDateMax.HasValue)
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);

            if (!query.Any())
                throw new Exception();

            return query
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
