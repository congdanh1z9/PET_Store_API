using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Infrastructures.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class TypeRepository : GenericRepository<Domain.Entitys.Type>, ITypeRepository
    {
        public TypeRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
        }

        public async Task<IEnumerable<Domain.Entitys.Type>> GetTypesByKindId(int kindId)
        {
            return await _dbSet.Where(t => t.KindId == kindId).ToListAsync();
        }
    }
}