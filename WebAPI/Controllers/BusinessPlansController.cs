using Application.Interfaces;
using Application.ViewModels.BusinessPlanDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBusinessPlans()
        {
            var result = await _businessPlanService.GetAllBusinessPlans();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBusinessPlanById(int id)
        {
            var result = await _businessPlanService.GetBusinessPlanById(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBusinessPlan([FromBody] BusinessPlanCreateDTO businessPlanDto)
        {
            var result = await _businessPlanService.CreateBusinessPlan(businessPlanDto);
            return CreatedAtAction(nameof(GetBusinessPlanById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBusinessPlan(int id, [FromBody] BusinessPlanUpdateDTO businessPlanDto)
        {
            var result = await _businessPlanService.UpdateBusinessPlan(id, businessPlanDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBusinessPlan(int id)
        {
            var result = await _businessPlanService.DeleteBusinessPlan(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}