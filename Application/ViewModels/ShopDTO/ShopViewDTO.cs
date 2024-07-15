using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ShopDTO
{
    public class ShopViewDTO
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public string ProfileImage { get; set; }
        public int? BusinessPlanId { get; set; }
        public DateTime? DateBusinessPlan { get; set; }
    }
}
