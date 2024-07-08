using Application.Interfaces;
using Application.Repositories;
using Application.ServiceReponses;
using Application.ViewModels.MeetDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MeetService : IMeetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ViewMeetDTO>> CancelMeetAsync(int id)
        {
            var reponse = new ServiceResponse<ViewMeetDTO>();
            try
            {
                var ViewMeetDTO = await _unitOfWork.MeetRepository.GetByIdAsync(id);

                if (ViewMeetDTO == null)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Not found Meet";
                }
                else if (ViewMeetDTO.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Meet are deleted";
                }
                else if (ViewMeetDTO.Status == "Completed")
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Meet is Completed";
                }
                else
                {
                    if (ViewMeetDTO.Status == "Processing")
                    {
                        ViewMeetDTO.Status = "Cancel";
                        var meetFofUpdate = _mapper.Map<ViewMeetDTO>(ViewMeetDTO);
                        var meetDTOAfterUpdate = _mapper.Map<ViewMeetDTO>(meetFofUpdate);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = meetDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Status = "200";
                            reponse.Message = "Update Meet successfully";
                        }
                        else
                        {
                            reponse.Data = meetDTOAfterUpdate;
                            reponse.Success = false;
                            reponse.Status = "400";
                            reponse.Message = "Update Meet fail!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Update meet fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public Task<ServiceResponse<ViewMeetDTO>> CreateMeetAsync(CreateMeetDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetByBuyerIDAsync(int buyerId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ViewMeetDTO>> GetMeetByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetByShopIDAsync(int shopId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<ViewMeetDTO>>> GetMeetsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ViewMeetDTO>> UpdateMeetAsync(int id, UpdateMeetDTO dto)
        {
            throw new NotImplementedException();
        }

        
    }
}
