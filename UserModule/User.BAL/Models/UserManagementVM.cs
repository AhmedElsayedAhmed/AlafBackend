using System;
using System.Collections.Generic;
using System.Text;
using User.BAL.Models;

namespace User.BAL.Models
{
    public class UserManagementVM
    {
        public IList<UserVM> UserVMs { get; set; }
    }
}
