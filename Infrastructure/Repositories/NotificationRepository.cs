using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Infrastructures.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class NotificationRepository : GenericRepository<Notifition>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
