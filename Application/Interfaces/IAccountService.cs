using Application.ServiceReponses;
using Application.ViewModels.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        public Task<ServiceResponse<List<AccountViewDTO>>> ViewAllAccounts();
    }
}
