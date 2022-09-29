using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;
using DEVinCar.Service.ViewModels;
using System.Xml.Linq;

namespace DEVinCar.Service.Services
{
    internal class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public IList<GetStateViewModel> Get(string name)
        {
            var query = _stateRepository.Get();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name == name);

            return _stateRepository.Get()
                .Select(s => new GetStateViewModel(
                        s.Id,
                        s.Name,
                        s.Initials
                    )
                    {
                        Cities = _stateRepository.GetCitiesByStateId(s.Id)
                            .Select(c => c.Name)
                            .ToList()
                    })
                .ToList();
        }
        public IList<GetStateViewModel> GetByName(string name)
        {

            return _stateRepository.GetByName(name)
                .Select(s => new GetStateViewModel(
                        s.Id,
                        s.Name,
                        s.Initials
                    )
                {
                    Cities = _stateRepository.GetCitiesByStateId(s.Id)
                            .Select(c => c.Name)
                            .ToList()
                })
                .ToList();
        }
        // TODO
        // Verificar se state == null retornar notfound
        // Verificar se existe outra cidade com mesmo nome e state.Id retornar BadRequest
        public void PostCity(CityDTO city)
        {
            _stateRepository.PostCity(new City(city));
        }
        // TODO
        // Verificar se stateId ou cityId inexistentes retornar NotFound
        // Verificar se cityId tenha um stateId diferente do enviado retornar BadRequest
        public void PostAddress(int stateId, int cityId, AddressDTO addressDTO)
        {
            City city = _stateRepository.GetCityById(cityId);
            Address address = new()
            {
                CityId = cityId,
                Street = addressDTO.Street,
                Number = addressDTO.Number,
                Cep = addressDTO.Cep,
                Complement = addressDTO.Complement,
                City = city
            };
            _stateRepository.PostAddress(address);
        }
        // TODO
        // Verificar se stateId ou cityId inexistentes retornar NotFound
        // Verificar se cityId tenha um stateId diferente do enviado retornar BadRequest
        public GetCityByIdViewModel GetCityById(int stateId, int cityId)
        {
            City city = _stateRepository.GetCityById(cityId);
            State state = _stateRepository.GetStateById(stateId);

            return new GetCityByIdViewModel(
                city.Id,
                city.Name,
                state.Id,
                state.Name,
                state.Initials
            );
        }
        public GetStateViewModel GetStateById(int stateId)
        {
            State state = _stateRepository.GetStateById(stateId);

            GetStateViewModel stateViewModel = new(
                state.Id,
                state.Name,
                state.Initials
            )
            {
                Cities = _stateRepository.GetCitiesByStateId(stateId)
                    .Select(c => c.Name)
                    .ToList()
            };

            return stateViewModel;
        }
        // TODO
        // Verificar se getCitiesByStateId.length == 0 return NoContent
        public IList<GetCityByIdViewModel> GetCitiesByStateId(int stateId, string? name)
        {
            var query = _stateRepository.GetCitiesByStateId(stateId);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));

            State state = _stateRepository.GetStateById(stateId);
            return query
                .Select(c => new GetCityByIdViewModel(
                    c.Id,
                    c.Name,
                    state.Id,
                    state.Name,
                    state.Initials
                    ))
                .ToList();
        }
    }
}
