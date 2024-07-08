using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostDTO
{
    public class CreatePostDTO
    {
        public string? Name { get; set; }
        public int? TypeId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? HealthStatus { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
