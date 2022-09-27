﻿using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Service.DTOs
{
    public class SaleDTO
    {
        [Required(ErrorMessage = "The BuyerId is required.")]
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
