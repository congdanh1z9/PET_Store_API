using Application.Interfaces;
using Application.Repositories;
using Azure.Core;
using Infrastructures.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class RequestRepository : GenericRepository<Domain.Entitys.Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}
