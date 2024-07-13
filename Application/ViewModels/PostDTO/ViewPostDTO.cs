using Application.ViewModels.ImageDTO;
using Application.ViewModels.MeetDTO;
using Application.ViewModels.TypeDTO;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.PostDTO
{
    public class ViewPostDTO
    {
        public int? ShopID { get; set; }
        public string? ShopName { get; set; }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public int? HealthStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Isvalid { get; set; }
        public virtual IEnumerable<ViewNotificationDTO>? MeetDTOs { get; set; }
        public virtual IEnumerable<ImageViewDTO>? ImageDTOs { get; set; }
        
    }
}
