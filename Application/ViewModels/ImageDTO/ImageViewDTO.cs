using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ImageDTO
{
    public class ImageViewDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? PostPetId { get; set; }
    }
}
