using DEVinCar.Service.Models;

namespace DEVinCar.Service.Interfaces.Repositories
{
    internal interface ISaleCarRepository
    {
        SaleCar GetSoldCar(int carId);
        void Post(SaleCar saleCar);
        void Alter(SaleCar salesCar);
        bool HasBeenSold(int carId);
    }
}
