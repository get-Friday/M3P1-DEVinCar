using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Controller.DTOs
{
     public class CityDTO
    {     
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]  
        public string Name { get; set; }

       
       
    }
}