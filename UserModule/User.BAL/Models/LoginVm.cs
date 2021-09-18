using System;
using System.Collections.Generic;
using System.Text;

namespace User.BAL.Models
{
    public class LoginVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
