﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.NotificationDTO
{
    public class CreateNotificationDTO
    {
        public string? ShopName { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public float? Money { get; set; }
        public DateTime? MeetDate { get; set; }
        public int? BuyerId { get; set; }
    }
}
