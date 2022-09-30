using DEVinCar.Service.Models;

namespace DEVinCar.Service.DTOs
{
    public class SaleCarDTO
    {
        public int Id { get; internal set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }

        public SaleCarDTO()
        {
        }
        public SaleCarDTO(SaleCar saleCar)
        {
            Id = saleCar.Id;
            UnitPrice = saleCar.UnitPrice;
            Amount = saleCar.Amount;
            CarId = saleCar.CarId;
            SaleId = saleCar.SaleId;
        }
    }
}
