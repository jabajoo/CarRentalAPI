using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Entities
{
    public partial class Category
    {
        public Category()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        [Column("Category")]
        public string CategoryName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
