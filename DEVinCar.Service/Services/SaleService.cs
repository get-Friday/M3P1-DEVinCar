using DEVinCar.Service.DTOs;
using DEVinCar.Service.Exceptions;
using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Interfaces.Services;
using DEVinCar.Service.Models;
using DEVinCar.Service.ViewModels;

namespace DEVinCar.Service.Services
{
    internal class SaleService : ISaleService
    {
        private readonly ICarRepository _carRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleCarRepository _saleCarRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public SaleService(
            ISaleRepository saleRepository, 
            ISaleCarRepository saleCarRepository,
            ICarRepository carRepository,
            IDeliveryRepository deliveryRepository,
            IAddressRepository addressRepository,
            IUserRepository userRepository
        )
        {
            _saleRepository = saleRepository;
            _saleCarRepository = saleCarRepository;
            _carRepository = carRepository;
            _deliveryRepository = deliveryRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
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
            saleCar.UnitPrice ??= _carRepository.GetSuggestedPrice(saleCar.CarId);
            saleCar.Amount ??= 1;

            if (SoldCarNotFound(saleCar.CarId, saleCar.SaleId))
                throw new ObjectNotFoundException("Sold car not found.");

            if (saleCar.CarId == 0)
                throw new EqualOrLowerThanZeroException("Invalid ID. Can't be zero.");

            if (IsEqualOrLowerThanZero(saleCar.UnitPrice, saleCar.Amount))
                throw new EqualOrLowerThanZeroException("Data can't be lower than zero.");
            
            _saleCarRepository.Post(new SaleCar(saleCar));
        }
        
        public void PostDelivery(DeliveryDTO delivery)
        {
            if (SaleNotFound(delivery.SaleId))
                throw new ObjectNotFoundException($"Sale #{delivery.SaleId} not found.");

            if (AddressNotFound(delivery.AddressId))
                throw new ObjectNotFoundException($"Address #{delivery.AddressId} not found.");

            delivery.DeliveryForecast ??= DateTime.Now.AddDays(7);

            if (HasInvalidDate(delivery.DeliveryForecast))
                throw new ValueNotAcceptableException("Invalid delivery forecast."); 

            _deliveryRepository.Post(new Delivery(delivery));
        }

        public void Alter(int saleId, int carId, int? amount, decimal? unitPrice)
        {
            if (SaleNotFound(saleId))
                throw new ObjectNotFoundException($"Sale #{saleId} not found.");

            if (SoldCarNotFound(carId, saleId))
                throw new ObjectNotFoundException($"Sold car #{carId} not found.");

            if (IsEqualOrLowerThanZero(unitPrice, amount))
                throw new EqualOrLowerThanZeroException("Invalid Values. Can't be zero or lower.");

            SaleCar soldCar = _saleCarRepository.GetSoldCar(carId);

            if (amount.HasValue)
                soldCar.Amount = amount;

            if (unitPrice.HasValue)
                soldCar.UnitPrice = (decimal)unitPrice;

            _saleCarRepository.Alter(soldCar);
        }

        public IList<SaleDTO> GetSalesByUserId(int userId)
        {
            return _saleRepository.GetSalesByUserId(userId)
                .Select(s => new SaleDTO(s))
                .ToList();
        }

        public IList<SaleDTO> GetSalesBySellerId(int userId)
        {
            return _saleRepository.GetSalesBySellerId(userId)
                .Select(s => new SaleDTO(s))
                .ToList();
        }

        public void PostSaleUserId(SaleDTO sale)
        {
            if (sale.BuyerId == 0)
                throw new EqualOrLowerThanZeroException("Invalid ID. Can't be zero.");

            if (UserNotFound(sale.BuyerId) || UserNotFound(sale.SellerId))
                throw new ObjectNotFoundException("User not found.");


            _saleRepository.PostSaleUserId(new Sale(sale));
        }
        
        public void PostBuyUserId(BuyDTO buy)
        {
            if (UserNotFound(buy.BuyerId) || UserNotFound(buy.SellerId))
                throw new ObjectNotFoundException("User not found.");

            _saleRepository.PostBuyUserId(new Sale(buy));
        }
        public decimal GetSuggestedPrice(int carId)
        {
            return _carRepository.GetSuggestedPrice(carId);
        }

        public SaleCarDTO GetSoldCar(int saleId)
        {
            if (SaleNotFound(saleId))
                throw new ObjectNotFoundException($"Sale #{saleId} not found.");

            return new SaleCarDTO(_saleCarRepository.GetSoldCar(saleId));
        }

        // Regras de negócio abaixo
        private bool SoldCarNotFound(int carId, int saleId)
        {
            return (
                _carRepository.GetById(carId) == null &&
                _saleRepository.SaleExists(saleId) == false
            );
        }

        private bool IsEqualOrLowerThanZero(decimal? unitPrice, int? amount)
        {
            return (
                unitPrice <= 0 ||
                amount <= 0
            );
        }

        private bool SaleNotFound(int id)
        {
            return _saleRepository.SaleExists(id) == false;
        }

        private bool AddressNotFound(int id)
        {
            return _addressRepository.GetById(id) == null;
        }

        private bool HasInvalidDate(DateTime? deliveryForecast)
        {
            return deliveryForecast < DateTime.Now.Date;
        }

        private bool UserNotFound(int id)
        {
            return _userRepository.GetById(id) == null;
        }
    }
}
