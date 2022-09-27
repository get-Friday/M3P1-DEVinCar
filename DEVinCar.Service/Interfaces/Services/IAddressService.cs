using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IAddressService
    {
        IList<AddressDTO> Get();
        void Alter(AddressDTO car);
        void Delete(AddressDTO address);
    }
}
