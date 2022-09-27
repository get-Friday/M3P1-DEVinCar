using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;

namespace DEVinCar.Service.Services
{
    internal class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IList<AddressDTO> Get()
        {
            throw new NotImplementedException();
        }
        public void Alter(AddressDTO car)
        {
            throw new NotImplementedException();
        }
        public void Delete(AddressDTO address)
        {
            throw new NotImplementedException();
        }
    }
}
