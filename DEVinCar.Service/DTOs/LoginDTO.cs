using DEVinCar.Service.Enums;
using DEVinCar.Service.Models;

namespace DEVinCar.Service.DTOs
{
    public class LoginDTO
    {
        public int Id { get; internal set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public Permissions Role { get; set; }

        public LoginDTO()
        {
        }
        public LoginDTO(User user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            BirthDate = user.BirthDate;
            Role = user.Role;
        }
    }
}
