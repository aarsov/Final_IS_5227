
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_IS.Models
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
       public int Id { get; set; }
        public string LicencePlate { get; set; }

        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }

    }
}

