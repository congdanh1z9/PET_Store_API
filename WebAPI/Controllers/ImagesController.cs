using Application.Interfaces;
using Application.ViewModels.ImageDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/image")]
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

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetImageById([FromBody] ImageIdRequest request)
		{
			var result = await _imageService.GetImageById(request.Id);
			return Ok(result);
		}

		[HttpGet("get-by-post-pet-id")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetImagesByPostPetId([FromBody] PostPetIdRequest request)
		{
			var result = await _imageService.GetImagesByPostPetId(request.PostPetId);
			return Ok(result);
		}

		[HttpPost("create")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateImage([FromBody] ImageCreateDTO imageDto)
		{
			var result = await _imageService.CreateImage(imageDto);
			return Ok(result);
		}

		[HttpPut("update")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> UpdateImage([FromBody] ImageUpdateRequest request)
		{
			var result = await _imageService.UpdateImage(request.Id, request.ImageDto);
			return Ok(result);
		}

		[HttpDelete("delete")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> DeleteImage([FromBody] ImageIdRequest request)
		{
			var result = await _imageService.DeleteImage(request.Id);
			return Ok(result);
		}
	}
}