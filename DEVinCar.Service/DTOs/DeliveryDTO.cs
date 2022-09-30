using DEVinCar.Service.Models;

namespace DEVinCar.Service.DTOs;

public class DeliveryDTO
{
    public int Id { get; internal set; }
    public DateTime? DeliveryForecast { get; set; }
    public int AddressId { get; set; }
    public int SaleId { get; set; }

    public DeliveryDTO()
    {
    }
    public DeliveryDTO(Delivery delivery)
    {
        Id = delivery.Id;
        DeliveryForecast = delivery.DeliveryForecast;
        AddressId = delivery.AddressId;
        SaleId = delivery.SaleId;
    }
}