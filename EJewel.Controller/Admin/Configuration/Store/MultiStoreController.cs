using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJewel.Model.Admin.Configuration.Store;
using EJewel.DAL.Admin.Configuration.Store;
namespace EJewel.Controller.Admin.Configuration.Store
{
    public class MultiStoreController
    {
        MultiStoreDAL objMultiStoreDAL = new MultiStoreDAL();
        public MultiStoreModel SaveUpdateStore(MultiStoreModel model)
        {
            return objMultiStoreDAL.SaveUpdateStore(model);
        }
        public bool StoreExist(MultiStoreModel model)
        {
            return objMultiStoreDAL.StoreExist(model);
        }
        public List<MultiStoreModel> GetMultiStore(int storeid)
        {
            return objMultiStoreDAL.GetMultiStore(storeid);
        }
        public bool  DeleteMultiStore(MultiStoreModel model)
        {
            return objMultiStoreDAL.DeleteMultistore(model);
        }
    }
}
