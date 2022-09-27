using DEVinCar.Service.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class CarDTO
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

        public CarDTO()
        {
        }
        public CarDTO(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            SuggestedPrice = car.SuggestedPrice;
        }
    }
}
