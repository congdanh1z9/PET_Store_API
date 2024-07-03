using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Type : BaseEntity
    {
        public string? Name { get; set; }
        public virtual IEnumerable<Pet> Pets { get; set; }
    }
}
