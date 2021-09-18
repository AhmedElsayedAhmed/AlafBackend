using Framework.Core.Model;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using User.BAL.Models;

namespace User.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUsersService _userService;
        internal readonly IUnitOfWork _unitOfWork;
        private readonly IUtility _utility;
        private readonly IConfiguration _configuration;

        public AccountService(IUsersService usersService,
            IUnitOfWork unitOfWork,
            IUtility utility,
            IConfiguration configuration)
        {
            _userService = usersService;
            _unitOfWork = unitOfWork;
            _utility = utility;
            _configuration = configuration;
        }



        public async Task<Persistence.User> Register(UserVM model)
        {
            try
            {
                model.Password = _utility.Hash(model.Password);
                model.Name = model.Email;
                var mailValid = await CheckEmail(model.Email);
                if(mailValid == "400")
                    _unitOfWork.SaveResult.Errors.Add(new Error(500, "mail exists"));

                var user = _userService.Insert(model);
           
                return user;
            }
            catch (Exception e)
            {
                _unitOfWork.SaveResult.Errors.Add(new Error(500, e.Message.ToString()));
                return null;
            }
        }

        public Persistence.User Login(LoginVm loginModel)
        {
           
                var user = _userService.GetEntity(a => a.Email.ToLower() == loginModel.Email.ToLower());
                if (user != null)
                {


                    if (_utility.Verify(loginModel.Password, user.Password))
                        return user;

                }
            
       
           
            return null;
        }

   

    

        public async Task<string> CheckEmail(string email)
        {
            var user = _unitOfWork.Users.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefault();
            if (user != null)
                return "400";
            return "200";
            //else
            //{
            
            //    return user.PhoneNumber; ;
            //}
        }

    }
    
}
