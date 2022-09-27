using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class SaleDTO
    {
        public int Id { get; internal set; }
        public DateTime SaleDate { get; set; }
        [Required(ErrorMessage = "The BuyerId is required.")]
        public int BuyerId { get; set; }
        public int SellerId { get; internal set; }
    }
}
