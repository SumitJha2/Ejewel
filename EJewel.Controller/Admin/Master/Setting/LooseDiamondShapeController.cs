using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//model

using EJewel.Model.Admin.Master.Setting;
//dal
using EJewel.DAL.Admin.Master.Setting;

namespace EJewel.Controller.Admin.Master.Setting
{
    public class LooseDiamondShapeController
    {
        LooseDiamondShapeDAL objDAL = new LooseDiamondShapeDAL();

        public List<LooseDiamondShapeModel> GetLooseDiamondShape(int shape_id)
        {
            return objDAL.GetLooseDiamondShape(shape_id);
        }
    }
}
