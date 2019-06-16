using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Stone;

namespace EJewel.DAL.Admin.Master.Stone
{
   public class StoneCertificateDAL
    {
       EJewelEntities objEntity = new EJewelEntities();
       /* sumit jha
        * @ 23-01-2013
        * */
       public StoneCertificateModel SaveUpdateStoneCertificate(StoneCertificateModel model)
       {
           try
           {
               if (model.CertificateID > 0)
               {
                   ej_StoneCertificate objCertificate = objEntity.ej_StoneCertificate.Where(cr => cr.CertificateId == model.CertificateID).FirstOrDefault();


                   objCertificate.StoneId = model.StoneID;
                   objCertificate.CertificateDepth = model.CertificateDepth;
                   objCertificate.CertificateTable = model.CertificateTable;
                   objCertificate.CertificateGridleId = model.GridleId;
                   objCertificate.CertificateSymmetryId = model.SymmetryId;
                   objCertificate.CertificatePolishId = model.PolishId;
                   objCertificate.CertificateCuletId = model.CuletId;
                   objCertificate.CertificateFlouresenceId = model.FlouresenceID;
                   objCertificate.CertificateMeasurement = model.CertificateMeasurement;
                   objCertificate.CertificateCrown = model.CertificateCrown;
                   objCertificate.CertificateCrownAngle = model.CertificateCrownAngle;
                   objCertificate.CertificatePavillion = model.CertificatePavillion;
                   objCertificate.CertificatePavillionAngle = model.CertificatePavillionAngle;
                   objCertificate.CertificateCertification = model.CertificateCertification;
                   objCertificate.CertificationFile = model.CertificationFile;
                   objCertificate.CertificateCertificationLabId = model.LabId;
                   objCertificate.Status = model.Status;
                   objEntity.SaveChanges();




               }
               else
               {
                   ej_StoneCertificate objCertificate = this.Mapping(model);
                   objEntity.AddToej_StoneCertificate(objCertificate);
                   objEntity.SaveChanges();
                   model.CertificateID = Convert.ToInt32(objCertificate.CertificateId);
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return model;

       }
       /* sumit jha
       * @ 23-01-2013
       * */
       public ej_StoneCertificate  Mapping(StoneCertificateModel model)
       {
           try
           {
               ej_StoneCertificate objCertificate = new ej_StoneCertificate();
               objCertificate.StoneId = model.StoneID;
               objCertificate.CertificateDepth = model.CertificateDepth;
               objCertificate.CertificateTable = model.CertificateTable;
               objCertificate.CertificateGridleId = model.GridleId;
               objCertificate.CertificateSymmetryId = model.SymmetryId;
               objCertificate.CertificatePolishId = model.PolishId;
               objCertificate.CertificateCuletId = model.CuletId;
               objCertificate.CertificateFlouresenceId = model.FlouresenceID;
               objCertificate.CertificateMeasurement = model.CertificateMeasurement;
               objCertificate.CertificateCrown = model.CertificateCrown;
               objCertificate.CertificateCrownAngle = model.CertificateCrownAngle;
               objCertificate.CertificatePavillion = model.CertificatePavillion;
               objCertificate.CertificatePavillionAngle = model.CertificatePavillionAngle;
               objCertificate.CertificateCertification = model.CertificateCertification;
               objCertificate.CertificationFile = model.CertificationFile;
               objCertificate.CertificateCertificationLabId = model.LabId;
               objCertificate.Status = model.Status;
               return objCertificate;
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return null;
       }
        /* sumit jha
      * @ 23-01-2013
      * */
       public List<StoneCertificateModel> GetCertificate(int certificateid)
       {
           List<StoneCertificateModel> lstcertificate=new List<StoneCertificateModel>();

           try
           {
               if (certificateid > 0)
               {
                   ej_StoneCertificate objCertificate = objEntity.ej_StoneCertificate.Where(cr => cr.CertificateId == certificateid).FirstOrDefault();
                   lstcertificate.Add(this.Mapping(objCertificate));
               }
               else
               {
                   foreach (ej_StoneCertificate objCert in objEntity.ej_StoneCertificate.Where(sc => sc.Status == true))
                   {
                       lstcertificate.Add(this.Mapping(objCert));
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return lstcertificate;
       }
        /* sumit jha
     * @ 23-01-2013
     * */
       public StoneCertificateModel Mapping(ej_StoneCertificate model)
       {
           try
           {
               StoneCertificateModel objCertificate = new StoneCertificateModel();
               if (model != null)
               {
                   objCertificate.CertificateID = Convert.ToInt32(model.CertificateId);
                   objCertificate.StoneID = Convert.ToInt32(model.StoneId);
                   objCertificate.CertificateDepth = model.CertificateDepth;
                   objCertificate.CertificateTable = model.CertificateTable;
                   objCertificate.GridleId = model.CertificateGridleId;
                   objCertificate.SymmetryId = model.CertificateSymmetryId;
                   objCertificate.PolishId = model.CertificatePolishId;
                   objCertificate.CuletId = model.CertificateCuletId;
                   objCertificate.FlouresenceID = model.CertificateFlouresenceId;
                   objCertificate.CertificateMeasurement = model.CertificateMeasurement;
                   objCertificate.CertificateCrown = model.CertificateCrown;
                   objCertificate.CertificateCrownAngle = model.CertificateCrownAngle;
                   objCertificate.CertificatePavillion = model.CertificatePavillion;
                   objCertificate.CertificatePavillionAngle = model.CertificatePavillionAngle;
                   objCertificate.CertificateCertification = model.CertificateCertification;
                   objCertificate.LabId = model.CertificateCertificationLabId;
                   objCertificate.CertificationFile = model.CertificationFile;
                   objCertificate.Status = model.Status;

                   return objCertificate;
               }
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return null;
       }
       /* sumit jha
        * @ 24-01-2013
        * */
       public StoneCertificateModel GetCertificateByStoneID(int stoneid)
       {
           try
           {
               ej_StoneCertificate objStoneCertificate = objEntity.ej_StoneCertificate.Where(sc => sc.StoneId == stoneid).FirstOrDefault();
               return this.Mapping(objStoneCertificate);
           }
           catch (Exception ex)
           {
               ErrorLogDAL obj = new ErrorLogDAL();
               obj.SetErrorLog(new ErrorLogModel()
               {
                   ErrorMessage = ex.Message,
                   ErrorSource = ex.Source,
                   InnerException = Convert.ToString(ex.InnerException),
                   LogTime = DateTime.Now,
                   StackTrace = ex.StackTrace,
                   UserID = "DAL"
               });
           }
           return null;

       }
      
    }
}
