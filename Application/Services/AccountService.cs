using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using AutoMapper;
using Domain.Entitys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<AccountViewDTO>>> ViewAllAccounts()
        {
            var response = new ServiceResponse<List<AccountViewDTO>>();
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            response.Data = _mapper.Map<List<AccountViewDTO>>(accounts);
            return response;
            {
            var response = new ServiceResponse<string>();
            }


            response.Data = "Đổi mật khẩu thành công!";
        }
    }
}
