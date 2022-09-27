using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Models
{
    public class SaleCar
    {
        public int Id { get; internal set; }
        public decimal UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Sale Sale { get; set; }

        public SaleCar()
        {
        }
        public SaleCar(SaleCarDTO saleCar)
        {
            Id = saleCar.Id;
            UnitPrice = saleCar.UnitPrice;
            Amount = saleCar.Amount;
            CarId = saleCar.CarId;
            SaleId = saleCar.SaleId;
        }

        public decimal Sum(decimal UnitPrice, int? Amount)
        {
            return UnitPrice * (int)Amount;
        }
    }
}
