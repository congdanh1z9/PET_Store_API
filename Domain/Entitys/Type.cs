﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Type : BaseEntity
    {
        public string? Name { get; set; }
        public int? KindId { get; set; } 
        public virtual Kind? Kind { get; set; } 
        public virtual IEnumerable<PostPet> PostPets { get; set; }
    }
}
