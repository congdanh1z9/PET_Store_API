using Application.Interfaces;
using Application.ViewModels.NotificationDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllNotification()
        {
            var result = await _notificationService.GetNotificationsAsync();
            return Ok(result);
        }

        //[Authorize(Roles = "Buyer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllNotificationByBuyerID(SearchNotificationDTO searchMeetDTO)
        {
            var result = await _notificationService.GetNotificationByBuyerIDAsync(searchMeetDTO.Id);
            return Ok(result);
        }

        //[Authorize(Roles = "Buyer")]
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> ViewAllNotificationByShopID(SearchNotificationDTO searchMeetDTO)
        //{
        //    var result = await _notificationService.GetMeetByShopIDAsync(searchMeetDTO.Id);
        //    return Ok(result);
        //}

        //[Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewNotificationByID(SearchNotificationDTO searchMeetDTO)
        {
            var result = await _notificationService.GetNotificationByIdAsync(searchMeetDTO.Id);
            return Ok(result);
        }

        //[Authorize (Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDTO createDto)
        {
            var c = await _notificationService.CreateNotificationAsync(createDto);
            return Ok(c);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateNotification([FromBody] UpdateNotificationDTO updateDto)
        {
            var c = await _notificationService.UpdateNotificationAsync(updateDto.Id, updateDto);
            return Ok(c);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteNotification(SearchNotificationDTO searchMeetDTO)
        {
            var c = await _notificationService.DeleteNotificationAsync(searchMeetDTO.Id);
            return Ok(c);
        }
    }
}
