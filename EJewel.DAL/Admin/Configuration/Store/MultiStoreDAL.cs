using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Configuration.Store;
namespace EJewel.DAL.Admin.Configuration.Store
{
    /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
    public class MultiStoreDAL
    {
        EJewelEntities objEntity = new EJewelEntities();
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        public MultiStoreModel SaveUpdateStore(MultiStoreModel model)
        {
            if (model.StoreID > 0)
            {
                ej_MultiStore objMultiStore = objEntity.ej_MultiStore.Where(ml => ml.StoreId == model.StoreID).FirstOrDefault();
                objMultiStore.StoreName = model.StoreName;
                objMultiStore.StoreUrl = model.StoreUrl;
                objMultiStore.DefaultCurrency = model.DefaultCurrency;
                objMultiStore.Status = model.Status;
                objEntity.SaveChanges();
            }
            else
            {
                ej_MultiStore store = this.Mapping(model);
                objEntity.AddToej_MultiStore(store);
                objEntity.SaveChanges();
                model.StoreID = store.StoreId;
            }

            return model;
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        public bool StoreExist(MultiStoreModel model)
        {
            if (model.StoreID > 0)
            {
                return objEntity.ej_MultiStore.Where(ml => ml.StoreId != model.StoreID && ml.StoreUrl == model.StoreUrl).Any();
            }
            else
            {
                return objEntity.ej_MultiStore.Where(ml => ml.StoreUrl == model.StoreUrl).Any();
            }
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        private MultiStoreModel Mapping(ej_MultiStore store)
        {
            MultiStoreModel model = new MultiStoreModel();
            model.StoreID = store.StoreId;
            model.StoreName = store.StoreName;
            model.StoreUrl = store.StoreUrl;
            model.DefaultCurrency = store.DefaultCurrency;
            model.Status = store.Status;
            return model;
        }
        /*
        * Partha Ranjan Nayak
        * @ 15-12-12
        * */
        private ej_MultiStore Mapping(MultiStoreModel model)
        {
            ej_MultiStore store = new ej_MultiStore();
            store.StoreId = model.StoreID;
            store.StoreName = model.StoreName;
            store.StoreUrl = model.StoreUrl;
            store.DefaultCurrency = model.DefaultCurrency;
            store.Status = model.Status;
            return store;
        }
        /* sumit jha
         * @ 25-01-2013
         * */
        public List<MultiStoreModel> GetMultiStore(int storeid)
        {
            List<MultiStoreModel> lstmultistore = new List<MultiStoreModel>();
            if (storeid > 0)
            {
                ej_MultiStore objstrore = objEntity.ej_MultiStore.Where(ml => ml.StoreId == storeid &&  ml.Status==true).FirstOrDefault();
                lstmultistore.Add(this.Mapping(objstrore));
            }
            else
            {
                foreach (ej_MultiStore obj in objEntity.ej_MultiStore.Where(ml => ml.Status == true).ToList())
                {
                    lstmultistore.Add(this.Mapping(obj));
                }
            }
            return lstmultistore.OrderByDescending(sc => sc.StoreID).ToList();
        }
        /* sumit jha
        * @ 25-01-2013
        * */
        public bool DeleteMultistore(MultiStoreModel model)
        {
            ej_MultiStore objstrore = objEntity.ej_MultiStore.Where(ml => ml.StoreId == model.StoreID).FirstOrDefault();
            objstrore.Status = false;
            objEntity.SaveChanges();
            return true;
        }

    }
}
