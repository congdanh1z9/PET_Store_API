using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BusinessPlanDTO
{
    public class BusinessPlanUpdateRequest
    {
        public int Id { get; set; }
        public BusinessPlanUpdateDTO BusinessPlanDto { get; set; }
    }
}
