using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Models
{
    public class User
    {
        public int Id { get; internal set; }
        public string Email { get; set; }
        public string Password { internal get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public User()
        {
        }
        public User(int id, string email, string password, string name, DateTime birthDate)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            BirthDate = birthDate;
        }
        public User(UserDTO user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            BirthDate = user.BirthDate;
        }
    }
}