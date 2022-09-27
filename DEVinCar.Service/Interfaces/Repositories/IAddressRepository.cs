using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IAddressRepository
    {
        IEnumerable<Address> Get();
        void Alter(Address car);
        void Delete(Address address);
    }
}
