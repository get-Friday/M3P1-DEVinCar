using DEVinCar.Service.DTOs;
using DEVinCar.Service.Models;
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
            return _addressRepository
                .Get()
                .Select(a => new AddressDTO(a))
                .ToList();
        }
        public void Alter(AddressDTO address)
        {
            _addressRepository.Alter(new Address(address));
        }
        public void Delete(AddressDTO address)
        {
            _addressRepository.Delete(new Address(address));
        }
    }
}
