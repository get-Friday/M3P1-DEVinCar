using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.DTOs;
using DEVinCar.Service.Models;
using DEVinCar.Service.Exceptions;

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
                throw new ObjectNotFoundException("User not found.");

            return query
                .Select(u => new UserDTO(u))
                .ToList();
        }
        public UserDTO GetById(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
                throw new ObjectNotFoundException("User not found.");

            return new UserDTO();
        }

        public void Post(UserDTO user)
        {
            if (_userRepository.EmailDuplicated(user.Email))
                throw new DuplicatedEntryException("Email already registered.");

            _userRepository.Post(new User(user));
        }

        public void Delete(int id)
        {
            User user = _userRepository.GetById(id);

            if (user == null)
                throw new ObjectNotFoundException("User not found.");

            _userRepository.Delete(user);
        }
        public LoginDTO Login(string email, string password)
        {
            User user = _userRepository.Login(email, password);

            if (user == null)
                throw new ObjectNotFoundException("Invalid email or password.");

            return new LoginDTO(user);
        }
    }
}
