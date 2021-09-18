using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Invoice
    {
        public Invoice()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Serial { get; set; }
        public string Number { get; set; }
        public int? Discount { get; set; }
        public string Status { get; set; }
        public bool? Active { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? UserId { get; set; }
        public decimal? TotalPrice { get; set; }



        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
