using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class RoleUser
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
