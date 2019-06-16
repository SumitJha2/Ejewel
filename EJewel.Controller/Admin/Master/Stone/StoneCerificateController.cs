using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;
using EJewel.DAL.Admin.Master.Stone;

namespace EJewel.Controller.Admin.Master.Stone
{
   public class StoneCerificateController
    {
       /* sumit jha
        * @ 23-01-2013
        * */
       StoneCertificateDAL objCertificateDal = new StoneCertificateDAL();
       public StoneCertificateModel SaveUpdateStoneCertificate(StoneCertificateModel model)
       {
           return objCertificateDal.SaveUpdateStoneCertificate(model);
       }
        /* sumit jha
        * @ 23-01-2013
        * */
       public List<StoneCertificateModel> GetCertificate(int certificateid)
       {
           return objCertificateDal.GetCertificate(certificateid);
       }
       /* sumit jha
        * @ 24-01-2012
        * */
       public StoneCertificateModel GetCertificateByStoneID(int stoneid)
       {
           return objCertificateDal.GetCertificateByStoneID(stoneid);
       }
       
        

    }
}
