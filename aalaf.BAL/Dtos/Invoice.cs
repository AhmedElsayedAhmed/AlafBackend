using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace aalaf.BAL.Dtos
{
    public class InvoiceDto: IVM
    {
        //public string Serial { get; set; }
        public string Number { get; set; }
        //public int? Discount { get; set; }
        public string Status { get; set; }
        //public bool? Active { get; set; }
        public string Address { get; set; }
        public string CreatedAt { get; set; }
      
        //public long? UserId { get; set; }
        public decimal TotalPrice { get; set; }

        public  IList<OrderDto> Orders { get; set; }
    }
}
