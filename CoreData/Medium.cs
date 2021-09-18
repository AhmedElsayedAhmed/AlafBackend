using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Medium
    {
        public long Id { get; set; }
        public string ModelType { get; set; }
        public long ModelId { get; set; }
        public string CollectionName { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Disk { get; set; }
        public uint Size { get; set; }
        public string Manipulations { get; set; }
        public string CustomProperties { get; set; }
        public string ResponsiveImages { get; set; }
        public uint? OrderColumn { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
