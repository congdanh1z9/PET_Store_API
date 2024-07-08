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
       
        public async Task<IActionResult> GetAllImages()
        {
            var result = await _imageService.GetAllImages();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
<<<<<<< HEAD
       
        public async Task<IActionResult> GetImageById([FromBody] ImageIdRequest request)
=======
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetImageById(int id)
>>>>>>> parent of 62ba2c9 (update api)
        {
            var result = await _imageService.GetImageById(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("postpet/{postPetId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
<<<<<<< HEAD
       
        public async Task<IActionResult> GetImagesByPostPetId([FromBody] PostPetIdRequest request)
=======
        public async Task<IActionResult> GetImagesByPostPetId(int postPetId)
>>>>>>> parent of 62ba2c9 (update api)
        {
            var result = await _imageService.GetImagesByPostPetId(postPetId);
            return Ok(result);
        }

<<<<<<< HEAD
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
=======
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
>>>>>>> parent of 62ba2c9 (update api)
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
<<<<<<< HEAD
       
        public async Task<IActionResult> UpdateImage([FromBody] ImageUpdateRequest request)
=======
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteImage(int id)
>>>>>>> parent of 62ba2c9 (update api)
        {
            var result = await _imageService.DeleteImage(id);
            if (!result.Success)
<<<<<<< HEAD
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        public async Task<IActionResult> DeleteImage([FromBody] ImageIdRequest request)
        {
            var result = await _imageService.DeleteImage(request.Id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
=======
                return NotFound(result);
>>>>>>> parent of 62ba2c9 (update api)
            return Ok(result);
        }
    }
}