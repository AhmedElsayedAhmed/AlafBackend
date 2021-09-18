using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Permission
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
