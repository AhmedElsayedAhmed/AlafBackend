

using AutoMapper;
using Framework.Core.BaseModel;
using Framework.Core.Model;
using Framework.Core.Repo.Interfaces;
using Framework.Core.UOW;
using Framework.Helpers;
using Microsoft.EntityFrameworkCore;
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
    public class UsersService : BaseService<Persistence.User, UserVM>, IUsersService
    {
        private readonly IUtility _utility;
        //private readonly INotificationService _notificationService;
        private readonly IConfiguration _configuration;


        protected override Func<Persistence.User, IVM> FuncToVM()
        {
            return (s) => new UserVM
            {
                Email = s.Email,
            };
        }

        public UsersService(IUsersRepository usersRepository, IUtility utility, IUnitOfWork unitOfWork,
             IMapper mapper, 
            //INotificationService notificationService,
            IConfiguration configuration
            )
            : base(usersRepository, unitOfWork, mapper)
        {
            _utility = utility;
            //_notificationService = notificationService;
            _configuration = configuration;
        }

    }
}
