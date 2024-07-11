using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using AutoMapper;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
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
