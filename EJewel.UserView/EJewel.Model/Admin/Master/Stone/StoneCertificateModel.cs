using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EJewel.Model.Admin.Master.Stone
{
   public class StoneCertificateModel
    {
       /* sumit jha
        * @ 23-01-2013
        * */
       public int CertificateID { get; set; }
       public int StoneID { get; set; }
       public double CertificateDepth { get; set; }
       public double CertificateTable { get; set; }
       public int GridleId { get; set; }
       public int SymmetryId { get; set; }
       public int PolishId { get; set; }
       public int CuletId { get; set; }
       public int FlouresenceID { get; set; }
       public string CertificateMeasurement { get; set; }
       public double CertificateCrown { get; set; }
       public double CertificateCrownAngle { get; set; }
       public double CertificatePavillion { get; set; }
       public double CertificatePavillionAngle { get; set; }
       public string CertificateCertification { get; set; }
       public int LabId { get; set; }
       public string CertificationFile { get; set; }
       public bool Status { get; set; }


       

    }
}
