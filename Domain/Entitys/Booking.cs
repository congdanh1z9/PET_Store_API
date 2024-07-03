using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Booking : BaseEntity
    {
        public DateTime? bookingDate { get; set; }
        public string? status { get; set; }
        public int? userId { get; set; }
        public int? petId { get; set; }
        public virtual User? User { get; set; }  
        public virtual Pet? Pet { get; set; }
        public virtual IEnumerable<BookingDetail>? BookingDetails { get; set; }
    }
}
