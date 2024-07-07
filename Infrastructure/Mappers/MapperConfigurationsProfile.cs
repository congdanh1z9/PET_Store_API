using AutoMapper;
using Domain.Entitys;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<Account, AccountViewDTO>().ReverseMap();
        }
    }
}
