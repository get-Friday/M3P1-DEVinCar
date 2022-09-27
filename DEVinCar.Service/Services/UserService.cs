using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.DTOs;
using System.Xml.Linq;

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
            throw new NotImplementedException();
        }
        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
        public IList<UserDTO> GetByIdbuy(int userId)
        {
            throw new NotImplementedException();
        }
        public IList<UserDTO> GetSalesBySellerId(int userId)
        {
            throw new NotImplementedException();
        }
        public void Post(UserDTO user)
        {
            throw new NotImplementedException();
        }
        public void PostSaleUserId(SaleDTO sale)
        {
            throw new NotImplementedException();
        }
        public void PostBuyUserId(SaleDTO buy)
        {
            throw new NotImplementedException();
        }
        public void Delete(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
