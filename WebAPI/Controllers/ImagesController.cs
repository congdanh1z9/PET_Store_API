using Application.Interfaces;
using Application.ViewModels.ImageDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllImages()
        {
            var result = await _imageService.GetAllImages();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetImageById(int id)
        {
            var result = await _imageService.GetImageById(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("postpet/{postPetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetImagesByPostPetId(int postPetId)
        {
            var result = await _imageService.GetImagesByPostPetId(postPetId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateImage([FromBody] ImageCreateDTO imageDto)
        {
            var result = await _imageService.CreateImage(imageDto);
            return CreatedAtAction(nameof(GetImageById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateImage(int id, [FromBody] ImageUpdateDTO imageDto)
        {
            var result = await _imageService.UpdateImage(id, imageDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var result = await _imageService.DeleteImage(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}