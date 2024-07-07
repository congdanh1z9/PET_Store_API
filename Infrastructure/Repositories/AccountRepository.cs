// Trong AccountRepository.cs
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Infrastructures.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public async Task<Account> GetFirstOrDefaultAsync(Expression<Func<Account, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
