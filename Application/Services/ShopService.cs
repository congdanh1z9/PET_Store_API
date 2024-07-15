using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.ShopDTO;
using AutoMapper;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ShopViewDTO>>> ViewAllShops()
        {
            var response = new ServiceResponse<List<ShopViewDTO>>();
            var shops = await _unitOfWork.ShopRepository.GetAllAsync();
            var dtos = _mapper.Map<List<ShopViewDTO>>(shops);
            response.Data = dtos;
            return response;
        }

        public async Task<ServiceResponse<string>> CreateShop(CreateShopDTO createShopDTO)
        {
            var response = new ServiceResponse<string>();

            var newShop = new Shop
            {
                Name = createShopDTO.Name,
                BusinessPlanId = createShopDTO.BusinessPlanId,
                DateBusinessPlan = createShopDTO.DateBusinessPlan
            };

            await _unitOfWork.ShopRepository.AddAsync(newShop);
            await _unitOfWork.SaveChangeAsync();

            response.Data = "Shop created successfully.";
            return response;
        }

        public async Task<ServiceResponse<string>> UpdateShop(int id, UpdateShopDTO updateShopDTO)
        {
            var response = new ServiceResponse<string>();

            var shop = await _unitOfWork.ShopRepository.GetByIdAsync(id);

            if (shop == null)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Shop not found.";
                return response;
            }
            shop.Name = updateShopDTO.Name;
            shop.BusinessPlanId = updateShopDTO.BusinessPlanId;
            shop.DateBusinessPlan = updateShopDTO.DateBusinessPlan;

            _unitOfWork.ShopRepository.Update(shop);
            await _unitOfWork.SaveChangeAsync();

            response.Data = "Shop updated successfully.";
            return response;
        }
    }
}
