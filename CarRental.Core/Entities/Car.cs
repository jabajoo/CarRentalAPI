using CarRental.Core.Extenssions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public partial class Car 
    {
       
        public Car()
        {
            this.Bookings = new List<Booking>();
        }
        public string RegistrationPlate { get; set; }
        public decimal BaseDayPrice { get; set; }
        public decimal BaseKmPrice { get; set; }
        public decimal Mileage { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public CarType GetCategoryName()
        {
            return Category.CategoryName.ParseEnum<CarType>();
        }
    }
}
