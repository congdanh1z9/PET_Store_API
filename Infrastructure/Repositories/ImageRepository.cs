using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Infrastructures.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
        }

        public async Task<IEnumerable<Image>> GetImagesByPostPetId(int postPetId)
        {
            return await _dbSet.Where(i => i.PostPetId == postPetId).ToListAsync();
        }
    }
}