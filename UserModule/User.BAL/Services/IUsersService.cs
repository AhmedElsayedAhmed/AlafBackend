
using Framework.Core.UOW;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.BAL.Models;

namespace User.BAL.Services
{
    public interface IUsersService : IBaseService<Persistence.User, UserVM>
    {
    }
}
