using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        public Task<ServiceResponse<ViewPostDTO>> CreatePostAsync(CreatePostDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ViewPostDTO>> DeletePostAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ViewPostDTO>> GetPostByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostByShopIDAsync(int shopId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ViewPostDTO>> UpdatePostAsync(int Id, UpdatePostDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
