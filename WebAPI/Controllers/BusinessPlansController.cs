using Application.Interfaces;
using Application.ViewModels.BusinessPlanDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/business-plan")]
	[ApiController]
	public class BusinessPlansController : BaseController
	{
		private readonly IBusinessPlanService _businessPlanService;

		public BusinessPlansController(IBusinessPlanService businessPlanService)
		{
			_businessPlanService = businessPlanService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllBusinessPlans()
		{
			var result = await _businessPlanService.GetAllBusinessPlans();
			return Ok(result);
		}

		[HttpGet("get-by-id")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetBusinessPlanById([FromBody] BusinessPlanIdRequest request)
		{
			var result = await _businessPlanService.GetBusinessPlanById(request.Id);
			return Ok(result);
		}

		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateBusinessPlan([FromBody] BusinessPlanCreateDTO businessPlanDto)
		{
			var result = await _businessPlanService.CreateBusinessPlan(businessPlanDto);
			return Ok(result);
		}

		[HttpPut("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> UpdateBusinessPlan([FromBody] BusinessPlanUpdateRequest request)
		{
			var result = await _businessPlanService.UpdateBusinessPlan(request.Id, request.BusinessPlanDto);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteBusinessPlan([FromBody] BusinessPlanIdRequest request)
		{
			var result = await _businessPlanService.DeleteBusinessPlan(request.Id);
			return Ok(result);
		}
	}
}