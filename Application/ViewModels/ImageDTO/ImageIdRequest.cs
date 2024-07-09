using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ImageDTO
{
	public class ImageIdRequest
	{
		public int Id { get; set; }
	}

	public class PostPetIdRequest
	{
		public int PostPetId { get; set; }
	}

	public class ImageUpdateRequest
	{
		public int Id { get; set; }
		public ImageUpdateDTO ImageDto { get; set; }
	}
}
