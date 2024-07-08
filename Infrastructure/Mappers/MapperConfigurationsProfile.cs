using Application.ViewModels.AccountDTO;
using Application.ViewModels.BusinessPlanDTO;
using Application.ViewModels.ImageDTO;
using Application.ViewModels.MeetDTO;
using Application.ViewModels.PostDTO;
using Application.ViewModels.TypeDTO;
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
            CreateMap<BussinessPlan, BusinessPlanViewDTO>().ReverseMap();
            CreateMap<BussinessPlan, BusinessPlanCreateDTO>().ReverseMap();
            CreateMap<BussinessPlan, BusinessPlanUpdateDTO>().ReverseMap();
            CreateMap<Image, ImageViewDTO>().ReverseMap();
            CreateMap<Image, ImageCreateDTO>().ReverseMap();
            CreateMap<Image, ImageUpdateDTO>().ReverseMap();
            CreateMap<Domain.Entitys.Type, TypeViewDTO>().ReverseMap();
            CreateMap<Domain.Entitys.Type, TypeCreateDTO>().ReverseMap();
            CreateMap<Domain.Entitys.Type, TypeUpdateDTO>().ReverseMap();
            CreateMap<Account, AccountViewDTO>().ReverseMap();
            CreateMap<RegisterDTO, Account>();
            CreateMap<ChangePasswordDTO, Account>();

            CreateMap<Meet, CreateMeetDTO>().ReverseMap();
            CreateMap<Meet, UpdateMeetDTO>().ReverseMap();
            CreateMap<Meet, ViewMeetDTO>().ReverseMap();
            CreateMap<List<Meet>, List<ViewMeetDTO>>().ReverseMap();

            CreateMap<PostPet, CreatePostDTO>().ReverseMap();
            CreateMap<Meet, UpdatePostDTO>().ReverseMap();
            CreateMap<Meet, ViewPostDTO>().ReverseMap();
            CreateMap<List<Meet>, List<ViewPostDTO>>().ReverseMap();
        }

    }
}
