using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using AutoMapper;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var reponse = new ServiceResponse<List<AccountViewDTO>>();
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            List<AccountViewDTO> dtos = new List<AccountViewDTO>();
            foreach (var account in accounts)
            {
                dtos.Add(_mapper.Map<AccountViewDTO>(account));
            }
            reponse.Data = dtos;

            return reponse;
        }
    }
}
