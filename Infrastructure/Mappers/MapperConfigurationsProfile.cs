using Application.ViewModels.AccountDTO;
using Application.ViewModels.BusinessPlanDTO;
using Application.ViewModels.ImageDTO;
using Application.ViewModels.NotificationDTO;
using Application.ViewModels.PostDTO;
using Application.ViewModels.ShopDTO;
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
            CreateMap<Account, UpdateAccountDTO>().ReverseMap();
            CreateMap<Account , LoginResponseDTO>().ReverseMap();
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

            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();
            CreateMap<Notification, ViewNotificationDTO>().ReverseMap();

            CreateMap<PostPet, CreatePostDTO>().ReverseMap();
            CreateMap<PostPet, UpdatePostDTO>().ReverseMap();
            CreateMap<PostPet, ViewPostDTO>().ReverseMap();

            CreateMap<Shop, ShopViewDTO>().ReverseMap();
            CreateMap<Shop, CreateShopDTO>().ReverseMap();
            CreateMap<Shop, UpdateShopDTO>().ReverseMap();
        }

    }
}
