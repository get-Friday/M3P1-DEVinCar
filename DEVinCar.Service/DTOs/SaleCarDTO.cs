﻿using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class SaleCarDTO
    {
        public int CarId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int SaleId { get; set; }
    }
}
