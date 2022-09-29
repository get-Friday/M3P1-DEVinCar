using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class AddressPatchDTO
    {
        public int Id { get; set; }
        public int CityId { get; internal set; }
        [MaxLength(150, ErrorMessage = "Street name must be a maximum of 100 characters")]
        public string Street { get; set; }
        [MaxLength(8, ErrorMessage = "The CEP must have a maximum of 8 characters")]
        public string Cep { get; set; }
        public int Number { get; set; }
        [MaxLength(255, ErrorMessage = "The Complement must have a maximum of 255 characters")]
        public string Complement { get; set; }

    }
}