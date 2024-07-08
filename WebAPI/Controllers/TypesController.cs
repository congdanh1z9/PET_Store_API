using Application.Interfaces;
using Application.ViewModels.TypeDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/type")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _typeService.GetAllTypes();
            return Ok(result);
        }

        [HttpPost("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTypeById([FromBody] TypeIdRequest request)
        {
            var result = await _typeService.GetTypeById(request.Id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("list-by-kind")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTypesByKindId([FromBody] KindIdRequest request)
        {
            var result = await _typeService.GetTypesByKindId(request.KindId);
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateType([FromBody] TypeCreateDTO typeDto)
        {
            var result = await _typeService.CreateType(typeDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateType([FromBody] TypeUpdateRequest request)
        {
            var result = await _typeService.UpdateType(request.Id, request.TypeDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteType([FromBody] TypeIdRequest request)
        {
            var result = await _typeService.DeleteType(request.Id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}