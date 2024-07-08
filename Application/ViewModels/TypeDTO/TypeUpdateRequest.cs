using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.TypeDTO
{
    public class TypeUpdateRequest
    {
        public int Id { get; set; }
        public TypeUpdateDTO TypeDto { get; set; }
    }
}
