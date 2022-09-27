using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> Get();
        UserDTO GetById(int id);
        IList<SaleDTO> GetSalesByUserId(int userId);
        IList<SaleDTO> GetSalesBySellerId(int userId);
        void Post(UserDTO user);
        void PostSaleUserId(SaleDTO sale);
        void PostBuyUserId(SaleDTO buy);
        void Delete(UserDTO user);
    }
}
