using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Image : BaseEntity
    {
        public string? ImageUrl { get; set; }
        public int? PostPetId { get; set;}

        public virtual PostPet? PostPet { get; set; }
    }
}
