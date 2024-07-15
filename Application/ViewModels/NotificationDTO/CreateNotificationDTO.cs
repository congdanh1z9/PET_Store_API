﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.NotificationDTO
{
    public class CreateNotificationDTO
    {
        public int? requestID { get; set; }
        public string? SellerName { get; set; }
        public string? SellerPhone { get; set; }
        public string? Address { get; set; }
        public DateTime? MeetDate { get; set; }
    }
}
