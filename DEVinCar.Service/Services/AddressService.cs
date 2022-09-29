using DEVinCar.Service.DTOs;
using DEVinCar.Service.Models;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Services
{
    internal class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IList<AddressViewModel> Get(int? cityId, int? stateId, string? street, string? cep)
        {
            var query = _addressRepository.GetIncludeCity();

            if (cityId.HasValue)
                query = query.Where(a => a.CityId == cityId);

            if (stateId.HasValue)
                query = query.Where(a => a.City.StateId == stateId);

            if (!string.IsNullOrEmpty(street))
                query = query.Where(a => a.Street.ToUpper().Contains(street.ToUpper()));

            if (!string.IsNullOrEmpty(cep))
                query = query.Where(a => a.Cep == cep);

            if (!query.ToList().Any())
                throw new Exception();


            return query.Select(a => new AddressViewModel(
                    a.Id,
                    a.Street,
                    a.CityId,
                    a.City.Name,
                    a.Number,
                    a.Complement,
                    a.Cep
                )).ToList();
        }
        public void Alter(AddressPatchDTO addressPatch)
        {
            if (AddressNotFound(addressPatch.Id))
                throw new Exception(); // Address {Id} not found

            if (AllFieldsEmpty(addressPatch))
                throw new Exception(); // Must have at least one field

            if (!addressPatch.Cep.All(char.IsDigit))
                throw new Exception(); // Every characters in cep must be numeric

            _addressRepository.Alter(new Address(addressPatch));
        }
        public void Delete(int id)
        {
            if (AddressNotFound(id))
                throw new Exception(); // Address {Id} not found

            if (_addressRepository.HasDeliveryRelated(id))
                throw new Exception(); // Cannot delete address {Id} because it is related to Delivery

            Address address = _addressRepository.GetById(id);
            _addressRepository.Delete(address);
        }

        private static bool AllFieldsEmpty(AddressPatchDTO address)
        {
            return (
                String.IsNullOrEmpty(address.Street) &&
                String.IsNullOrEmpty(address.Cep) &&
                String.IsNullOrEmpty(address.Complement)
            );
        }

        private bool AddressNotFound(int id)
        {
            return _addressRepository.GetById(id) == null;
        }
    }
}
