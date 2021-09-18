using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Migration
    {
        public uint Id { get; set; }
        public string Migration1 { get; set; }
        public int Batch { get; set; }
    }
}
