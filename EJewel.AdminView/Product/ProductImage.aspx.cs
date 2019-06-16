using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
//controller
using EJewel.Controller.Admin.Master.Category;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Common;
using EJewel.Controller.Admin.Master.Metal;
using EJewel.Controller.Admin.Common.Sfm;
using EJewel.Controller.Admin.Master.Stone;
//model
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Master.Category;
using EJewel.Model.Admin.Master.Metal;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Model.Admin.Master.Stone;

using System.IO;
using System.Data.OleDb;

namespace EJewel.AdminView.Product
{
    public partial class ProductImage : System.Web.UI.Page
    {
        ProductDetailsController objController = new ProductDetailsController();
        ProductImageController objImageController = new ProductImageController();
        StoneSpecificationController objStoneSpecificationController = new StoneSpecificationController();
        SideStoneController objSideStoneController = new SideStoneController();
        ProductImageManagerController objProductImageManagerController = new ProductImageManagerController();
        long _productID = 0;
        public int _totalImage = 0;
        const int COLSPAN = 3;
        int ORIENTATION = 6;
        string PRODUCT_SKU = "",product_title="";
        List<ProductImageManagerModel> lstProductImageManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Guid.NewGuid().ToString());
            try
            {
                if (Session["loginID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("/Default.aspx");
                }
                string pID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(pID))
                {
                    _productID = Convert.ToInt64(pID.Trim());
                    ProductDetailsModel productModel = objController.GetProductList(_productID).FirstOrDefault();
                    if (productModel != null)
                    {
                        PRODUCT_SKU = productModel.SKU.ToUpper().Trim();
                        product_title = productModel.ProductTitle;
                        if (!IsPostBack)
                        {
                            lstProductImageManager = objProductImageManagerController.ProductImageListFromProduct(_productID, CommonModel.RecordStatus.Both);
                            ltrlHeading.Text = productModel.SKU + " / " + productModel.ProductTitle;
                            //show the total image
                            //_totalImage = lstImageName.Items.Count;
                            //load no of item in ddl
                            for(int i=1;i<=20;i++)
                            {
                                ddlAngle.Items.Add(new ListItem(i.ToString(), i.ToString()));
                            }
                            string no = Convert.ToString(Request.QueryString["angles"]);
                            if (!string.IsNullOrEmpty(no))
                            {
                                ddlAngle.SelectedValue = no;
                                ORIENTATION = Convert.ToInt32(no);
                                //create the table str
                                this.CreateTableStr(_productID);
                            }
                        }
                        string qs_status = Request.QueryString["status"];
                        if(!string.IsNullOrEmpty(qs_status))
                        {
                            if (qs_status == "success")
                            {
                                lblMessage.Text = "Image Imported successfully.";
                            }
                            else if(qs_status=="error")
                            {
                                lblMessage.Text = "Error in Import.";
                            }
                        }

                    }
                    else
                    {
                        //error 
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        private void CreateTableStr(long productId)
        {
            try
            {
                //Some Constant
                //1 For DIAMONDS
                //2 For GEMSTONE
                //get Metal Type
                List<MetalTypeListModel> lstMetalType = objImageController.GetMetalTypeList(productId);
                //get stone shape model
                List<StoneSpecificationModel> lstStoneShapeModel = objStoneSpecificationController.GetStoneSpecificationListForShape(0, StoneShapeModel.ShapeVisibility.BOTH, CommonModel.RecordStatus.Enabled);
                List<StoneSpecificationModel> lstStoneShapeModelDiamonds = lstStoneShapeModel.Where(tbl => tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND).ToList();
                List<StoneSpecificationModel> lstStoneShapeModelGemStone = lstStoneShapeModel.Where(tbl => tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE).ToList();
                //get stone type model
                List<StoneSpecificationModel> lstStoneTypeModel = new StoneSpecificationController().GetStoneSpecificationList(0, StoneSpecificationModel.PageName.Type, CommonModel.RecordStatus.Enabled);
                //N.B. stone type only in case of gem stone for diamonds (in future) 2 for gem stone
                List<StoneSpecificationModel> lstStoneTypeModelGemStone = lstStoneTypeModel.Where(tbl => tbl.StoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE).ToList();
                //get product center stone details
                //N.b. This Center Shape only in case of center stone diamonds
                List<StoneSpecificationModel> lstCenterStoneDiamondList = objImageController.GetProductCenterStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, lstStoneShapeModelDiamonds);
                //get stone details
                List<SideStoneModel> lstStoneDiamondList = objSideStoneController.GetSideStoneListFromCategory(ConstantHelper.STONE_CATEGORY_DIAMOND, CommonModel.RecordStatus.Enabled);
                List<SideStoneModel> lstStoneGemStoneList = objSideStoneController.GetSideStoneListFromCategory(ConstantHelper.STONE_CATEGORY_GEMSTONE, CommonModel.RecordStatus.Enabled);
                //For Side Stone
                List<ProductSideStoneImageModel> lstSideStoneDiamondList = objImageController.GetProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_DIAMOND, lstStoneDiamondList, SideStoneActionModel.PageName.SideStone);
                List<ProductSideStoneImageModel> lstSideStoneGemStoneList = objImageController.GetProductSideStoneList(productId, ConstantHelper.STONE_CATEGORY_GEMSTONE, lstStoneGemStoneList, SideStoneActionModel.PageName.SideStone);
                //get matching band
                //
                //now create table str
                int total_metal_type = lstMetalType.Count;
                if (total_metal_type > 0)
                {
                    DataTable table = this.InitTable();
                    //center stone count
                    int total_diamond_center_stone = lstCenterStoneDiamondList.Count;
                    //get side stone count
                    int total_side_stone_diamond = lstSideStoneDiamondList.Count;
                    int total_side_stone_gemstone = lstSideStoneGemStoneList.Count;
                    if (total_metal_type > 0)
                    {
                        #region Center Stone

                        if (total_diamond_center_stone > 0)
                        {
                            #region For side stone

                            //for all diamond
                            if (total_side_stone_diamond == 0 && total_side_stone_gemstone == 0)
                            {
                                //create only center stone (Solitire Ring)
                                this.CreateCenterStoneImageStr(lstMetalType, lstCenterStoneDiamondList, table);
                            }
                            else
                            {
                                if (total_side_stone_gemstone > 0)
                                {
                                    //for only gems stone side stone
                                    this.CreateSideStoneImageStr3(table, lstMetalType, lstCenterStoneDiamondList, lstSideStoneDiamondList, lstSideStoneGemStoneList, ConstantHelper.STONE_CATEGORY_GEMSTONE);
                                }
                                else if (total_side_stone_diamond > 0)
                                {
                                    //for only diamond side stone
                                    this.CreateSideStoneImageStr3(table, lstMetalType, lstCenterStoneDiamondList, lstSideStoneDiamondList, lstSideStoneGemStoneList, ConstantHelper.STONE_CATEGORY_DIAMOND);
                                }
                            }
                            //for center stone loop
                            #endregion
                        }
                        else
                        {
                            #region Without Side Stone
                            //if apps not have any center stone
                            if (total_side_stone_gemstone > 0)
                            {
                                //for only gems stone side stone
                                this.CreateSideStoneImageStr3(table, lstMetalType, lstCenterStoneDiamondList, lstSideStoneDiamondList, lstSideStoneGemStoneList, ConstantHelper.STONE_CATEGORY_GEMSTONE);
                            }
                            else if (total_side_stone_diamond > 0)
                            {
                                //for only diamond side stone
                                this.CreateSideStoneImageStr3(table, lstMetalType, lstCenterStoneDiamondList, lstSideStoneDiamondList, lstSideStoneGemStoneList, ConstantHelper.STONE_CATEGORY_DIAMOND);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    gridViewImages.DataSource = table;
                    gridViewImages.DataBind();
                    gridViewImages.HeaderRow.TableSection = TableRowSection.TableHeader;
                    _totalImage = gridViewImages.Rows.Count;
                }
            }
            catch(Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }

        }

        private void CreateCenterStoneImageStrOld(MetalTypeListModel metalTypeModel, List<StoneSpecificationModel> lstCenterStoneShape,DataTable table)
        {
            int total = lstCenterStoneShape.Count;
            if (total > 0)
            {
                string image_name = "", guid = "";
                //create center stone label
                for (int i = 0; i < total; i++)
                {
                    //create center  stone heading
                    image_name = metalTypeModel.MetalTypeName + " > " + lstCenterStoneShape[i].Name;
                    guid = metalTypeModel.MetalTypeId + "-" + lstCenterStoneShape[i].AutoID;
                    this.AddRow(table, guid, image_name);
                }
            }
        }

        private void CreateCenterStoneImageStr(List<MetalTypeListModel> lstmetalTypeModel, List<StoneSpecificationModel> lstCenterStoneShape, DataTable table)
        {
            int total_metal = lstmetalTypeModel.Count;
            int total_center_stone_shape = lstCenterStoneShape.Count;
            string image_name = "", guid = "";
            for (int i = 0; i < total_metal; i++)
            {
                for (int j = 0; j < total_center_stone_shape; j++)
                {
                    //create center  stone heading
                    image_name = lstmetalTypeModel[i].MetalTypeName + " > " + lstCenterStoneShape[j].Name;
                    guid = lstmetalTypeModel[i].MetalTypeId + "-" + lstCenterStoneShape[j].AutoID + "-0";
                    this.AddRow(table, guid, image_name);
                }
                //without center stone
                this.AddRow(table, lstmetalTypeModel[i].MetalTypeId + "-0-0", lstmetalTypeModel[i].MetalTypeName + "(Setting Only)");
            }
        }

        void AddRow(DataTable table, string guid, string image_name)
        {
            for (int i = 1; i <= ORIENTATION; i++)
            {
                DataRow row = table.NewRow();
                row["GUID"] = PRODUCT_SKU + "-" + guid + "-A" + i;
                row["ImageName"] = image_name;
                row["ImageAlt"] = "";
                row["Angle"] = "A" + i;
                row["ImagePath"] = "";
                table.Rows.Add(row);
                //add row
                if (Session["TABLE_EXPORT"] == null)
                {
                    Session["TABLE_EXPORT"] = table;
                }
                else
                {
                    Session["TABLE_EXPORT"] = table;
                }
            }
        }

        private void CreateSideStoneImageStr(DataTable table, MetalTypeListModel metalTypeModel, List<StoneSpecificationModel> lstCenterStoneShapeModel,List<ProductSideStoneImageModel> lstSideStoneModel,int stoneCategoryId)
        {
            int total_center_stone_shape = lstCenterStoneShapeModel.Count;
            int total_side_stone_shape = lstSideStoneModel.Count;
            string image_name = "", guid = "";
            List<string> lstSideStoneImage = null;
            List<string> lstSideStoneGUID = null;
            if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
            {
                //list init
                lstSideStoneImage = new List<string>();
                lstSideStoneGUID = new List<string>();
                //for center stone
                if (total_center_stone_shape > 0)
                {
                    for (int i = 0; i < total_center_stone_shape; i++)
                    {
                        image_name = guid = "";
                        StoneSpecificationModel centerStoneShapeModel = lstCenterStoneShapeModel[i];
                        if (centerStoneShapeModel != null)
                        {
                            for (int j = 0; j < total_side_stone_shape; j++)
                            {
                                image_name += lstSideStoneModel[j].Shape + " >>> White Diamond -";
                                guid += lstSideStoneModel[j].ShapeId + "-0";
                            }
                            //
                            if (image_name != "" && guid != "")
                            {
                                //remove last 
                                image_name = image_name.Substring(0, image_name.Length - 1);
                                //add in list
                                lstSideStoneImage.Add(image_name);
                                lstSideStoneGUID.Add(guid);
                                //add in list
                                string img_details = metalTypeModel.MetalTypeName + " > " + centerStoneShapeModel.Name + " >> " + image_name;
                                string guid_details = metalTypeModel.MetalTypeId + "-" + centerStoneShapeModel.AutoID +"-"+guid;
                                //add row
                                this.AddRow(table, guid_details, img_details);
                                //add no center diamond
                                img_details = metalTypeModel.MetalTypeName + " > (Setting Only) >> " + image_name;
                                guid_details = metalTypeModel.MetalTypeId + "-0-" + guid;
                                this.AddRow(table, guid_details, img_details);
                            }
                        }
                    }
                }
                else
                {
                    //for no center stone
                    for (int i = 0; i < total_side_stone_shape; i++)
                    {
                        image_name += lstSideStoneModel[i].Shape + " >>> White Diamond -";
                        guid += lstSideStoneModel[i].ShapeId + "-0";
                    }
                    if (image_name != "" && guid != "")
                    {
                        //remove last 
                        image_name = image_name.Substring(0, image_name.Length - 1);
                        //add in list
                        lstSideStoneImage.Add(image_name);
                        lstSideStoneGUID.Add(guid);
                        //add in list
                        string img_details = metalTypeModel.MetalTypeName + " >> " + image_name;
                        string guid_details = metalTypeModel.MetalTypeId + "-" + guid;
                        //add row
                        this.AddRow(table, guid_details, img_details);
                    }
                }
            }
            else if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
            {
                //get the customize stone type
                lstSideStoneModel = lstSideStoneModel.OrderByDescending(tbl => tbl.IsCustomize).ToList();
                ProductSideStoneImageModel productCustomizeStoneImage = lstSideStoneModel.Where(tbl => tbl.IsCustomize == true).FirstOrDefault();
                if (productCustomizeStoneImage != null)
                {
                    //list init
                    //get customize details
                    List<ProductSideStoneAvialableStoneTypeModel> lstProductSideStoneAvialableStoneType = objImageController.GetProductStoneTypeListFromSideStone(productCustomizeStoneImage.ProductSideStoneId, SideStoneActionModel.PageName.SideStone);
                    int total_customize_type = lstProductSideStoneAvialableStoneType.Count;
                    if (total_customize_type > 0)
                    {
                        //prepare customize image
                        List<string> lstCustomizeImageName = new List<string>();
                        List<string> lstCustomizeGUID = new List<string>();
                        //now add the shape in manner
                        string customize_image_name = "", customize_image_guid="";
                        for (int i = -1; i < total_customize_type; i++)
                        {
                            if (i == -1)
                            {
                                //add default as full diamond
                                customize_image_name = lstSideStoneModel[0].Shape + " >>> White Diamond";
                                customize_image_guid = lstSideStoneModel[0].ShapeId + "-0";
                            }
                            else
                            {
                                SideStoneModel sideStoneModel = objSideStoneController.GetSideStoneList(lstProductSideStoneAvialableStoneType[i].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                if (sideStoneModel != null)
                                {
                                    //for first element
                                    customize_image_name = lstSideStoneModel[0].Shape + " >>> " + sideStoneModel.StoneColor + " " + sideStoneModel.StoneType;
                                    customize_image_guid = lstSideStoneModel[0].ShapeId + "-" + sideStoneModel.SideStoneId;
                                }
                            }
                            for (int j = 1; j < total_side_stone_shape; j++)
                            {
                                customize_image_name += " - " + lstSideStoneModel[j].Shape + " >>> White Diamond";
                                customize_image_guid += lstSideStoneModel[j].ShapeId + "-0";
                            }
                            lstCustomizeImageName.Add(customize_image_name);
                            lstCustomizeGUID.Add(customize_image_guid);
                        }
                        //re init customize
                        total_customize_type = lstCustomizeImageName.Count;
                        if (total_center_stone_shape > 0)
                        {
                            for (int i = 0; i < total_center_stone_shape; i++)
                            {
                                image_name = guid = "";
                                StoneSpecificationModel centerStoneShapeModel = lstCenterStoneShapeModel[i];
                                if (centerStoneShapeModel != null)
                                {
                                    for (int j = 0; j < total_customize_type; j++)
                                    {
                                        image_name = metalTypeModel.MetalTypeName + " > " + centerStoneShapeModel.Name + " >> " + lstCustomizeImageName[j];
                                        guid = metalTypeModel.MetalTypeId + "-" + centerStoneShapeModel.AutoID + "-" + lstCustomizeGUID[j];
                                        //add row
                                        this.AddRow(table, guid, image_name);
                                    }
                                }
                            }

                            //add with out center stone
                            for (int i = 0; i < total_customize_type; i++)
                            {
                                //add in list
                                image_name = metalTypeModel.MetalTypeName + " > (Setting Only) >> " + lstCustomizeImageName[i];
                                guid = metalTypeModel.MetalTypeId + "-0-" + lstCustomizeGUID[i];
                                //add row
                                this.AddRow(table, guid, image_name);
                            }
                        }
                        else
                        {
                            //for no center stone
                            for (int j = 0; j < total_customize_type; j++)
                            {
                                image_name = metalTypeModel.MetalTypeName + " >> " + lstCustomizeImageName[j];
                                guid = metalTypeModel.MetalTypeId + "-" + lstCustomizeGUID[j];
                                //add row
                                this.AddRow(table, guid, image_name);
                            }
                        }
                    }
                }

            }
            
        }

        private void CreateSideStoneImageStr2(DataTable table, MetalTypeListModel metalTypeModel, List<StoneSpecificationModel> lstCenterStoneShapeModel, List<ProductSideStoneImageModel> lstProductSideStoneDiamond, List<ProductSideStoneImageModel> lstProductSideStoneGemstone, int stoneCategoryId)
        {
            int total_product_diamond = lstProductSideStoneDiamond.Count;
            int total_product_gemstone = lstProductSideStoneGemstone.Count;
            int total_center_stone_shape = lstCenterStoneShapeModel.Count;
            string image_name = "", guid = "";
            if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
            {
                #region For Diamond
                //list init
                //for center stone
                if (total_center_stone_shape > 0)
                {
                    #region For Center Stone
                    for (int i = 0; i < total_center_stone_shape; i++)
                    {
                        image_name = guid = "";
                        StoneSpecificationModel centerStoneShapeModel = lstCenterStoneShapeModel[i];
                        if (centerStoneShapeModel != null)
                        {
                            for (int j = 0; j < total_product_diamond; j++)
                            {
                                image_name += lstProductSideStoneDiamond[j].Shape + " >>> White Diamond -";
                                guid += lstProductSideStoneDiamond[j].ShapeId + "-0";
                            }
                            //
                            if (image_name != "" && guid != "")
                            {
                                //remove last 
                                image_name = image_name.Substring(0, image_name.Length - 1);
                                //add in list
                                //add in list
                                string img_details = metalTypeModel.MetalTypeName + " > " + centerStoneShapeModel.Name + " >> " + image_name;
                                string guid_details = metalTypeModel.MetalTypeId + "-" + centerStoneShapeModel.AutoID + "-" + guid;
                                //add row
                                this.AddRow(table, guid_details, img_details);
                                //add no center diamond
                                img_details = metalTypeModel.MetalTypeName + " > (Setting Only) >> " + image_name;
                                guid_details = metalTypeModel.MetalTypeId + "-0-" + guid;
                                this.AddRow(table, guid_details, img_details);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region For No Center Stone
                    //for no center stone
                    for (int i = 0; i < total_product_diamond; i++)
                    {
                        image_name += lstProductSideStoneDiamond[i].Shape + " >>> White Diamond -";
                        guid += lstProductSideStoneDiamond[i].ShapeId + "-0";
                    }
                    if (image_name != "" && guid != "")
                    {
                        //remove last 
                        image_name = image_name.Substring(0, image_name.Length - 1);
                        //add in list
                        //add in list
                        string img_details = metalTypeModel.MetalTypeName + " >> " + image_name;
                        string guid_details = metalTypeModel.MetalTypeId + "-" + guid;
                        //add row
                        this.AddRow(table, guid_details, img_details);
                    }
                    #endregion
                }
                #endregion
            }
            else if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
            {
                //get the customize stone type
                lstProductSideStoneGemstone = lstProductSideStoneGemstone.OrderByDescending(tbl => tbl.IsCustomize).ToList();
                //get the customization
                ProductSideStoneImageModel productCustomizeStoneImage = lstProductSideStoneGemstone.Where(tbl => tbl.IsCustomize == true).FirstOrDefault();
                if (productCustomizeStoneImage != null)
                {
                    //list init
                    //get customize details
                    List<ProductSideStoneAvialableStoneTypeModel> lstProductSideStoneAvialableStoneType = objImageController.GetProductStoneTypeListFromSideStone(productCustomizeStoneImage.ProductSideStoneId, SideStoneActionModel.PageName.SideStone);
                    int total_customize_type = lstProductSideStoneAvialableStoneType.Count;
                    if (total_customize_type > 0)
                    {
                        List<long> lstDiamondContainID = null, lstGemstoneContainID = null;
                        //this function get the same shape
                        this.JustCompareShape(lstProductSideStoneDiamond, lstProductSideStoneGemstone, out lstDiamondContainID, out lstGemstoneContainID);
                        List<ProductSideStoneImageModel> lstRemainProductSideStoneDiamond = lstProductSideStoneDiamond.Where(tbl => !lstDiamondContainID.Contains(tbl.ProductSideStoneId)).ToList();


                        List<string> lstShapes = new List<string>();
                        List<string> lstColorType = new List<string>();
                        //
                        List<string> lstExtraShapes = new List<string>();
                        List<string> lstExtraColorType = new List<string>();
                        //
                        List<string> lstTempShapes = new List<string>();
                        List<string> lstTempColorType = new List<string>();
                        //
                        List<string> lstGuidShape = new List<string>();
                        List<string> lstGuidSideStone = new List<string>();
                        //for extra shapes
                        if (lstRemainProductSideStoneDiamond != null)
                        {
                            int total_extra_shapes = lstRemainProductSideStoneDiamond.Count;
                            for (int i = 0; i < total_extra_shapes; i++)
                            {
                                lstExtraShapes.Add(lstRemainProductSideStoneDiamond[i].Shape);
                                lstExtraColorType.Add("White Diamond");
                            }
                        }
                        string shapes_image_name = "";
                        for (int i = 0; i < total_customize_type; i++)
                        {
                            //init
                            shapes_image_name = "";
                            SideStoneModel sideStoneModel = objSideStoneController.GetSideStoneList(lstProductSideStoneAvialableStoneType[i].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                            if (sideStoneModel != null)
                            {
                                //clear list
                                lstShapes.Clear();
                                lstColorType.Clear();
                                //
                                lstTempShapes.Clear();
                                lstTempColorType.Clear();
                                //guid
                                lstGuidShape.Add(productCustomizeStoneImage.ShapeId.ToString());
                                lstGuidSideStone.Add(sideStoneModel.SideStoneId.ToString());
                                //
                                for (int j = 0; j < total_product_gemstone; j++)
                                {
                                    //add shapes
                                    lstShapes.Add(lstProductSideStoneGemstone[j].Shape);
                                    lstColorType.Add(sideStoneModel.StoneColor + " " + sideStoneModel.StoneType);
                                }
                                //for shape
                                lstTempShapes.AddRange(lstShapes);
                                lstTempShapes.AddRange(lstExtraShapes);
                                //for color and type
                                lstTempColorType.AddRange(lstColorType);
                                lstTempColorType.AddRange(lstExtraColorType);
                                //here we get the shapes
                                int total_customize_shapes = lstTempShapes.Count;
                                for (int k = 0; k < total_customize_shapes; k++)
                                {
                                    shapes_image_name += lstTempShapes[k] + "->" + lstTempColorType[k] + ",";
                                }
                                if (shapes_image_name.Length > 0)
                                {
                                    //remove last comma
                                    shapes_image_name = shapes_image_name.Substring(0, shapes_image_name.Length - 1);
                                    //for center stone shape
                                    if (total_center_stone_shape > 0)
                                    {
                                        for (int l = 0; l < total_center_stone_shape; l++)
                                        {
                                            StoneSpecificationModel centerStoneShapeModel = lstCenterStoneShapeModel[l];
                                            if (centerStoneShapeModel != null)
                                            {
                                                image_name = metalTypeModel.MetalTypeName + " > " + centerStoneShapeModel.Name + " >> " + shapes_image_name;
                                                this.AddRow(table, "", image_name);
                                            }
                                        }
                                    }
                                    //for no center stone
                                    image_name = metalTypeModel.MetalTypeName + " > (Setting Only) >> " + shapes_image_name;
                                    this.AddRow(table, "", image_name);
                                }
                            }
                        }
                    }
                }

            }

        }

        private void CreateSideStoneImageStr3(DataTable table, List<MetalTypeListModel> lstMetalTypeModel, List<StoneSpecificationModel> lstCenterStoneShapeModel, List<ProductSideStoneImageModel> lstProductSideStoneDiamond, List<ProductSideStoneImageModel> lstProductSideStoneGemstone, int stoneCategoryId)
        {
            int total_metal = lstMetalTypeModel.Count;
            int total_product_diamond = lstProductSideStoneDiamond.Count;
            int total_product_gemstone = lstProductSideStoneGemstone.Count;
            int total_center_stone_shape = lstCenterStoneShapeModel.Count;
            string image_name = "", guid = "";
            if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_DIAMOND)
            {
                #region For Diamond
                //list init
                //for center stone
                if (total_center_stone_shape > 0)
                {
                    #region For Center Stone
                    for (int m = 0; m < total_metal; m++)
                    {
                        for (int i = 0; i < total_center_stone_shape; i++)
                        {
                            image_name = guid = "";
                            StoneSpecificationModel centerStoneShapeModel = lstCenterStoneShapeModel[i];
                            if (centerStoneShapeModel != null)
                            {
                                for (int j = 0; j < total_product_diamond; j++)
                                {
                                    image_name += lstProductSideStoneDiamond[j].Shape + " -> White Diamond ,";
                                    //guid += lstProductSideStoneDiamond[j].ShapeId + "-0-";
                                    guid += "0-";
                                }
                                //
                                if (image_name != "" && guid != "")
                                {
                                    //remove last 
                                    image_name = image_name.Substring(0, image_name.Length - 1);
                                    guid = guid.Substring(0, guid.Length - 1);
                                    //add in list
                                    string img_details = lstMetalTypeModel[m].MetalTypeName + " > " + centerStoneShapeModel.Name + " >> " + image_name;
                                    string guid_details = lstMetalTypeModel[m].MetalTypeId + "-" + centerStoneShapeModel.AutoID + "-" + guid;
                                    /*
                                     * This will add only one times
                                     * becuase one shape for one metal
                                    */
                                    if (i == 0)
                                    {
                                        this.AddRow(table, lstMetalTypeModel[m].MetalTypeId + "-0-" + guid, lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + image_name);
                                    }
                                    //add row
                                    this.AddRow(table, guid_details, img_details);
                                    //add no center diamond
                                    //this will add only one time

                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region For No Center Stone
                    //for no center stone
                    for (int i = 0; i < total_product_diamond; i++)
                    {
                        image_name += lstProductSideStoneDiamond[i].Shape + " -> White Diamond ,";
                        //guid += lstProductSideStoneDiamond[i].ShapeId + "-0-0-";
                        guid += "0-0-";
                    }
                    if (image_name != "" && guid != "")
                    {
                        //remove last 
                        image_name = image_name.Substring(0, image_name.Length - 1);
                        guid = guid.Substring(0, guid.Length - 1);
                        //add in list
                        //add in list
                        for (int m = 0; m < total_metal; m++)
                        {
                            string img_details = lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + image_name;
                            string guid_details = lstMetalTypeModel[m].MetalTypeId + "-" + guid;
                            //add row
                            this.AddRow(table, guid_details, img_details);
                        }
                    }
                    #endregion
                }
                #endregion
            }
            else if (stoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
            {
                //get the customize stone type
                lstProductSideStoneGemstone = lstProductSideStoneGemstone.OrderBy(tbl => tbl.IsCustomize).ToList();
                //get the customization
                ProductSideStoneImageModel productCustomizeStoneImage = lstProductSideStoneGemstone.Where(tbl => tbl.IsCustomize == true).FirstOrDefault();
                if (productCustomizeStoneImage != null)
                {
                    //list init
                    //get customize details
                    List<ProductSideStoneAvialableStoneTypeModel> lstProductSideStoneAvialableStoneType = objImageController.GetProductStoneTypeListFromSideStone(productCustomizeStoneImage.ProductSideStoneId, SideStoneActionModel.PageName.SideStone);
                    int total_customize_type = lstProductSideStoneAvialableStoneType.Count;
                    if (total_customize_type > 0)
                    {
                        List<long> lstDiamondContainID = null, lstGemstoneContainID = null;
                        //this function get the same shape
                        this.JustCompareShape(lstProductSideStoneDiamond, lstProductSideStoneGemstone, out lstDiamondContainID, out lstGemstoneContainID);
                        List<ProductSideStoneImageModel> lstRemainProductSideStoneDiamond = lstProductSideStoneDiamond.Where(tbl => !lstDiamondContainID.Contains(tbl.ProductSideStoneId)).ToList();

                        List<string> lstShapes = new List<string>();
                        List<string> lstColorType = new List<string>();
                        //
                        List<string> lstExtraShapes = new List<string>();
                        List<string> lstExtraColorType = new List<string>();
                        //
                        List<string> lstTempShapes = new List<string>();
                        List<string> lstTempColorType = new List<string>();
                        //
                        List<string> lstGuidShape = new List<string>();
                        List<string> lstGuidSideStone = new List<string>();
                        //for extra shapes
                        if (lstRemainProductSideStoneDiamond != null)
                        {
                            int total_extra_shapes = lstRemainProductSideStoneDiamond.Count;
                            for (int i = 0; i < total_extra_shapes; i++)
                            {
                                lstExtraShapes.Add(lstRemainProductSideStoneDiamond[i].Shape);
                                lstExtraColorType.Add("White Diamond");
                            }
                        }
                        string shapes_image_name = "", shapes_diamond_image_name = "";
                        //get metal type
                        int current_center_stone_shape = 0, current_metal = 0, current_metal2 = 0;
                        for (int m = 0; m < total_metal; m++)
                        {
                            current_metal2 = lstMetalTypeModel[m].MetalTypeId;
                            if (total_center_stone_shape > 0)
                            {
                                #region For Center Stone
                                //get center stone shape
                                for (int css = 0; css < total_center_stone_shape; css++)
                                {
                                    //show the 
                                    if (css != 0)
                                    {
                                        current_center_stone_shape = lstCenterStoneShapeModel[css].AutoID;
                                    }
                                    //for total customize
                                    for (int cmz = 0; cmz < total_customize_type; cmz++)
                                    {
                                        SideStoneModel sideStoneModel = objSideStoneController.GetSideStoneList(lstProductSideStoneAvialableStoneType[cmz].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                        if (sideStoneModel != null)
                                        {
                                            //clear
                                            shapes_image_name = shapes_diamond_image_name = "";
                                            //clear list
                                            lstShapes.Clear();
                                            lstColorType.Clear();
                                            //
                                            lstTempShapes.Clear();
                                            lstTempColorType.Clear();
                                            //guid
                                            lstGuidShape.Add(productCustomizeStoneImage.ShapeId.ToString());
                                            lstGuidSideStone.Add(sideStoneModel.SideStoneId.ToString());
                                            //
                                            for (int tpc = 0; tpc < total_product_gemstone; tpc++)
                                            {
                                                //add shapes
                                                lstShapes.Add(lstProductSideStoneGemstone[tpc].Shape);
                                                lstColorType.Add(sideStoneModel.StoneColor + " " + sideStoneModel.StoneType);
                                            }
                                            //for shape
                                            lstTempShapes.AddRange(lstShapes);
                                            lstTempShapes.AddRange(lstExtraShapes);
                                            //for color and type
                                            lstTempColorType.AddRange(lstColorType);
                                            lstTempColorType.AddRange(lstExtraColorType);
                                            //here we get the shapes
                                            int total_customize_shapes = lstTempShapes.Count;

                                            for (int tcs = 0; tcs < total_customize_shapes; tcs++)
                                            {
                                                shapes_image_name += lstTempShapes[tcs] + "->" + lstTempColorType[tcs] + ",";
                                                shapes_diamond_image_name += lstTempShapes[tcs] + "->" + "White Diamond,";
                                            }
                                            if (shapes_image_name.Length > 0)
                                            {
                                                //remove last comma
                                                shapes_image_name = shapes_image_name.Substring(0, shapes_image_name.Length - 1);
                                                shapes_diamond_image_name = shapes_diamond_image_name.Substring(0, shapes_diamond_image_name.Length - 1);
                                                //for center stone shape
                                                if (current_center_stone_shape != lstCenterStoneShapeModel[css].AutoID)
                                                {
                                                    //for all diamond
                                                    image_name = lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + shapes_diamond_image_name;
                                                    //guid = lstMetalTypeModel[m].MetalTypeId + "-0-0-0";
                                                    guid = lstMetalTypeModel[m].MetalTypeId + "-0-0";
                                                    this.AddRow(table, guid, image_name);
                                                }
                                                //change the shape
                                                current_center_stone_shape = lstCenterStoneShapeModel[css].AutoID;
                                                if (cmz==0)
                                                {
                                                    //this is only for first metal
                                                    //for shape diamond name
                                                    image_name = lstMetalTypeModel[m].MetalTypeName + " >" + lstCenterStoneShapeModel[css].Name + " >> " + shapes_diamond_image_name;
                                                    //guid = lstMetalTypeModel[m].MetalTypeId + "-0-0-0";
                                                    guid = lstMetalTypeModel[m].MetalTypeId + "-" + lstCenterStoneShapeModel[css].AutoID + "-0";
                                                    this.AddRow(table, guid, image_name);
                                                }
                                                //chnage metal
                                                //current_metal = lstMetalTypeModel[m].MetalTypeId;
                                                //for other
                                                if (css == 0 && current_metal2 == lstMetalTypeModel[m].MetalTypeId)
                                                {
                                                    //for gemstone no center stone
                                                    image_name = lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + shapes_image_name;
                                                    //guid = lstMetalTypeModel[m].MetalTypeId + "-0-0-0";
                                                    guid = lstMetalTypeModel[m].MetalTypeId + "-0-" + sideStoneModel.SideStoneId;
                                                    this.AddRow(table, guid, image_name);
                                                }
                                                //for gemstone
                                                image_name = lstMetalTypeModel[m].MetalTypeName + " > " + lstCenterStoneShapeModel[css].Name + " >> " + shapes_image_name;
                                                guid = lstMetalTypeModel[m].MetalTypeId + "-" + lstCenterStoneShapeModel[css].AutoID + "-" + sideStoneModel.SideStoneId;
                                                this.AddRow(table, guid, image_name);
                                            }
                                        }
                                    }
                                }
                                //chnage the css   
                                current_metal = 0;
                            #endregion
                            }
                            else
                            {
                                #region Without Center Stone
                                //for without center stone
                                //for total customize
                                for (int cmz = 0; cmz < total_customize_type; cmz++)
                                {
                                    SideStoneModel sideStoneModel = objSideStoneController.GetSideStoneList(lstProductSideStoneAvialableStoneType[cmz].StoneId, CommonModel.RecordStatus.Enabled).FirstOrDefault();
                                    if (sideStoneModel != null)
                                    {
                                        //clear
                                        shapes_image_name = shapes_diamond_image_name = "";
                                        //clear list
                                        lstShapes.Clear();
                                        lstColorType.Clear();
                                        //
                                        lstTempShapes.Clear();
                                        lstTempColorType.Clear();
                                        //guid
                                        lstGuidShape.Add(productCustomizeStoneImage.ShapeId.ToString());
                                        lstGuidSideStone.Add(sideStoneModel.SideStoneId.ToString());
                                        //
                                        for (int tpc = 0; tpc < total_product_gemstone; tpc++)
                                        {
                                            //add shapes
                                            lstShapes.Add(lstProductSideStoneGemstone[tpc].Shape);
                                            lstColorType.Add(sideStoneModel.StoneColor + " " + sideStoneModel.StoneType);
                                        }
                                        //for shape
                                        lstTempShapes.AddRange(lstShapes);
                                        lstTempShapes.AddRange(lstExtraShapes);
                                        //for color and type
                                        lstTempColorType.AddRange(lstColorType);
                                        lstTempColorType.AddRange(lstExtraColorType);
                                        //here we get the shapes
                                        int total_customize_shapes = lstTempShapes.Count;
                                        for (int tcs = 0; tcs < total_customize_shapes; tcs++)
                                        {
                                            shapes_image_name += lstTempShapes[tcs] + "->" + lstTempColorType[tcs] + ",";
                                            shapes_diamond_image_name += lstTempShapes[tcs] + "->" + "White Diamond,";
                                        }
                                        if (shapes_image_name.Length > 0)
                                        {
                                            //remove last comma
                                            shapes_image_name = shapes_image_name.Substring(0, shapes_image_name.Length - 1);
                                            shapes_diamond_image_name = shapes_diamond_image_name.Substring(0, shapes_diamond_image_name.Length - 1);
                                            //for center stone shape
                                            if (cmz == 0)
                                            {
                                                //for all diamond
                                                image_name = lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + shapes_diamond_image_name;
                                                //guid = lstMetalTypeModel[m].MetalTypeId + "-0-0-0";
                                                guid = lstMetalTypeModel[m].MetalTypeId + "-0-0";
                                                this.AddRow(table, guid, image_name);
                                            }
                                            //for other
                                            //for gemstone no center stone
                                            image_name = lstMetalTypeModel[m].MetalTypeName + " > (Setting Only) >> " + shapes_image_name;
                                            //guid = lstMetalTypeModel[m].MetalTypeId + "-0-0-0";
                                            guid = lstMetalTypeModel[m].MetalTypeId + "-0-" + sideStoneModel.SideStoneId;
                                            this.AddRow(table, guid, image_name);
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }
            }

        }

        private void JustCompareShape(List<ProductSideStoneImageModel> lstProductSideStoneDiamond, List<ProductSideStoneImageModel> lstProductSideStoneGemstone,out List<long> lstDiamondContainID,out List<long> lstGemstoneContainID)
        {
            lstDiamondContainID = new List<long>();
            lstGemstoneContainID = new List<long>();
            //
            int total_diamond = lstProductSideStoneDiamond.Count;
            int total_gemstone = lstProductSideStoneGemstone.Count;
            ProductSideStoneImageModel diamondModel = null, gemStoneModel = null;
            for(int i=0;i<total_diamond;i++)
            {
                diamondModel = lstProductSideStoneDiamond[i];
                //access the shape of the
                for(int j=0;j<total_gemstone;j++)
                {
                    gemStoneModel = lstProductSideStoneGemstone[j];

                    if(diamondModel!=null && gemStoneModel!=null)
                    {
                        if(diamondModel.Shape==gemStoneModel.Shape)
                        {
                            //add product diamond side stone
                            lstDiamondContainID.Add(diamondModel.ProductSideStoneId);
                            //add product gemstone side stone
                            lstGemstoneContainID.Add(gemStoneModel.ProductSideStoneId);
                            break;
                        }
                    }
                }
            }
        }

        DataTable InitTable()
        {
            //session
            DataTable table = new DataTable();
            table.Columns.Add("GUID");
            table.Columns.Add("ImageName");
            table.Columns.Add("ImageAlt");
            table.Columns.Add("Angle");
            table.Columns.Add("ImagePath");
            return table;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["TABLE_EXPORT"] != null)
                {
                    DataTable table = new DataTable();
                    table = (DataTable)Session["TABLE_EXPORT"];
                    DataSet ds = new DataSet();
                    ds.Clear();
                    ds.Tables.Add(table);
                    this.ExportToExcel(ds, PRODUCT_SKU);
                }
            }
            catch(Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
                Response.Redirect("/Product/ProductImage.aspx?id="+_productID);
            }
        }
        //
        private void ExportToExcel(DataSet ds, string sku)
        {
            try
            {
                string attachment = "attachment; filename=" + sku + ".xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                MemoryStream m = new MemoryStream();
                ExcelLibrary.DataSetHelper.CreateWorkbook(m, ds);
                m.WriteTo(Response.OutputStream);
                ds.Dispose();
                m.Dispose();
                //Response.End();
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }
        // After file import bind grid
        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string upload_file_name = this.UploadFile();
                if (upload_file_name.Length > 0)
                {
                    // Change file name before upload : replaced to _
                    string fileExtension = Path.GetExtension(upload_file_name);
                    string connectionString = "";
                    if (fileExtension == ".xls")
                    {
                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + upload_file_name + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    else if (fileExtension == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + upload_file_name + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    OleDbConnection con = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
                    DataTable dtExcelRecords = new DataTable();
                    con.Open();
                    DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
                    cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
                    dAdapter.SelectCommand = cmd;
                    dAdapter.Fill(dtExcelRecords);
                    con.Close();
                    if (dtExcelRecords != null)
                    {
                        DataTable table = dtExcelRecords;
                        if (table != null)
                        {
                            int total_row = table.Rows.Count;
                            if (total_row > 0)
                            {
                                objProductImageManagerController.DeleteAllImage(_productID);

                                for (int i = 0; i < total_row; i++)
                                {
                                    objProductImageManagerController.SaveUpdate(new ProductImageManagerModel()
                                    {
                                        GUID = table.Rows[i][0].ToString(),
                                        ImageAlt = table.Rows[i][2].ToString(),
                                        Angle = table.Rows[i][3].ToString(),
                                        ImagePath = table.Rows[i][4].ToString(),
                                        ProductId = _productID,
                                        Status = true
                                    });
                                }
                            }
                        }
                    }
                    Response.Redirect("/Product/ProductImage.aspx?id=" + _productID + "&angles=" + Convert.ToString(Request.QueryString["angles"]) + "&status=success");
                }
                else
                {
                    lblMessage.Text = "File upload failed";
                }
            }
            catch(Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        string UploadFile()
        {
            try
            {
                if (fleImport.HasFile)
                {
                    string file_name = Path.GetFileNameWithoutExtension(fleImport.PostedFile.FileName).Trim();
                    string file_ext = Path.GetExtension(fleImport.PostedFile.FileName).Trim();
                    string productSKU = PRODUCT_SKU.Replace('-', ':');
                    if (productSKU == file_name)
                    {
                        //for extension
                        string upload_file_name = Server.MapPath("~/upload/files/" + file_name + file_ext);
                        fleImport.PostedFile.SaveAs(upload_file_name);
                        return upload_file_name;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
            return "";
        }

        private ProductImageManagerModel GetProductImageManagerModel(long product_id,string GUID)
        {
            return lstProductImageManager.Where(tbl => tbl.ProductId == product_id && tbl.GUID == GUID).FirstOrDefault();
        }

        protected void gridViewImages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (lstProductImageManager != null)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        //access the controls
                        TextBox txtPath = (TextBox)e.Row.FindControl("txtPath");
                        Image imgView = (Image)e.Row.FindControl("imgView");
                        if (txtPath != null)
                        {
                            DataRowView rowView = (DataRowView)e.Row.DataItem;
                            ProductImageManagerModel model = this.GetProductImageManagerModel(_productID, rowView.Row.ItemArray[0].ToString());
                            if (model != null)
                            {
                                if (model.ImagePath.Length > 0)
                                {
                                    txtPath.Text = model.ImagePath;
                                    imgView.ImageUrl = "/assets/themes/admin/images/loader/ajax_loader_48.gif";
                                    imgView.Attributes.Add("data-original", model.ImagePath);
                                    imgView.CssClass = "lazy";
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLogModel objLogError = new ErrorLogModel();
                objLogError.ErrorMessage = ex.Message;
                objLogError.ErrorSource = ex.Source;
                objLogError.StackTrace = ex.StackTrace;
                objLogError.InnerException = Convert.ToString(ex.InnerException);
                objLogError.LogTime = DateTime.Now;
                objLogError.UserID = Session["loginID"].ToString();
                new ErrorLogController().SetErrorLog(objLogError);
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Product/ProductImage.aspx?id=" + _productID + "&angles=" + ddlAngle.SelectedValue);
        }
    }
}