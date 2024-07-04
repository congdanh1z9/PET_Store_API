using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class PostPet : BaseEntity
    {
        public int? ShopID { get; set; }
        public string? Name { get; set; }
        public int? TypeId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? HealthStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Isvalid { get; set; }

        public virtual Shop? Shop { get; set; }
        public virtual IEnumerable<Meet>? Meets { get; set; }
        public virtual IEnumerable<Image>? Images { get; set; } 
        public virtual Type? Type { get; set; } 

    }
}
