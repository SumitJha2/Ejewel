using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.DAL.Admin.Extras;
using EJewel.Model.Admin.Extras;

namespace EJewel.Controller.Admin.Extras
{    
  public class ContactDetailsController
    {
      ContactDetailsDAL objDAL = new ContactDetailsDAL();
      public ContactDetailsModel SaveContactDetails(ContactDetailsModel model)
      {
          return objDAL.SaveContactDetails(model);
      }
      public List<ContactDetailsModel> GetContactDetails()
      {
          return objDAL.GetContactDetails();
      }
      public bool DeleteContactDetails(int contactDetailsId)
      {
          return objDAL.DeleteContactDetails(contactDetailsId);
      }

    }
}
