using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Models
{
    public class Sale
    {
        public int Id { get; internal set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }

        public virtual User UserBuyer { get; set; }
        public virtual User UserSeller { get; set; }
        public virtual List<SaleCar> Cars { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }

        public Sale()
        {
        }
        public Sale(SaleDTO sale)
        {
            Id = sale.Id;
            SaleDate = sale.SaleDate;
            BuyerId = sale.BuyerId;
            SellerId = sale.SellerId;
        }
        public Sale(BuyDTO buy)
        {
            Id = buy.Id;
            SaleDate = buy.SaleDate;
            BuyerId = buy.BuyerId;
            SellerId = buy.SellerId;
        }
    }
}