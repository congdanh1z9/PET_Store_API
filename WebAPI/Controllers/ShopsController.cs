using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.ShopDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ShopViewDTO>>>> ViewAllShops()
        {
            var response = await _shopService.ViewAllShops();
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ServiceResponse<string>>> CreateShop([FromBody] CreateShopDTO createShopDTO)
        {
            var response = await _shopService.CreateShop(createShopDTO);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateShop([FromBody] UpdateShopDTO updateShopDTO)
        {
            var response = await _shopService.UpdateShop(updateShopDTO.Id, updateShopDTO);
            return Ok(response);
        }
    }
}
