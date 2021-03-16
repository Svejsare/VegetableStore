﻿using System.ComponentModel.DataAnnotations;

namespace VegetableWarehouse.Models
{
    public class VegetableRequestUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}