// AccountService.cs
using Application.Interfaces;
using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using AutoMapper;
using Domain.Entitys;
using System.Collections.Generic;
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

        public async Task<ServiceResponse<AccountViewDTO>> Login(string email, string password)
        {
            var response = new ServiceResponse<AccountViewDTO>();
            var account = await _unitOfWork.AccountRepository.GetFirstOrDefaultAsync(a => a.email == email && a.password == password);

            if (account == null)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Invalid email or password.";
                return response;
            }

            response.Data = _mapper.Map<AccountViewDTO>(account);
            return response;
        }

        public async Task<ServiceResponse<string>> Register(RegisterDTO registerDTO)
        {
            var response = new ServiceResponse<string>();

            // Check if email is already registered
            var existingAccount = await _unitOfWork.AccountRepository.GetFirstOrDefaultAsync(a => a.email == registerDTO.email);
            if (existingAccount != null)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Email already registered.";
                return response;
            }

            // Check if passwords match
            if (registerDTO.password != registerDTO.confirmPassword)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Passwords do not match.";
                return response;
            }

            // Create new account
            var newAccount = new Account
            {
                fullName = registerDTO.fullName,
                email = registerDTO.email,
                password = registerDTO.password,
                role = "buyer" // or "shop" depending on your logic
            };

            await _unitOfWork.AccountRepository.AddAsync(newAccount);
            await _unitOfWork.SaveChangeAsync();

            response.Data = "Registration successful.";
            return response;
        }

        public async Task<ServiceResponse<string>> ChangePassword(string email, string oldPassword, string newPassword, string confirmPassword)
        {
            var response = new ServiceResponse<string>();

            var account = await _unitOfWork.AccountRepository.GetFirstOrDefaultAsync(a => a.email == email && a.password == oldPassword);

            if (account == null)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Invalid email or password.";
                return response;
            }

            if (oldPassword == newPassword)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "New password must be different from the old password.";
                return response;
            }

            if (newPassword != confirmPassword)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "New password and confirm password do not match.";
                return response;
            }

            account.password = newPassword;
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangeAsync();

            response.Data = "Password changed successfully.";
            return response;
        }
        public async Task<ServiceResponse<string>> UpdateAccount(string email, UpdateAccountDTO updateAccountDTO)
        {
            var response = new ServiceResponse<string>();

            var account = await _unitOfWork.AccountRepository.GetFirstOrDefaultAsync(a => a.email == email);

            if (account == null)
            {
                response.Success = false;
                response.Status = "400";
                response.Message = "Account not found.";
                return response;
            }

            account.fullName = updateAccountDTO.fullName;
            account.phoneNumber = updateAccountDTO.phoneNumber;

            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangeAsync();

            response.Data = "Account updated successfully.";
            return response;
        }



        public async Task<ServiceResponse<List<AccountViewDTO>>> ViewAllAccounts()
        {
            var response = new ServiceResponse<List<AccountViewDTO>>();
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            var dtos = _mapper.Map<List<AccountViewDTO>>(accounts);
            response.Data = dtos;
            return response;
        }
    }
}
