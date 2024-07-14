using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ShopDTO
{
    public class UpdateShopDTO
    {
        public string? Name { get; set; }
        public int? BusinessPlanId { get; set; }
        public DateTime? DateBusinessPlan { get; set; }
    }
}
