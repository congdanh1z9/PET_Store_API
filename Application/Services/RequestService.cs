using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using Application.ViewModels.RequestDTO;
using AutoMapper;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<ViewRequestDTO>> CreateRequestAsync(CreateRequestDTO dto)
        {
            var reponse = new ServiceResponse<ViewRequestDTO>();

            try
            {
                var entity = _mapper.Map<Request>(dto);
                await _unitOfWork.RequestRepository.AddAsync(entity);
                if(validateExitsField(dto) == true)
                {
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = _mapper.Map<ViewRequestDTO>(entity);
                        reponse.Success = true;
                        reponse.Status = "200";
                        reponse.Message = "Add request successfully";
                        return reponse;
                    }
                    else
                    {
                        reponse.Data = _mapper.Map<ViewRequestDTO>(entity);
                        reponse.Success = false;
                        reponse.Status = "400";
                        reponse.Message = "Add request fail in Save";
                        return reponse;
                    }
                }
                else
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Add request fail, field not found";
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
        private bool validateExitsField(CreateRequestDTO dto)
        {
            bool flag = true;
            var post = _unitOfWork.PostRepository.GetByIdAsync((int)dto.PostId);
            var shop = _unitOfWork.ShopRepository.GetByIdAsync((int)dto.ShopId);
            if (post.Result.IsDeleted == true || post == null)
            {
                flag = false;
            }
            else if (shop.Result.IsDeleted == true || shop == null)
            {
                flag = false;
            }
            return true;
        }
    }
}
