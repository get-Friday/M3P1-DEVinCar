using DEVinCar.Service.DTOs;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Services
{
    internal class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public IList<SaleViewModel> GetItemsSale(int saleId)
        {
            return _saleRepository.GetItemsSale(saleId)
                .Select(s => new SaleViewModel
                {
                    SellerName = s.UserSeller.Name,
                    BuyerName = s.UserBuyer.Name,
                    SaleDate = s.SaleDate,
                    Itens = s.Cars.Select(sc => new CarViewModel
                    {
                        Name = sc.Car.Name,
                        UnitPrice = sc.UnitPrice,
                        Amount = sc.Amount,
                        Total = sc.Sum(sc.UnitPrice, sc.Amount)
                    }).ToList()
                })
                .ToList();
        }
        public void PostSale(SaleCarDTO saleCar)
        {
            _saleRepository.PostSale(new SaleCar(saleCar));
        }
        public void PostDelivery(DeliveryDTO delivery)
        {
            _saleRepository.PostDelivery(new Delivery(delivery));
        }
        public void AlterCarAmount(SaleCarDTO salesCar)
        {
            _saleRepository.AlterCarAmount(new SaleCar(salesCar));
        }
        public void AlterUnitPrice(SaleCarDTO salesCar)
        {
            _saleRepository.AlterUnitPrice(new SaleCar(salesCar));
        }
    }
}
