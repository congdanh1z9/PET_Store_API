using Application.Interfaces;
using Application.Repositories;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositorys
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
            : base(context, timeService, claimsService)
        {
        }
    }
}