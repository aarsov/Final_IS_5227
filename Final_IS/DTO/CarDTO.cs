using System.ComponentModel.DataAnnotations;

namespace Final_IS.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }

        [Required]
        public string LicencePlate{ get; set; }
        [Required]
        public string Model { get; set;}
        [Required]
        public string Manufacturer { get; set;}
        [Required]
        public int Year { get; set; }
    }
}
