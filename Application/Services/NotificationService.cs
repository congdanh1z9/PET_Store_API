using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.NotificationDTO;
using Application.ViewModels.PostDTO;
using AutoMapper;
using Domain.Entitys;
using MailKit.Search;

namespace Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ViewNotificationDTO>> CreateNotificationAsync(CreateNotificationDTO dto)
        {
            var reponse = new ServiceResponse<ViewNotificationDTO>();

            try
            {
                var entity = _mapper.Map<Notification>(dto);
                await _unitOfWork.NotificationRepository.AddAsync(entity);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<ViewNotificationDTO>(entity);
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Add notification successfully";
                    return reponse;
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewNotificationDTO>(entity);
                    reponse.Success = true;
                    reponse.Status = "400";
                    reponse.Message = "Add notification fail in Save";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Add fail with exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<ViewNotificationDTO>> DeleteNotificationAsync(int id)
        {
            var reponse = new ServiceResponse<ViewNotificationDTO>();
            try
            {
                var ViewNotificationDTO = await _unitOfWork.NotificationRepository.GetByIdAsync(id);

                if (ViewNotificationDTO == null)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Not found notification";
                }
                else if (ViewNotificationDTO.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "notification are deleted";
                }
                else
                {
                        var notificationFofUpdate = _mapper.Map<ViewNotificationDTO>(ViewNotificationDTO);
                        _unitOfWork.NotificationRepository.SoftRemove(ViewNotificationDTO);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = notificationFofUpdate;
                            reponse.Success = true;
                            reponse.Status = "200";
                            reponse.Message = "delete notification successfully";
                        }
                        else
                        {
                            reponse.Data = notificationFofUpdate;
                            reponse.Success = false;
                            reponse.Status = "400";
                            reponse.Message = "delete notification fail!";
                        }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Delete notification fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }
            return reponse;
        }

        public async Task<ServiceResponse<IEnumerable<ViewNotificationDTO>>> GetNotificationByBuyerIDAsync(int buyerId)
        {
            var reponse = new ServiceResponse<IEnumerable<ViewNotificationDTO>>();
            try
            {
                List<ViewNotificationDTO> DTOs = new List<ViewNotificationDTO>();
                var cc = await _unitOfWork.NotificationRepository.GetAllAsync();
                var c = cc.Where(x => x.BuyerId == buyerId).ToList();
                foreach (var item in c)
                {
                    if (item.IsDeleted == false)
                    {
                        DTOs.Add(_mapper.Map<ViewNotificationDTO>(item));
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

        public async Task<ServiceResponse<ViewNotificationDTO>> GetNotificationByIdAsync(int Id)
        {
            var reponse = new ServiceResponse<ViewNotificationDTO>();
            try
            {
                var cc = await _unitOfWork.NotificationRepository.GetAllAsync();
                var c = cc.Where(x => x.Id == Id).First();
                if (c == null || c.IsDeleted != false)
                {
                    reponse.Data = _mapper.Map<ViewNotificationDTO>(c);
                    reponse.Success = false;
                    reponse.Status = "400";
                    reponse.Message = "Notification Retrieved Fail";
                }
                else
                {
                    reponse.Data = _mapper.Map<ViewNotificationDTO>(c);
                    reponse.Success = true;
                    reponse.Status = "200";
                    reponse.Message = "Notification Retrieved Successfully";
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

        public async Task<ServiceResponse<IEnumerable<ViewNotificationDTO>>> GetNotificationsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<ViewNotificationDTO>>();
            List<ViewNotificationDTO> DTOs = new List<ViewNotificationDTO>();
            try
            {
                var notifications = await _unitOfWork.NotificationRepository.GetAllAsync();
                foreach (var notification in notifications)
                {
                    if(notification.IsDeleted == false)
                    {
                        DTOs.Add(_mapper.Map<ViewNotificationDTO>(notification));
                    }
                }
                if (DTOs.Count > 0)
                {
                    reponse.Data = DTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {DTOs.Count} notification.";
                    reponse.Status = "200";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {DTOs.Count} notification.";
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

        public async Task<ServiceResponse<ViewNotificationDTO>> UpdateNotificationAsync(int Id, UpdateNotificationDTO dto)
        {
            var reponse = new ServiceResponse<ViewNotificationDTO>();
            try
            {
                var notificationChecked = await _unitOfWork.NotificationRepository.GetByIdAsync(Id);

                if (notificationChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found notification";
                    reponse.Status = "400";
                }
                else if (notificationChecked.IsDeleted == true)
                {

                    reponse.Success = false;
                    reponse.Message = "Notification is deleted";
                    reponse.Status = "400";
                }
                else
                {

                    var notificationFofUpdate = _mapper.Map(dto, notificationChecked);
                    var notificationDTOAfterUpdate = _mapper.Map<ViewNotificationDTO>(notificationFofUpdate);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Data = notificationDTOAfterUpdate;
                        reponse.Success = true;
                        reponse.Status = "200";
                        reponse.Message = "Update Notification successfully";
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Status = "400";
                        reponse.Message = "Update Notification fail!";
                    }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Status = "400";
                reponse.Message = "Update Notification fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }
    }
}
