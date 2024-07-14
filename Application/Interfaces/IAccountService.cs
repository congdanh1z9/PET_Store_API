using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponse<AccountViewDTO>> Login(string email, string password);
        Task<ServiceResponse<string>> Register(RegisterDTO registerDTO);
        Task<ServiceResponse<string>> ChangePassword(string email, string oldPassword, string newPassword, string confirmPassword);
        Task<ServiceResponse<List<AccountViewDTO>>> ViewAllAccounts();
        Task<ServiceResponse<string>> UpdateAccount(string email, UpdateAccountDTO updateAccountDTO);
    }
}
