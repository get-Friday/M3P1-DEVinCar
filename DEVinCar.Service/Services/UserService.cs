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
        public IList<SaleDTO> GetSalesByUserId(int userId)
        {
            return _userRepository.GetSalesByUserId(userId)
                .Select(s => new SaleDTO(s))
                .ToList();
        }
        public IList<SaleDTO> GetSalesBySellerId(int userId)
        {
            return _userRepository.GetSalesBySellerId(userId)
                .Select(s => new SaleDTO(s))
                .ToList();
        }
        public void Post(UserDTO user)
        {
            _userRepository.Post(new User(user));
        }
        public void PostSaleUserId(SaleDTO sale)
        {
            _userRepository.PostSaleUserId(new Sale(sale));
        }
        public void PostBuyUserId(SaleDTO buy)
        {
            _userRepository.PostBuyUserId(new Sale(buy));
        }
        public void Delete(UserDTO user)
        {
            _userRepository.Delete(new User(user));
        }
    }
}
