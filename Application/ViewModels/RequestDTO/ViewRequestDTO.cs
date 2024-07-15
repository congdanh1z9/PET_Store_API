using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.RequestDTO
{
    public class ViewRequestDTO
    {
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public int? BuyerId { get; set; }
        public int? PostId { get; set; }
        public float? Money { get; set; }
        public string? sellerName { get; set; }
        public string? sellerPhone { get; set; }
    }
}
