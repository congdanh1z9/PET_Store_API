using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class BookingDetail : BaseEntity
    {
        public int? bookingId { get; set; }
        public int? serviceId { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Service Service { get; set; }
    }
}
