using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Master.Payment;

namespace EJewel.DAL.Admin.Master.Payment
{
   public class TaxDAL
    {
       /* sumit jha
        * @ 26-12-2012
        *  */
       EJewelEntities objEntity = new EJewelEntities();
       public TaxModel SaveUpdateTax(TaxModel model)
       {
           if (model.TaxID > 0)
           {
               ej_TaxClass objTax = objEntity.ej_TaxClass.Where(tc => tc.TaxId == model.TaxID).FirstOrDefault();
               objTax.TaxClass = model.TaxClass;
               objTax.TaxPercent = model.TaxPercent;
               objTax.Status = model.Status;
               objEntity.SaveChanges();
           }
           else
           {
               ej_TaxClass objTax = this.Mapping(model);
               objEntity.AddToej_TaxClass(objTax);
               objEntity.SaveChanges();
               model.TaxID = objTax.TaxId;
           }
           return model;
       }
        /* sumit jha
        * @ 26-12-2012
        *  */
       public ej_TaxClass Mapping(TaxModel model)
       {
           ej_TaxClass objTaxClass = new ej_TaxClass();
           objTaxClass.TaxClass = model.TaxClass;
           objTaxClass.TaxPercent = model.TaxPercent;
           objTaxClass.Status = model.Status;
           return objTaxClass;
       }
       /* sumit jha
        * @ 26-12-2012
        *  */
       public bool IsExistTax(TaxModel model)
       {
           if (model.TaxID > 0)
           {
               return objEntity.ej_TaxClass.Where(tc => tc.TaxId != model.TaxID && tc.TaxClass == model.TaxClass).Any();
           }
           else
           {
               return objEntity.ej_TaxClass.Where(tc =>tc.TaxClass == model.TaxClass).Any();
           }
        
       }
       /* sumit jha
        * @ 15-01-2013
        * */
       public List<TaxModel> GetTax(int taxid)
       {
           List<TaxModel> lsttax = new List<TaxModel>();
           if (taxid > 0)
           {
               ej_TaxClass objTax = objEntity.ej_TaxClass.Where(tc => tc.TaxId == taxid && tc.Status==true).FirstOrDefault();
               lsttax.Add(this.Mapping(objTax));
           }
           else
           {
               foreach (var obj in objEntity.ej_TaxClass.Where(tc => tc.Status == true))
               {
                   lsttax.Add(this.Mapping(obj));
               }
           }
           return lsttax.OrderByDescending(tc=>tc.TaxID).ToList();               

       }
       /* sumit jha
        * @ 15-01-2013
        * */
       public TaxModel Mapping(ej_TaxClass objTax)
       {
           TaxModel model = new TaxModel();
           model.TaxID = objTax.TaxId;
           model.TaxClass = objTax.TaxClass;
           model.TaxPercent = objTax.TaxPercent;
           model.Status = objTax.Status;
           return model;
       }
        /* sumit jha
         * @ 15-01-2013
         * */
       public bool DeleteTax(TaxModel model)
       {
           ej_TaxClass objTax = objEntity.ej_TaxClass.Where(tc => tc.TaxId == model.TaxID).FirstOrDefault();
           objTax.Status = model.Status;
           objEntity.SaveChanges();
           return true;
       }


    }
}
