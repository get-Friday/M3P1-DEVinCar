using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class CityDTO
    {
        public int Id { get; internal set; }
        public int StateId { get; internal set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}