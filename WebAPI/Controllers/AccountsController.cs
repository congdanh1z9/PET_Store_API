﻿using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("inputname/{input}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Inputname(string input)
        {
            var result = $"{input} + HELLO backend";
            return Ok(result);
        }
    }

    
}
