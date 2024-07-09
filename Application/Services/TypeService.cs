using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.TypeDTO;
using AutoMapper;
using Domain.Entitys;

namespace Application.Services
{
	public class TypeService : ITypeService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<List<TypeViewDTO>>> GetAllTypes()
		{
			var response = new ServiceResponse<List<TypeViewDTO>>();
			var types = await _unitOfWork.TypeRepository.GetAllAsync();
			response.Data = _mapper.Map<List<TypeViewDTO>>(types);
			response.Success = true;
			response.Message = "Types retrieved successfully.";
			response.Status = "200";
			return response;
		}

		public async Task<ServiceResponse<TypeViewDTO>> GetTypeById(int id)
		{
			var response = new ServiceResponse<TypeViewDTO>();
			var type = await _unitOfWork.TypeRepository.GetByIdAsync(id);
			if (type == null)
			{
				response.Success = false;
				response.Message = "Type not found.";
				response.Status = "404";
				return response;
			}
			response.Data = _mapper.Map<TypeViewDTO>(type);
			response.Success = true;
			response.Message = "Type retrieved successfully.";
			response.Status = "200";
			return response;
		}

		public async Task<ServiceResponse<List<TypeViewDTO>>> GetTypesByKindId(int kindId)
		{
			var response = new ServiceResponse<List<TypeViewDTO>>();
			var types = await _unitOfWork.TypeRepository.GetTypesByKindId(kindId);
			if (types == null || !types.Any())
			{
				response.Success = false;
				response.Message = "No types found for the given KindId.";
				response.Status = "404";
				return response;
			}
			response.Data = _mapper.Map<List<TypeViewDTO>>(types);
			response.Success = true;
			response.Message = "Types retrieved successfully.";
			response.Status = "200";
			return response;
		}

		public async Task<ServiceResponse<TypeViewDTO>> CreateType(TypeCreateDTO typeDto)
		{
			var response = new ServiceResponse<TypeViewDTO>();
			var type = _mapper.Map<Domain.Entitys.Type>(typeDto);
			await _unitOfWork.TypeRepository.AddAsync(type);
			await _unitOfWork.SaveChangeAsync();
			response.Data = _mapper.Map<TypeViewDTO>(type);
			response.Success = true;
			response.Status = "201";
			response.Message = "Type created successfully.";
			return response;
		}

		public async Task<ServiceResponse<TypeViewDTO>> UpdateType(int id, TypeUpdateDTO typeDto)
		{
			var response = new ServiceResponse<TypeViewDTO>();
			var type = await _unitOfWork.TypeRepository.GetByIdAsync(id);
			if (type == null)
			{
				response.Success = false;
				response.Message = "Type not found.";
				response.Status = "404";
				return response;
			}
			_mapper.Map(typeDto, type);
			await _unitOfWork.TypeRepository.UpdateAsync(type);
			await _unitOfWork.SaveChangeAsync();
			response.Data = _mapper.Map<TypeViewDTO>(type);
			response.Success = true;
			response.Status = "200";
			response.Message = "Type updated successfully.";
			return response;
		}

		public async Task<ServiceResponse<bool>> DeleteType(int id)
		{
			var response = new ServiceResponse<bool>();
			var type = await _unitOfWork.TypeRepository.GetByIdAsync(id);
			if (type == null)
			{
				response.Success = false;
				response.Message = "Type not found.";
				response.Status = "404";
				return response;
			}
			await _unitOfWork.TypeRepository.DeleteAsync(type);
			await _unitOfWork.SaveChangeAsync();
			response.Data = true;
			response.Success = true;
			response.Message = "Type deleted successfully.";
			response.Status = "200";
			return response;
		}
	}
}