using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Pet: BaseEntity
    {
        public string? name { get; set; }
        public int? age { get; set; } 
        public int? typeId { get; set; }
        public int? userId { get; set; }

        public virtual User User { get; set; }
        public virtual Type Type { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }

    }
}
