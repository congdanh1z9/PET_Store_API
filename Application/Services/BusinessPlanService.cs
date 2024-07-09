using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.BusinessPlanDTO;
using AutoMapper;
using Domain.Entitys;

namespace Application.Services
{
	public class BusinessPlanService : IBusinessPlanService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BusinessPlanService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<List<BusinessPlanViewDTO>>> GetAllBusinessPlans()
		{
			var response = new ServiceResponse<List<BusinessPlanViewDTO>>();
			var businessPlans = await _unitOfWork.BusinessPlanRepository.GetAllAsync();
			response.Data = _mapper.Map<List<BusinessPlanViewDTO>>(businessPlans);
			response.Success = true;
			response.Status = "200";
			response.Message = "Business plans retrieved successfully.";
			//return
			return response;
		}

		public async Task<ServiceResponse<BusinessPlanViewDTO>> GetBusinessPlanById(int id)
		{
			var response = new ServiceResponse<BusinessPlanViewDTO>();
			var businessPlan = await _unitOfWork.BusinessPlanRepository.GetByIdAsync(id);
			if (businessPlan == null)
			{
				response.Success = false;
				response.Status = "404";
				response.Message = "Business plan not found.";
				return response;
			}
			response.Data = _mapper.Map<BusinessPlanViewDTO>(businessPlan);
			response.Success = true;
			response.Status = "200";
			response.Message = "Business plan retrieved successfully.";
			return response;
		}

		public async Task<ServiceResponse<BusinessPlanViewDTO>> CreateBusinessPlan(BusinessPlanCreateDTO businessPlanDto)
		{
			var response = new ServiceResponse<BusinessPlanViewDTO>();
			var businessPlan = _mapper.Map<BussinessPlan>(businessPlanDto);
			await _unitOfWork.BusinessPlanRepository.AddAsync(businessPlan);
			await _unitOfWork.SaveChangeAsync();
			response.Data = _mapper.Map<BusinessPlanViewDTO>(businessPlan);
			response.Success = true;
			response.Status = "201";
			response.Message = "Business plan created successfully.";
			return response;
		}

		public async Task<ServiceResponse<BusinessPlanViewDTO>> UpdateBusinessPlan(int id, BusinessPlanUpdateDTO businessPlanDto)
		{
			var response = new ServiceResponse<BusinessPlanViewDTO>();
			var businessPlan = await _unitOfWork.BusinessPlanRepository.GetByIdAsync(id);
			if (businessPlan == null)
			{
				response.Success = false;
				response.Status = "404";
				response.Message = "Business plan not found.";
				return response;
			}
			_mapper.Map(businessPlanDto, businessPlan);
			_unitOfWork.BusinessPlanRepository.Update(businessPlan);
			await _unitOfWork.SaveChangeAsync();
			response.Data = _mapper.Map<BusinessPlanViewDTO>(businessPlan);
			response.Success = true;
			response.Status = "200";
			response.Message = "Business plan updated successfully.";
			return response;
		}

		public async Task<ServiceResponse<bool>> DeleteBusinessPlan(int id)
		{
			var response = new ServiceResponse<bool>();
			var businessPlan = await _unitOfWork.BusinessPlanRepository.GetByIdAsync(id);
			if (businessPlan == null)
			{
				response.Success = false;
				response.Status = "404";
				response.Message = "Business plan not found.";
				return response;
			}
			await _unitOfWork.BusinessPlanRepository.DeleteAsync(businessPlan);
			await _unitOfWork.SaveChangeAsync();
			response.Data = true;
			response.Success = true;
			response.Status = "200";
			response.Message = "Business plan deleted successfully.";
			return response;
		}
	}
}