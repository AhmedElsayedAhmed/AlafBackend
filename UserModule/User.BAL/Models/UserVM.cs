
using Framework.Core.Model;
using System;
using System.Collections.Generic;

namespace User.BAL.Models
{
    public class UserVM : IVM
    {
       
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }



    }

    public class BaseVm : IVM
    {
        public string Email { get; set; }
        public string Address { get; set; }


    }
    public class BaseUser: UserVM
    {

        public string Email { get; set; }
        public string Address { get; set; }

    }

    public class HeaderUserDetail
    {
        public bool HasCredit { get; set; }
        public bool IsMobileVerified { get; set; } = false;

        public string FirstName { get; set; }
        public string ProfilePictureFileId { get; set; }
        public bool ApplicationRate { get; set; }
    }


    public class ClientUserDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureFileId { get; set; }
        public int ItemCount { get; set; }
        public string Location { get; set; }
        public int BagCount { get; set; }
        public decimal Rate { get; set; }
        public int NumberOfRate { get; set; }
        public int GrateCommunication { get; set; } = 0;
        public int DeliveredWithCare { get; set; } = 0;
        public int OnTime { get; set; } = 0;
        public int AboveAndBeyond { get; set; } = 0;

        public string AboutMySelf { get; set; }
        public string PiggyBagForOther { get; set; }
        public string FunStory { get; set; }
        public bool ApplicationRate { get; set; } = false;

        
    }

   
}