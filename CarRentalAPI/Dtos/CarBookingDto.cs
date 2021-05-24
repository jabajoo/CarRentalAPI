using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalAPI.Dtos
{
    public class CarBookingDto
    {
        [Required]
        public string CarRegistrationNumber { get; set; }
        [Required]
        public string CustomerId { get; set; }
        
        public string BookingNumber { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        
    }
}
