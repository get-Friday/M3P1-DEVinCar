using DEVinCar.Service.DTOs;

namespace DEVinCar.Service.Models;
public class Delivery
{
    public int Id { get; internal set; }
    public DateTime DeliveryForecast { get; set; }
    public int AddressId { get; set; }
    public int SaleId { get; set; }

    public virtual Address Address { get; set; }
    public virtual Sale Sale { get; set; }

    public Delivery()
    {
    }
    public Delivery(DeliveryDTO delivery)
    {
        Id = delivery.Id;
        DeliveryForecast = delivery.DeliveryForecast ??= DateTime.Now.AddDays(7);
        AddressId = delivery.AddressId;
        SaleId = delivery.SaleId;
    }
}
