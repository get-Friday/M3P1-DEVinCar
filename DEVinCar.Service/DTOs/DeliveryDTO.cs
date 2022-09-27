namespace DEVinCar.Service.DTOs;

public class DeliveryDTO
{
    public int Id { get; internal set; }
    public DateTime? DeliveryForecast { get; set; }
    public int? AddressId { get; set; }
    public int SaleId { get; internal set; }
}