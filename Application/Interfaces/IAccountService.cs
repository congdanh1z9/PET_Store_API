using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponse<AccountViewDTO>> Login(string email, string password);
    }
}
