using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class User : BaseEntity
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }

        public string? phoneNumber { get; set; }
        public virtual IEnumerable<Pet>? Pets { get; set; }

        public virtual IEnumerable<Booking>? Bookings { get; set; }
    }
}
