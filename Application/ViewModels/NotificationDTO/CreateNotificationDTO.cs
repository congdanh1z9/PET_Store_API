using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.NotificationDTO
{
    public class CreateNotificationDTO
    {
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? BuyerID { get; set; }
        public int? PostPetID { get; set; }
    }
}
