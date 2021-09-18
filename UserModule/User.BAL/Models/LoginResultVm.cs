using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class LoginResultVm
    {
        public LoginResultVm(Tokens tokens)
        {
            Token = tokens;
        }
        public Tokens Token { get; set; }
    }
}
