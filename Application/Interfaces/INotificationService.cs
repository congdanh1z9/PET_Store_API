using Application.ServiceReponses;
using Application.ViewModels.NotificationDTO;
namespace Application.Interfaces
{
    public interface INotificationService
    {
        Task<ServiceResponse<IEnumerable<ViewNotificationDTO>>> GetNotificationsAsync();
        Task<ServiceResponse<ViewNotificationDTO>> GetNotificationByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewNotificationDTO>>> GetNotificationByBuyerIDAsync(int buyerId);
        //Task<ServiceResponse<IEnumerable<ViewNotificationDTO>>> GetMeetByShopIDAsync(int shopId);
        Task<ServiceResponse<ViewNotificationDTO>> CreateNotificationAsync(CreateNotificationDTO dto);
        Task<ServiceResponse<ViewNotificationDTO>> UpdateNotificationAsync(int Id,UpdateNotificationDTO dto);
        Task<ServiceResponse<ViewNotificationDTO>> DeleteNotificationAsync(int Id);
        
    }
}
