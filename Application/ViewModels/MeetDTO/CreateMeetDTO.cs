using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MeetDTO
{
    public class CreateMeetDTO
    {
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? BuyerID { get; set; }
        public int? PostPetID { get; set; }
    }
}
