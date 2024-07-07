using Application.ServiceReponses;
using Application.ViewModels.TypeDTO;

namespace Application.Interfaces
{
    public interface ITypeService
    {
        Task<ServiceResponse<List<TypeViewDTO>>> GetAllTypes();
        Task<ServiceResponse<TypeViewDTO>> GetTypeById(int id);
        Task<ServiceResponse<List<TypeViewDTO>>> GetTypesByKindId(int kindId);
        Task<ServiceResponse<TypeViewDTO>> CreateType(TypeCreateDTO typeDto);
        Task<ServiceResponse<TypeViewDTO>> UpdateType(int id, TypeUpdateDTO typeDto);
        Task<ServiceResponse<bool>> DeleteType(int id);
    }
}