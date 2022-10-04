using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateTokenFromUser(LoginDTO user);
    }
}
