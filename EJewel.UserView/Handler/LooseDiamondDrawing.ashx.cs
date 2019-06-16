using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
//using model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Controller.Admin.Master.Stone;
//

using EJewel.Model.Admin.Master.Setting;
using EJewel.Controller.Admin.Master.Setting;
namespace EJewel.UserView.Handler
{
    /// <summary>
    /// Summary description for LooseDiamondDrawing
    /// </summary>
    public class LooseDiamondDrawing : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string qs_sku = context.Request.QueryString["SKU"];
            string qs_type = context.Request.QueryString["type"];
            if(qs_sku!="" && qs_type!="")
            {
                CenterStoneController objController = new CenterStoneController();
                CenterStoneModel modelCenterStone = objController.GetCenterStoneDetailsFromSKU(qs_sku);
                if(modelCenterStone!=null)
                {
                    //access the loose diamond details
                    LooseDiamondShapeController objLooseDiamond = new LooseDiamondShapeController();
                    LooseDiamondShapeModel modeLooselShape = objLooseDiamond.GetLooseDiamondShape(modelCenterStone.StoneShapeId).FirstOrDefault();
                    if(modeLooselShape!=null)
                    {
                        int type=Convert.ToInt32(qs_type);
                        if(modelCenterStone.StoneShape=="Round")
                        {
                            context.Response.ContentType = "image/png";
                            if(type==1)
                            {
                                //for first image
                                string image_path = context.Server.MapPath("~/" + modeLooselShape.ShapeScreechImage1Large);
                                Bitmap btm = this.GenerateRoundShape(image_path, modelCenterStone,1);
                                btm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            else if(type==2)
                            {
                                //for 2nd image
                                string image_path = context.Server.MapPath("~/" + modeLooselShape.ShapeScreechImage2Large);
                                Bitmap btm = this.GenerateRoundShape(image_path, modelCenterStone, 2);
                                btm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            
                        }
                    }
                }
            }
        }

        private Bitmap GenerateRoundShape(string image_path, CenterStoneModel modelCenterStone,int type)
        {
            //point of the table
            Bitmap bitmap = new Bitmap(image_path);
            Graphics graphics = Graphics.FromImage(bitmap);
            Font arialFont = new Font("Courier", 10, FontStyle.Regular);
            if (type == 1)
            {
                //draw points
                Point pointTable = new Point(170, 27);
                Point pointDepth = new Point(50, 115);
                Point pointCuelt = new Point(170, 210);
                Point pointGridle = new Point(215, 165);
                //
                graphics.DrawString(modelCenterStone.CertificateTable + " %", arialFont, Brushes.Black, pointTable);
                graphics.DrawString(modelCenterStone.CertificateDepth + " %", arialFont, Brushes.Black, pointDepth);
                graphics.DrawString(modelCenterStone.CertificateCulet, arialFont, Brushes.Black, pointCuelt);
                graphics.DrawString(modelCenterStone.CertificateGridle, arialFont, Brushes.Black, pointGridle);
            }
            else if(type==2)
            {
                //draw points
                Point pointWidth = new Point(170, 27);
                Point pointHeight = new Point(50, 115);
                Point pointCuelt = new Point(170, 210);
                Point pointGridle = new Point(215, 165);
                //
                graphics.DrawString(modelCenterStone.CertificateTable + " %", arialFont, Brushes.Black, pointWidth);
                graphics.DrawString(modelCenterStone.CertificateDepth + " %", arialFont, Brushes.Black, pointHeight);
                graphics.DrawString(modelCenterStone.CertificateCulet, arialFont, Brushes.Black, pointCuelt);
                graphics.DrawString(modelCenterStone.CertificateGridle, arialFont, Brushes.Black, pointGridle);
            }
            return bitmap;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}