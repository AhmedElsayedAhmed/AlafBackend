using Api.Controllers.Base;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using User.BAL.Models;
using User.BAL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.Account
{
    [Route("api/[controller]/[action]")]
    public class AccountController : CommonController
    {
        private readonly IAccountService _accountService;
        private readonly IUtility _utility;
        private readonly TokenProvider _tokenProvider;
        private readonly IUnitOfWork _unitOfWork;



        public AccountController(IAccountService accountService,
            IUtility utility,
            TokenProvider tokenProvider,
            IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _utility = utility;
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserVM registerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(GetErrors(ModelState));
            var user = await _accountService.Register(registerVM);

            if (!CheckExistError())
                await _unitOfWork.Save();

            if (_unitOfWork.SaveResult.Errors.Count > 0)
            {
                return ResCreateServerError(_unitOfWork.SaveResult);
            }
            var tokenVm = _tokenProvider.GenerateAccessToken(user);
            // GenerateOTP("dsg");
            return Ok(new LoginResultVm(tokenVm));
            // return _unitOfWork.SaveResult.Errors.Count == 0 ? ResCreateOk(userId) : ResCreateServerError(_unitOfWork.SaveResult);
        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult Login([FromBody] LoginVm loginModel)
        {
            var user = _accountService.Login(loginModel);
            if (user == null)
                return BadRequest("Invalid UserName or Password");

            var tokenVm = _tokenProvider.GenerateAccessToken(user);
            // GenerateOTP("dsg");
            return Ok(new LoginResultVm(tokenVm));


        }

 
        protected bool CheckExistError()
        {
            return _unitOfWork.SaveResult.Errors.Count != 0;
        }

    }
}
