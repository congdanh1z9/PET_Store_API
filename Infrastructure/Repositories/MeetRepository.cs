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
    public class MeetRepository : GenericRepository<Meet>, IMeetRepository
    {
        public MeetRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
