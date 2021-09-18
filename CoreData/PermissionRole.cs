using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class PermissionRole
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
