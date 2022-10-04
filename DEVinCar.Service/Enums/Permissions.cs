using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.Enums
{
    public enum Permissions
    {
        [Display(Name = "Gerente")]
        Gerente,

        [Display(Name = "Vendedor")]
        Vendedor,

        [Display(Name = "Comprador")]
        Comprador,
    }
}
