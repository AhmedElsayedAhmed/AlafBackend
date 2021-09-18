using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public string ArTitle { get; set; }
        public string ArDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
