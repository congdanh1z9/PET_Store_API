using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Infrastructures.Repositorys;

namespace Infrastructures.Repositories
{
    public class BusinessPlanRepository : GenericRepository<BussinessPlan>, IBusinessPlanRepository
    {
        public BusinessPlanRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }
    }
}