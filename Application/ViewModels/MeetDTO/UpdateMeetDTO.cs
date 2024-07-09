using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.MeetDTO
{
    public class UpdateMeetDTO
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Status { get; set; }
    }
}
