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
        // TODO
        // Mover para SaleService
        public IList<SaleDTO> GetSalesByUserId(int userId)
        {
            return _userRepository.GetSalesByUserId(userId)
                .Select(s => new SaleDTO(s))
                .ToList();
        }
        // TODO
        // Mover para SaleService
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
        // TODO
        // Verificar se sale.BuyerId = 0 retornar BadRequest
        // Verificar se sale.SellerId em User não existe retornar NotFound
        // Verificar se sale.BuyerId em User não existe retornar NotFound
        // Mover para SaleService
        public void PostSaleUserId(SaleDTO sale)
        {

            _userRepository.PostSaleUserId(new Sale(sale));
        }
        // TODO
        // Verificar se buy.BuyerId em User não existe retornar NotFound
        // Verificar se buy.SellerId em User não existe retornar NotFound
        // Mover para SaleService
        public void PostBuyUserId(BuyDTO buy)
        {
            _userRepository.PostBuyUserId(new Sale(buy));
        }
        public void Delete(int userId)
        {
            User user = _userRepository.GetById(userId);
            _userRepository.Delete(user);
        }
    }
}
