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
        public IList<AddressViewModel> Get()
        {
            return _addressRepository
                .GetWithCity()
                .Select(a => new AddressViewModel(
                    a.Id,
                    a.Street,
                    a.CityId,
                    a.City.Name,
                    a.Number,
                    a.Complement,
                    a.Cep
                    ))
                .ToList();
        }
        // TODO
        // Verificar se pelo menos um campo esta sendo alterado
        // Converter patchDTO pra addressDTO
        public void Alter(AddressPatchDTO addressPatch)
        {
            throw new NotImplementedException();
            //_addressRepository.Alter(new Address(address));
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
