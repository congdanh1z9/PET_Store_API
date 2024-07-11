using Application.ServiceReponses;
using Application.ViewModels.MeetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationService
    {
        Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetsAsync();
        Task<ServiceResponse<ViewMeetDTO>> GetMeetByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetByBuyerIDAsync(int buyerId);
        Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetByShopIDAsync(int shopId);
        Task<ServiceResponse<ViewMeetDTO>> CreateMeetAsync(CreateMeetDTO dto);
        Task<ServiceResponse<ViewMeetDTO>> UpdateMeetAsync(int Id,UpdateMeetDTO dto);
        Task<ServiceResponse<ViewMeetDTO>> CancelMeetAsync(int Id);
        
    }
}
