
using Application.ServiceReponses;
using Application.ViewModels.RequestDTO;

namespace Application.Interfaces
{
    public interface IRequestService
    {
        Task<ServiceResponse<ViewRequestDTO>> CreateRequestAsync(CreateRequestDTO dto);
    }
}

