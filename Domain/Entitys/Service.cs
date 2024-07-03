using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Service : BaseEntity
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
        public int? serviceProviderId {get;set;}
        public virtual ServiceProvider ServiceProvider { get; set; }
        public virtual BookingDetail BookingDetail { get; set; }
    }
}
