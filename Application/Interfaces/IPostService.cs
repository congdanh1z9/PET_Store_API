using Application.ServiceReponses;
using Application.ViewModels.PostDTO;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostsAsync();
        Task<ServiceResponse<ViewPostDTO>> GetPostByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostByShopIDAsync(int shopId);
        Task<ServiceResponse<ViewPostDTO>> CreatePostAsync(CreatePostDTO dto);
        Task<ServiceResponse<ViewPostDTO>> UpdatePostAsync(int Id, UpdatePostDTO dto);
        Task<ServiceResponse<ViewPostDTO>> DeletePostAsync(int Id);
    }
}
