using DEVinCar.Controller.Models;
namespace DEVinCar.Controller.ViewModels;
public class CarViewModel
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int? Amount { get; set; }
    public decimal Total { get; set; }
    public CarViewModel()
    {
    }
}