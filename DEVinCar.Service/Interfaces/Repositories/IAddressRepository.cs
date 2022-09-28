using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IAddressRepository
    {
        IEnumerable<Address> GetWithCity();
        Address GetById(int id);
        void Alter(Address car);
        void Delete(Address address);
    }
}
