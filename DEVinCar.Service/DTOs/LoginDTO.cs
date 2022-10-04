using DEVinCar.Service.Enums;

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
    }
}
