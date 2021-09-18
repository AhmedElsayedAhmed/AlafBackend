using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class Tokens
    {
        public Tokens()
        {
            
          
        }
        public string Token { get; set; }
        public BaseVm User { get; set; }
    }
}
