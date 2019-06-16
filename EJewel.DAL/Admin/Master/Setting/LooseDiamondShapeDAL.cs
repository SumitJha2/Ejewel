using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//

using EJewel.Model.Admin.Master.Setting;

namespace EJewel.DAL.Admin.Master.Setting
{
    public class LooseDiamondShapeDAL
    {
        EJewelEntities objEntity = new EJewelEntities();

        public List<LooseDiamondShapeModel> GetLooseDiamondShape(int shape_id)
        {
            List<LooseDiamondShapeModel> lstModel = new List<LooseDiamondShapeModel>();
            try
            {
                List<ej_LooseDiamondShape> lstObj = null;
                if (shape_id > 0)
                {
                    lstObj = objEntity.ej_LooseDiamondShape.Where(tbl => tbl.ShapeId == shape_id).ToList();
                }
                else
                {
                    lstObj = objEntity.ej_LooseDiamondShape.Select(tbl => tbl).ToList();
                }
                if (lstObj != null)
                {
                    lstModel = (from looseDiamond in lstObj
                                join shape in objEntity.ej_StoneShape
                                on looseDiamond.ShapeId equals shape.StoneShapeId
                                where shape.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND &&
                                shape.Status == true
                                select new LooseDiamondShapeModel()
                                {
                                    Shape = "",
                                    ShapeId = shape.StoneShapeId,
                                    ShapeOrginalImage1 = looseDiamond.ShapeOrginalImage1,
                                    ShapeOrginalImage2 = looseDiamond.ShapeOrginalImage2,
                                    ShapeScreechImage1Large = looseDiamond.ShapeScreechImage1Large,
                                    ShapeScreechImage1Small = looseDiamond.ShapeScreechImage1Small,
                                    ShapeScreechImage2Large = looseDiamond.ShapeScreechImage2Large,
                                    ShapeScreechImage2Small = looseDiamond.ShapeScreechImage2Small,
                                    ShapeSmallIcon = looseDiamond.ShapeSmallIcon,
                                    ShapeVideo = looseDiamond.ShapeVideo
                                }).ToList();
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
            return lstModel;
        }
    }
}
