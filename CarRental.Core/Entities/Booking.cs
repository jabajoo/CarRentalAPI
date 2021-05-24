using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public partial class Booking 
    {
        public string BookingNumber { get; set; }
        
        public DateTime PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? Price { get; set; }
        public string CarRegistrationPlate { get; set; }
        public string CustomerRegistrationId { get; set; }

        [NotMapped]
        public decimal TripKm { get; set; }

        public virtual Car Car{get; set;}
    }
}
