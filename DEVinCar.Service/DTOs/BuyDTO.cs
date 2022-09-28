using DEVinCar.Service.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class BuyDTO
    {
        public int Id { get; internal set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        [Required(ErrorMessage = "The SelleId is required.")]
        public int SellerId { get; set; }

        public BuyDTO()
        {
        }
        public BuyDTO(Sale sale)
        {
            Id = sale.Id;
            SaleDate = sale.SaleDate;
            BuyerId = sale.BuyerId;
            SellerId = sale.SellerId;
        }
    }
}


