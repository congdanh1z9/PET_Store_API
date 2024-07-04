using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Account : BaseEntity
    {
        public string? fullName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public string? role {  get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Shop? Shop { get; set; }
    }
}
