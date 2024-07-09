using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TypeDTO
{
	public class TypeIdRequest
	{
		public int Id { get; set; }
	}

	public class KindIdRequest
	{
		public int KindId { get; set; }
	}

	public class TypeUpdateRequest
	{
		public int Id { get; set; }
		public TypeUpdateDTO TypeDto { get; set; }
	}
}
