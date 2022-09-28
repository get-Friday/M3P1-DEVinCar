using System.ComponentModel.DataAnnotations;
using DEVinCar.Service.Annotations;
using DEVinCar.Service.Models;

namespace DEVinCar.Service.DTOs
{
    public class UserDTO
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "The email is required")]
        [MaxLength(150)]
        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The password is required")]
        [MaxLength(50)]
        [MinLength(4, ErrorMessage = "The password must contain at least 4 digits")]
        [DistinctCharacters]
        public string Password { internal get; set; }
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date must be valid")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [CheckAge(18)]
        public DateTime BirthDate { get; set; }

        public UserDTO()
        {
        }
        public UserDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            BirthDate = user.BirthDate;
        }
    }
}