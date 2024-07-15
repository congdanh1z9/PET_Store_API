using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using AutoMapper;
using Domain.Entitys;
using Domain.Enums;


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
        public async Task<ServiceResponse<ViewPostDTO>> CreatePostAsync(CreatePostDTO dto)
        {
            var reponse = new ServiceResponse<ViewPostDTO>();

            try
            {
                var entity = _mapper.Map<PostPet>(dto);
                await _unitOfWork.PostRepository.AddAsync(entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ViewPostDTO>(entity);
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Add post successfully";
                    return reponse;
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewPostDTO>(entity);
                    reponse.Success = true;
                    reponse.Status = "400";
                    reponse.Message = "Add post fail in Save";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Status = "400";
                reponse.Success = false;
                reponse.Message = "Fail with exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<ViewPostDTO>> DeletePostAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewPostDTO>();
            try
            {
                var ViewPostDTO = await _unitOfWork.PostRepository.GetByIdAsync(Id);

                if (ViewPostDTO == null)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Not found notification";
                }
                else if (ViewPostDTO.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "post are deleted";
                }
                else
                {
                    var notificationFofUpdate = _mapper.Map<ViewPostDTO>(ViewPostDTO);
                    _unitOfWork.PostRepository.SoftRemove(ViewPostDTO);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = notificationFofUpdate;
                        reponse.Success = true;
                        reponse.Status = "200";
                        reponse.Message = "delete post successfully";
                    }
                    else
                    {
                        reponse.Data = notificationFofUpdate;
                        reponse.Success = false;
                        reponse.Status = "400";
                        reponse.Message = "delete post fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Delete post fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }
            return reponse;
        }

        public async Task<ServiceResponse<ViewPostDTO>> GetPostByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewPostDTO>();
            try
            {
                var ccc = await _unitOfWork.PostRepository.GetAllAsync(x => x.Type);
                var cc = ccc.OrderByDescending(x => x.Id);
                var c = cc.Where(x => x.Id == Id).First();
                if (c == null || c.IsDeleted != false)
                {
                    var mapper = _mapper.Map<ViewPostDTO>(c);
                    mapper.TypeName = c.Type.Name;
                    mapper.HealthStatusName = printHealthStatus((int)mapper.HealthStatus);
                    reponse.Data = mapper;
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Post Retrieved Fail";
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewPostDTO>(c);
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Post Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostByShopIDAsync(int shopId)
        {
            var reponse = new ServiceResponse<IEnumerable<ViewPostDTO>>();
            try
            {
                List<ViewPostDTO> DTOs = new List<ViewPostDTO>();
                var ccc = await _unitOfWork.PostRepository.GetAllAsync(x => x.Type);
                var cc = ccc.OrderByDescending(x => x.Id);
                var c = cc.Where(x => x.ShopID == shopId).ToList();
                foreach (var item in c)
                {
                    if(item.IsDeleted == false)
                    {
                        var mapper = _mapper.Map<ViewPostDTO>(item);
                        mapper.TypeName = item.Type.Name;
                        mapper.HealthStatusName = printHealthStatus((int)mapper.HealthStatus);
                        DTOs.Add(mapper);
                    }
                }
                if (DTOs == null || DTOs.Count <= 0)
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Status = "400";
                    reponse.Message = "Not Found Notification";
                }
                else
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Notification Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewPostDTO>>> GetPostsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewPostDTO>>();
            List<ViewPostDTO> DTOs = new List<ViewPostDTO>();
            try
            {
                var postss = await _unitOfWork.PostRepository.GetAllAsync(x => x.Type);
                var posts = postss.OrderByDescending(x => x.Id); 
                foreach (var post in posts)
                {
                    if (post.IsDeleted == false)
                    {
                        var mapper = _mapper.Map<ViewPostDTO>(post);
                        mapper.TypeName = post.Type.Name;
                        mapper.HealthStatusName = printHealthStatus((int)mapper.HealthStatus); 
                        DTOs.Add(mapper);
                    }
                }
                if (DTOs.Count > 0 || DTOs == null)
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {DTOs.Count} post.";
                    reponse.Status = "200";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {DTOs.Count} post.";
                    reponse.Status = "400";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<ViewPostDTO>> UpdatePostAsync(int Id, UpdatePostDTO dto)
        {
            var reponse = new ServiceResponse<ViewPostDTO>();
            try
            {
                var postChecked = await _unitOfWork.PostRepository.GetByIdAsync(Id);

                if (postChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found post";
                    reponse.Status = "400";
                }
                else if (postChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "post is deleted";
                    reponse.Status = "400";
                }
                else
                {

                    var postFofUpdate = _mapper.Map(dto, postChecked);
                    var postDTOAfterUpdate = _mapper.Map<ViewPostDTO>(postFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = postDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Status = "200";
                        reponse.Message = "Update post successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Status = "400";
                        reponse.Message = "Update post fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Update post fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
        private string printHealthStatus(int healthStatusID)
        {
            string healthName;
            switch (healthStatusID)
            {
                case 1:
                    healthName = HealthStatusEnum.Sick.ToString();
                    break;
                case 2:
                    healthName = HealthStatusEnum.Recovering.ToString();
                    break;
                case 3:
                    healthName = HealthStatusEnum.Healthy.ToString();
                    break;
                default:
                    healthName = "Unknown";
                    break;
            }
            return healthName;
        }

    }
}
