using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Dtos
{
    public class ReturnCarDto
    {
        [Required]
        public string BookingNumber { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public decimal Mileage { get; set; }
    }
}
