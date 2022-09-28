﻿using DEVinCar.Service.DTOs;
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
        // TODO
        // Verificar se saleCar.CarId e saleCar.SaleId não existe no repository retornar NotFound
        // Verificar se saleCar.CarId == 0 retornar BadRequest
        // Verificar se saleCar.UnitPrice <= 0 || saleCar.Amount <= 0 retornar BadRequest
        public void PostSale(SaleCarDTO saleCar)
        {
            _saleRepository.PostSale(new SaleCar(saleCar));
        }
        // TODO
        // Verificar se delivery.saleId não existe retornar NotFound
        // Verificar se delivery.AddressId não existe retornar NotFound
        // Verificar se DateTime.Now.Date menor que delivery.DeliveryForecast retornar badRequest
        public void PostDelivery(DeliveryDTO delivery)
        {
            _saleRepository.PostDelivery(new Delivery(delivery));
        }
        public void Alter(SaleCarDTO salesCar)
        {
            _saleRepository.Alter(new SaleCar(salesCar));
        }
        public decimal GetSuggestedPrice(int carId)
        {
            return _saleRepository.GetSuggestedPrice(carId);
        }
        // TODO 
        // Verificar se existe sale com o id passado
        public SaleCarDTO GetSoldCar(int saleId)
        {
            return new SaleCarDTO(_saleRepository.GetSoldCar(saleId));
        }
    }
}
