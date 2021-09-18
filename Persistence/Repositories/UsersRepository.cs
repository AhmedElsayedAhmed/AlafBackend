using Framework.Core;
using Framework.Core.Repo;
using Framework.Core.Repo.Interfaces;

namespace Persistence.Repositories
{
    public class UsersRepository : Repository<Persistence.User>, IUsersRepository
    {
        public UsersRepository(aalafContext context) : base(context)
        {
        }
    }
}
