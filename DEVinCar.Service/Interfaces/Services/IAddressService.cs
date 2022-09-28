using DEVinCar.Service.DTOs;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Interfaces.Services
{
    public interface IAddressService
    {
        IList<AddressViewModel> Get();
        void Alter(AddressPatchDTO addressPatch);
        void Delete(int id);
    }
}
