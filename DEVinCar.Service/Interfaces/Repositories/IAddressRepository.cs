using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface IAddressRepository
    {
        IQueryable<Address> GetIncludeCity();
        Address GetById(int id);
        void Alter(Address car);
        void Delete(Address address);
    }
}
