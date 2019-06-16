using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Extras
{
   public class ContactDetailsModel
    {
        public int ContactDetailsId { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
        public DateTime ContactDate { get; set; }    
      
    }
}
