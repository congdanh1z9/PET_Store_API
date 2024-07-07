using Application.ServiceReponses;
using Application.ViewModels.ImageDTO;

namespace Application.Interfaces
{
    public interface IImageService
    {
        Task<ServiceResponse<List<ImageViewDTO>>> GetAllImages();
        Task<ServiceResponse<ImageViewDTO>> GetImageById(int id);
        Task<ServiceResponse<List<ImageViewDTO>>> GetImagesByPostPetId(int postPetId);
        Task<ServiceResponse<ImageViewDTO>> CreateImage(ImageCreateDTO imageDto);
        Task<ServiceResponse<ImageViewDTO>> UpdateImage(int id, ImageUpdateDTO imageDto);
        Task<ServiceResponse<bool>> DeleteImage(int id);
    }
}