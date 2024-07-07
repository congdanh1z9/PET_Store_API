
namespace Application.Repositories
{
    public interface ITypeRepository : IGenericRepository<Domain.Entitys.Type>
    {
        Task<IEnumerable<Domain.Entitys.Type>> GetTypesByKindId(int kindId);
    }
}