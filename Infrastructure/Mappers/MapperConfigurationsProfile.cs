using Application.ViewModels.AccountDTO;
using AutoMapper;
using Domain.Entitys;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            //CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap<Account, AccountViewDTO>().ReverseMap();
        }

    }
}
