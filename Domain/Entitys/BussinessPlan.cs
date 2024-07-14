using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class BussinessPlan : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? AmountDay { get; set; }

        public virtual IEnumerable<Shop>? Shops { get; set; }
    }
}
