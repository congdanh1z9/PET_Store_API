using Application.Interfaces;
using Application.ViewModels.TypeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : BaseController
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _typeService.GetAllTypes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var result = await _typeService.GetTypeById(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("kind/{kindId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTypesByKindId(int kindId)
        {
            var result = await _typeService.GetTypesByKindId(kindId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateType([FromBody] TypeCreateDTO typeDto)
        {
            var result = await _typeService.CreateType(typeDto);
            return CreatedAtAction(nameof(GetTypeById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateType(int id, [FromBody] TypeUpdateDTO typeDto)
        {
            var result = await _typeService.UpdateType(id, typeDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteType(int id)
        {
            var result = await _typeService.DeleteType(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}