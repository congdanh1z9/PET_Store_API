using Domain.Entitys;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetFirstOrDefaultAsync(Expression<Func<Account, bool>> predicate);
    }
}