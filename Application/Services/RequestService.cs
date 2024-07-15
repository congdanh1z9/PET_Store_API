using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.PostDTO;
using Application.ViewModels.RequestDTO;
using AutoMapper;
using Domain.Entitys;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Ocsp;
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
                var entity = _mapper.Map<Domain.Entitys.Request>(dto);
                var buyer = _unitOfWork.AccountRepository.GetByIdAsync((int)dto.AccountId, x => x.Buyer).Result;
                var post = _unitOfWork.PostRepository.GetByIdAsync((int)dto.PostId, x => x.Shop).Result;
                entity.ShopId = post.Shop.Id;
                entity.BuyerId = buyer.Buyer.Id;
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

        public async Task<ServiceResponse<ViewRequestDTO>> DeletePostAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewRequestDTO>();
            try
            {
                var ViewDTO = await _unitOfWork.RequestRepository.GetByIdAsync(Id);

                if (ViewDTO == null)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Not found Request";
                }
                else if (ViewDTO.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Request are deleted";
                }
                else
                {
                    var requestFofUpdate = _mapper.Map<ViewRequestDTO>(ViewDTO);
                    _unitOfWork.RequestRepository.SoftRemove(ViewDTO);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = requestFofUpdate;
                        reponse.Success = true;
                        reponse.Status = "200";
                        reponse.Message = "delete Request successfully";
                    }
                    else
                    {
                        reponse.Data = requestFofUpdate;
                        reponse.Success = false;
                        reponse.Status = "400";
                        reponse.Message = "delete Request fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Delete Request fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }
            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewRequestDTO>>> GetRequestByBuyerIDAsync(int Id)
        {
            var reponse = new ServiceResponse<IEnumerable<ViewRequestDTO>>();
            try
            {
                List<ViewRequestDTO> DTOs = new List<ViewRequestDTO>();
                var ccc = await _unitOfWork.RequestRepository.GetAllAsync();
                var cc = ccc.OrderByDescending(x => x.Id);
                var c = cc.Where(x => x.BuyerId == Id).ToList();
                foreach (var item in c)
                {
                    if (item.IsDeleted == false)
                    {
                        var mapper = _mapper.Map<ViewRequestDTO>(item);
                        var seller = _unitOfWork.ShopRepository.GetByIdAsync((int)item.ShopId, x => x.Account).Result;
                        var post = _unitOfWork.PostRepository.GetByIdAsync((int)item.PostId).Result;
                        mapper.sellerName = seller.Name;
                        mapper.Money = post.Price;
                        mapper.sellerPhone = seller.Account.phoneNumber;
                        DTOs.Add(mapper);
                    }
                }
                if (DTOs == null || DTOs.Count <= 0)
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Status = "400";
                    reponse.Message = "Not Found Request";
                }
                else
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Request Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<ViewRequestDTO>> GetRequestByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewRequestDTO>();
            try
            {
                var ccc = await _unitOfWork.RequestRepository.GetAllAsync();
                var cc = ccc.OrderByDescending(x => x.Id);
                var c = cc.Where(x => x.Id == Id).First();
                var seller = _unitOfWork.ShopRepository.GetByIdAsync((int)c.ShopId, x => x.Account).Result;
                var post = _unitOfWork.PostRepository.GetByIdAsync((int)c.PostId).Result;
                if (c == null || c.IsDeleted != false)
                {
                    var mapper = _mapper.Map<ViewRequestDTO>(c);
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Request Retrieved Fail";
                }
                else
                {
                    var mapper = _mapper.Map<ViewRequestDTO>(c);
                    mapper.sellerName = seller.Name;
                    mapper.Money = post.Price;
                    mapper.sellerPhone = seller.Account.phoneNumber;
                    reponse.Data = mapper;
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Request Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ViewRequestDTO>>> GetRequestsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewRequestDTO>>();
            List<ViewRequestDTO> DTOs = new List<ViewRequestDTO>();
            try
            {
                var requestss = await _unitOfWork.RequestRepository.GetAllAsync();
                var requests = requestss.OrderByDescending(x => x.Id);
                foreach (var request in requests)
                {
                    if (request.IsDeleted == false)
                    {
                        var post = _unitOfWork.PostRepository.GetByIdAsync((int)request.PostId).Result;
                        var seller = _unitOfWork.ShopRepository.GetByIdAsync((int)request.ShopId, x => x.Account).Result;
                        var mapper = _mapper.Map<ViewRequestDTO>(request);
                        mapper.sellerName = seller.Name;
                        mapper.Money = post.Price;
                        mapper.sellerPhone = seller.Account.phoneNumber;
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

        private bool validateExitsField(CreateRequestDTO dto)
        {
            bool flag = true;
            var post = _unitOfWork.PostRepository.GetByIdAsync((int)dto.PostId);
            if (post.Result.IsDeleted == true || post == null)
            {
                flag = false;
            }
            return true;
        }
    }
}
