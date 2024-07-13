using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.NotificationDTO
{
    public class ViewNotificationDTO
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
        public int? BuyerID { get; set; }
        public int? PostPetID { get; set; }

        public virtual PostPet? PostPet { get; set; }
        public virtual Buyer? Buyer { get; set; }
    }
}
