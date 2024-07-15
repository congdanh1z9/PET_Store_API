using Application.Interfaces;
using Application.ViewModels.PostDTO;
using Application.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RequestsController : BaseController
    {
        private readonly IRequestService _requestService;
        public RequestsController(IRequestService requestService) 
        {
            _requestService = requestService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDTO createDto)
        {
            var c = await _requestService.CreateRequestAsync(createDto);
            return Ok(c);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllRequest()
        {
            var result = await _requestService.GetRequestsAsync();
            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllRequestByBuyerID([FromBody] SearchPostDTO searchPostDTO)
        {
            var result = await _requestService.GetRequestByBuyerIDAsync(searchPostDTO.Id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewRequestByID([FromBody] SearchPostDTO searchPostDTO)
        {
            var result = await _requestService.GetRequestByIdAsync(searchPostDTO.Id);
            return Ok(result);
        }

    }
}
