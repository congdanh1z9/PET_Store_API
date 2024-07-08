using Application.Interfaces;
using Application.ViewModels.MeetDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class meetsController : ControllerBase
    {
        private readonly IMeetService _meetService;
        public meetsController(IMeetService meetService )
        {
            _meetService = meetService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllMeet()
        {
            var result = await _meetService.GetMeetsAsync();
            return Ok(result);
        }

        //[Authorize(Roles = "Buyer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllMeetByBuyerID(SearchMeetDTO searchMeetDTO)
        {
            var result = await _meetService.GetMeetByBuyerIDAsync(searchMeetDTO.Id);
            return Ok(result);
        }

        //[Authorize(Roles = "Buyer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllMeetByShopID(SearchMeetDTO searchMeetDTO)
        {
            var result = await _meetService.GetMeetByShopIDAsync(searchMeetDTO.Id);
            return Ok(result);
        }

        //[Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewMeetByID(SearchMeetDTO searchMeetDTO)
        {
            var result = await _meetService.GetMeetByIdAsync(searchMeetDTO.Id);
            return Ok(result);
        }

        //[Authorize (Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMeet([FromBody] CreateMeetDTO createDto)
        {
            var c = await _meetService.CreateMeetAsync(createDto);
            return Ok(c);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMeet([FromBody] UpdateMeetDTO updateDto)
        {
            var c = await _meetService.UpdateMeetAsync(updateDto.Id, updateDto);
            return Ok(c);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelMeet(SearchMeetDTO searchMeetDTO)
        {
            var c = await _meetService.CancelMeetAsync(searchMeetDTO.Id);
            return Ok(c);
        }
    }
}
