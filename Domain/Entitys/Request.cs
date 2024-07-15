using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitys
{
    public class Request : BaseEntity
    {
        public int? ShopId { get; set; }
        public int? BuyerId { get; set; }
        public int? PostId { get; set; }

    }
}
