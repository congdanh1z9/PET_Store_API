using Application.Interfaces;
using Application.ViewModels.TypeDTO;
using Domain.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/type")]
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
		public async Task<IActionResult> GetAllTypes()
		{
			var result = await _typeService.GetAllTypes();
			return Ok(result);
		}

		[HttpPost("get-by-id")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetTypeById([FromBody] TypeIdRequest request)
		{
			var result = await _typeService.GetTypeById(request.Id);
			return Ok(result);
		}

		[HttpPost("get-by-kind-id")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetTypesByKindId([FromBody] KindIdRequest request)
		{
			var result = await _typeService.GetTypesByKindId(request.KindId);
			return Ok(result);
		}

		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateType([FromBody] TypeCreateDTO typeDto)
		{
			var result = await _typeService.CreateType(typeDto);
			return Ok(result);
		}

		[HttpPut("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> UpdateType([FromBody] TypeUpdateRequest request)
		{
			var result = await _typeService.UpdateType(request.Id, request.TypeDto);
			if (!result.Success)
				return NotFound(result);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteType([FromBody] TypeIdRequest request)
		{
			var result = await _typeService.DeleteType(request.Id);
			return Ok(result);
		}
	}
}