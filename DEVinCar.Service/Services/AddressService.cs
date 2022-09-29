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
        // TODO
        // Verificar se pelo menos um campo esta sendo alterado
        public void Alter(AddressPatchDTO addressPatch)
        {
            _addressRepository.Alter(new Address(addressPatch));
        }
        // TODO
        // Verifica se address não existe retorna NotFound
        // Verifica se existe uma relação do endereço com uma entrega em context.deliveries
        public void Delete(int id)
        {
            Address address = _addressRepository.GetById(id);
            _addressRepository.Delete(address);
        }
    }
}
