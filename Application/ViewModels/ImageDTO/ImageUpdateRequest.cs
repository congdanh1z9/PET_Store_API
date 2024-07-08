using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ImageDTO
{
    public class ImageUpdateRequest
    {
        public int Id { get; set; }
        public ImageUpdateDTO ImageDto { get; set; }
    }
}
