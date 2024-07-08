using Application.Interfaces;
using Application.ViewModels.BusinessPlanDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/v1/business-plan")]
    [ApiController]
    public class BusinessPlansController : ControllerBase
    {
        private readonly IBusinessPlanService _businessPlanService;

        public BusinessPlansController(IBusinessPlanService businessPlanService)
        {
            _businessPlanService = businessPlanService;
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetAllBusinessPlans()
        {
            var result = await _businessPlanService.GetAllBusinessPlans();
            return Ok(result);
        }

        [HttpPost("detail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetBusinessPlanById([FromBody] BusinessPlanIdRequest request)
        {
            var result = await _businessPlanService.GetBusinessPlanById(request.Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> CreateBusinessPlan([FromBody] BusinessPlanCreateDTO businessPlanDto)
        {
            var result = await _businessPlanService.CreateBusinessPlan(businessPlanDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> UpdateBusinessPlan([FromBody] BusinessPlanUpdateRequest request)
        {
            var result = await _businessPlanService.UpdateBusinessPlan(request.Id, request.BusinessPlanDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> DeleteBusinessPlan([FromBody] BusinessPlanIdRequest request)
        {
            var result = await _businessPlanService.DeleteBusinessPlan(request.Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}