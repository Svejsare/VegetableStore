using System.ComponentModel.DataAnnotations;

namespace VegetableWarehouse.Models
{
    public class VegetableRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}