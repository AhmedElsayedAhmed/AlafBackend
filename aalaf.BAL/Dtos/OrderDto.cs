using Framework.Core.Model;
using System;

namespace aalaf.BAL.Dtos
{
    public class OrderDto: IVM
    {
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public string CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }
        //public long? ProductId { get; set; }
        public string ProductTitle { get; set; }
        //public long? InvoiceId { get; set; }
    }
}