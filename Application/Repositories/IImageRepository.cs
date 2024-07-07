using Domain.Entitys;

namespace Application.Repositories
{
    public interface IImageRepository : IGenericRepository<Image>
    {
        Task<IEnumerable<Image>> GetImagesByPostPetId(int postPetId);
    }
}