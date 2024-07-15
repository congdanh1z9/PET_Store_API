
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using Application.ViewModels.RequestDTO;

namespace Application.Interfaces
{
    public interface IRequestService
    {
        Task<ServiceResponse<ViewRequestDTO>> CreateRequestAsync(CreateRequestDTO dto);
        Task<ServiceResponse<IEnumerable<ViewRequestDTO>>> GetRequestsAsync();
        Task<ServiceResponse<ViewRequestDTO>> GetRequestByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewRequestDTO>>> GetRequestByShopIDAsync(int Id);
        Task<ServiceResponse<ViewRequestDTO>> DeletePostAsync(int Id);
    }
}

