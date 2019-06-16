using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.SiteSetting
{
   public class UserDetailsModel
    {
        public int UId { get; set; }
        public int UserTypeId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMobNo { get; set; }
        public string UserPassword { get; set; }      
        public bool Status { get; set; }

        public string UserTypeName { get; set; }
    }
}
