using Application.Interfaces;
using Application.ViewModels.PostDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllPost()
        {
            var result = await _postService.GetPostsAsync();
            return Ok(result);
        }


        //[Authorize(Roles = "Buyer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewAllPostByShopID([FromQuery] SearchPostDTO searchPostDTO)
        {
            var result = await _postService.GetPostByShopIDAsync(searchPostDTO.Id);
            return Ok(result);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ViewPostByID([FromQuery] SearchPostDTO searchPostDTO)
        {
            var result = await _postService.GetPostByIdAsync(searchPostDTO.Id);
            return Ok(result);
        }

        //[Authorize (Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createDto)
        {
            var c = await _postService.CreatePostAsync(createDto);
            return Ok(c);
        }

        //[Authorize(Roles = "Manager")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO updateDto)
        {
            var c = await _postService.UpdatePostAsync(updateDto.Id, updateDto);
            return Ok(c);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CancelPost([FromQuery] SearchPostDTO searchPostDTO)
        {
            var c = await _postService.DeletePostAsync(searchPostDTO.Id);
            return Ok(c);
        }
    }
}
