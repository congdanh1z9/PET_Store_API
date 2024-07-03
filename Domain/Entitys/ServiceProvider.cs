using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class ServiceProvider : BaseEntity
    {
        public string? name { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? address { get; set; }

        public virtual IEnumerable<Service> Services { get; set; }
    }
}
