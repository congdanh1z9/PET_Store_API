// AccountsController.cs
using Application.Interfaces;
using Application.Services;
using Application.ViewModels.AccountDTO;
using Application.ViewModels.PostDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllAccounts()
        {
            var result = await _accountService.ViewAllAccounts();
            return Ok(result);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]//
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _accountService.Login(loginDTO.email, loginDTO.password);

            //if (!result.Success)
            //{//
                //return BadRequest(new { message = result.Message });//
            //}//

            return Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await _accountService.Register(registerDTO);

            return Ok(result);
        }

        [HttpPost("changepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var result = await _accountService.ChangePassword(changePasswordDTO.email, changePasswordDTO.oldPassword, changePasswordDTO.newPassword , changePasswordDTO.confirmPassword);

            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAccount(string email, [FromBody] UpdateAccountDTO updateAccountDTO)
        {
            var result = await _accountService.UpdateAccount(email, updateAccountDTO);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProfileBuyerByAccountID([FromBody] SearchPostDTO dto)
        {
            var response = await _accountService.GetBuyerByAccountID(dto);
            return Ok(response);
        }
    }
}
