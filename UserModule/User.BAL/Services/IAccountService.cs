using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.BAL.Models;

namespace User.BAL.Services
{
    public interface IAccountService
    {
        Task<Persistence.User> Register(UserVM model);
        Persistence.User Login(LoginVm loginModel);
        Task<string> CheckEmail(string email);

    }
}
