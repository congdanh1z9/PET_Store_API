using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.ImageDTO;
using AutoMapper;
using Domain.Entitys;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ImageViewDTO>>> GetAllImages()
        {
            var response = new ServiceResponse<List<ImageViewDTO>>();
            var images = await _unitOfWork.ImageRepository.GetAllAsync();
            response.Data = _mapper.Map<List<ImageViewDTO>>(images);
            response.Success = true;
            response.Message = "Images retrieved successfully.";
             
            return response;
        }

        public async Task<ServiceResponse<ImageViewDTO>> GetImageById(int id)
        {
            var response = new ServiceResponse<ImageViewDTO>();
            var image = await _unitOfWork.ImageRepository.GetByIdAsync(id);
            if (image == null)
            {
                response.Success = false;
                response.Message = "Image not found.";
                 
                return response;
            }
            response.Data = _mapper.Map<ImageViewDTO>(image);
            response.Success = true;
            response.Message = "Image retrieved successfully.";
             
            return response;
        }

        public async Task<ServiceResponse<List<ImageViewDTO>>> GetImagesByPostPetId(int postPetId)
        {
            var response = new ServiceResponse<List<ImageViewDTO>>();
            var images = await _unitOfWork.ImageRepository.GetImagesByPostPetId(postPetId);
            response.Data = _mapper.Map<List<ImageViewDTO>>(images);
            response.Success = true;
            response.Message = "Images retrieved successfully.";
             
            return response;
        }

        public async Task<ServiceResponse<ImageViewDTO>> CreateImage(ImageCreateDTO imageDto)
        {
            var response = new ServiceResponse<ImageViewDTO>();
            var image = _mapper.Map<Image>(imageDto);
            await _unitOfWork.ImageRepository.AddAsync(image);
            await _unitOfWork.SaveChangeAsync();
            response.Data = _mapper.Map<ImageViewDTO>(image);
            response.Success = true;
            response.Message = "Image created successfully.";
            return response;
        }

        public async Task<ServiceResponse<ImageViewDTO>> UpdateImage(int id, ImageUpdateDTO imageDto)
        {
            var response = new ServiceResponse<ImageViewDTO>();
            var image = await _unitOfWork.ImageRepository.GetByIdAsync(id);
            if (image == null)
            {
                response.Success = false;
                response.Message = "Image not found.";
                 
                return response;
            }
            _mapper.Map(imageDto, image);
            await _unitOfWork.ImageRepository.UpdateAsync(image);
            await _unitOfWork.SaveChangeAsync();
            response.Data = _mapper.Map<ImageViewDTO>(image);
            response.Success = true;
            response.Message = "Image updated successfully.";
             
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteImage(int id)
        {
            var response = new ServiceResponse<bool>();
            var image = await _unitOfWork.ImageRepository.GetByIdAsync(id);
            if (image == null)
            {
                response.Success = false;
                response.Message = "Image not found.";
                 
                return response;
            }
            await _unitOfWork.ImageRepository.DeleteAsync(image);
            await _unitOfWork.SaveChangeAsync();
            response.Data = true;
            response.Success = true;
            response.Message = "Image deleted successfully.";
             
            return response;
        }
    }
}