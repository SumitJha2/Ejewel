using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//model
using EJewel.Model.Admin.Master.Stone;
using EJewel.Model.Admin.Product;
using EJewel.Model.Admin.Common;
using EJewel.Model.Admin.Master.Setting;
//controller
using EJewel.Controller.Admin.Master.Stone;
using EJewel.Controller.Admin.Product;
using EJewel.Controller.Admin.Master.Setting;
using EJewel.Controller.Common;

namespace EJewel.AdminView.Product
{
    public partial class ProductSideStone : System.Web.UI.Page
    {
        long _productID = 0;
        public int _activeTab=0, _stoneCategoryId = 1;//default as diamond
        string _view, _shapes;
        public string _lnkDiamond, _lnkGemStone;
        ProductSideStoneController objController = new ProductSideStoneController();
        ProductDetailsController objProductDetailsController = new ProductDetailsController();
        SideStoneActionModel.PageName _pageView = SideStoneActionModel.PageName.SideStone;

        List<StoneSpecificationModel> _lstStoneType = new List<StoneSpecificationModel>();

        List<StoneCategorySettingTypeModel> _lstStoneCategorySettingType = null;

        List<ProductSideStoneModel> _lstProductSideStoneModel = null;

        List<ProductSideStoneDesignTypeModel> _lstProductSideStoneDesignType = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginID"] == null)
            {
                Session.Abandon();
                Response.Redirect("/Default.aspx");
            }
            else
            {
                try
                {
                    string qs_productID = Request.QueryString["id"];
                    string qs_stoneCategoryID = Request.QueryString["stone_category"];
                    //
                    _view = Request.QueryString["view"];
                    _shapes = Request.QueryString["shapes"];
                    //set the navigation
                    if (!string.IsNullOrEmpty(qs_productID) && !string.IsNullOrEmpty(_view))
                    {
                        //now do the cast operation
                        _productID = Convert.ToInt64(qs_productID);
                        _pageView = objController.GetPageView(_view);
                        _stoneCategoryId = qs_stoneCategoryID.Length > 0 ? Convert.ToInt32(qs_stoneCategoryID) : 1;
                        lblStoneCategory.Text = _stoneCategoryId == 1 ? "Diamond" : "Gem Stone";
                        switch (_stoneCategoryId)
                        {
                            case 1:
                                {
                                    _activeTab = 0;
                                } break;
                            case 2:
                                {
                                    _activeTab = 1;
                                } break;
                        }
                        //default as diamonds
                        //
                        ltrlHeading.Text = objController.Heading;
                        //set navilation
                        _lnkDiamond = "/Product/ProductSideStone.aspx?id=" + _productID + "&stone_category=1&view=" + _view;
                        _lnkGemStone = "/Product/ProductSideStone.aspx?id=" + _productID + "&stone_category=2&view=" + _view;
                        //get stone type list
                        ProductDetailsModel product = objProductDetailsController.GetProductDetails(_productID);
                        if (product != null)
                        {
                            //load product detils
                            this.FillDesignType();
                            //
                            if (!IsPostBack)
                            {
                                #region Display
                                //set the value
                                lblSKU.Text = product.SKU + "/" + product.PageTitle;
                                //set product side stone design type
                                //set the design type
                                //load the shape
                                this.LoadStoneShape(_stoneCategoryId);
                                #endregion

                                #region Show Edit Data
                                #region access the stone range
                                ProductSideStoneRangeModel sideStoneRangeModel = objController.ProductSideStoneRange(_productID, _stoneCategoryId, _pageView);
                                if (sideStoneRangeModel != null)
                                {
                                    //set the value of the page
                                    txtMaxCarat.Text = sideStoneRangeModel.StoneMaxCarat.ToString();
                                    txtMinCarat.Text = sideStoneRangeModel.StoneMinCarat.ToString();

                                    #region  Get Shape
                                    int[] arr_shape = objController.StoneShapeList(sideStoneRangeModel.ProductSideStoneRangeId, _pageView, CommonModel.RecordStatus.Enabled).ToArray();
                                    int total_shape = arr_shape.Length;
                                    if (total_shape > 0)
                                    {
                                        for (int i = 0; i < total_shape; i++)
                                        {
                                            ListItem lstStoneShape = chkLstStoneShape.Items.FindByValue(arr_shape[i].ToString());
                                            if (lstStoneShape != null)
                                            {
                                                lstStoneShape.Selected = true;
                                            }
                                        }
                                    }
                                    #endregion

                                    #region Side Stone
                                    //load other related data
                                    _lstProductSideStoneModel = objController.ProductSideStoneList(_productID, _stoneCategoryId, _pageView, CommonModel.RecordStatus.Enabled);
                                    _lstStoneCategorySettingType = this.GetStoneCategorySettingTypeList();
                                    //load side stone grid
                                    this.LoadSideStone(_productID, _stoneCategoryId, sideStoneRangeModel.StoneMinCarat, sideStoneRangeModel.StoneMaxCarat, arr_shape);
                                    #endregion
                                }
                                #endregion
                                #endregion
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Response.Redirect("Pagenotfound.aspx");
                    }
                    //for status
                    string q_status = Request.QueryString["status"];
                    if (!string.IsNullOrEmpty(q_status))
                    {
                        if (q_status == "success")
                        {
                            lblMessage.Text = "Product Stone Details Save Successfully.";
                            lblMessage.CssClass = "small_success";
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
        }

        private List<StoneCategorySettingTypeModel> GetStoneCategorySettingTypeList()
        {
            return new StoneCategorySettingTypeController().StoneSettingTypeListFromStoneCategoryType(2, CommonModel.RecordStatus.Enabled);
        }

        private void LoadStoneShape(int stoneCategoryId)
        {
            chkLstStoneShape.DataSource = new StoneShapeController().StoneShapeListFromCategory(stoneCategoryId,StoneShapeModel.ShapeVisibility.SIDESTONE, CommonModel.RecordStatus.Enabled);
            chkLstStoneShape.DataTextField = "Shape";
            chkLstStoneShape.DataValueField = "StoneShapeId";
            chkLstStoneShape.DataBind();
        }

        private void LoadSideStone(long productID, int stoneCategoryID, double minCt, double maxCt, int[] shapes)
        {
            try
            {
                SideStoneController cont = new SideStoneController();
                //
                List<SideStoneModel> lstModel = cont.GetSideStoneListFromCategory_New(stoneCategoryID, minCt, maxCt, shapes, CommonModel.RecordStatus.Enabled);
                if (_lstProductSideStoneModel != null)
                {
                    lstModel = (from sideStone in lstModel
                                join productSideStone in _lstProductSideStoneModel
                                on sideStone.SideStoneId equals productSideStone.StoneId
                                select sideStone).ToList();
                }
                //
                dgvSideStone.DataSource = lstModel;
                //2 default as side stone
                dgvSideStone.DataBind();
                //set heaer as thead
                dgvSideStone.HeaderRow.TableSection = TableRowSection.TableHeader;

                switch (stoneCategoryID)
                {
                    case 1:
                        {
                            //for diamonds
                            //hide last 2 columns (customize & type)
                            dgvSideStone.Columns[10].Visible = false;
                            dgvSideStone.Columns[11].Visible = false;
                        } break;
                    case 2:
                        {
                            //for gemstone
                            // hide 4 5 6
                            dgvSideStone.Columns[4].Visible = false;
                            dgvSideStone.Columns[5].Visible = false;
                            dgvSideStone.Columns[6].Visible = false;
                        } break;
                }
                if (dgvSideStone.Rows.Count > 0)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
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

        public List<StoneSpecificationModel> FillStoneType(int categoryID)
        {
            return new StoneSpecificationController().GetStoneSpecificationListFromCategory(categoryID, StoneSpecificationModel.PageName.Type, CommonModel.RecordStatus.Both);
        }

        private void LoadSideStone(int stoneCategoryId)
        {
            try
            {
                //show the side stone details
                double min_carat = Convert.ToDouble(txtMinCarat.Text);
                double max_carat = Convert.ToDouble(txtMaxCarat.Text);
                int[] lstShape = this.GetShapeList();
                if (lstShape.Length > 0)
                {
                    _lstStoneCategorySettingType = this.GetStoneCategorySettingTypeList();
                    //load stone category
                    this.LoadSideStone(_productID, stoneCategoryId, min_carat, max_carat, lstShape);
                }
                else
                {
                    //error
                    //no shape selected
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

        private int[] GetShapeList()
        {
            int total_shape = chkLstStoneShape.Items.Count;
            List<int> listShape = new List<int>();
            for (int i = 0; i < total_shape; i++)
            {
                ListItem lstShape = chkLstStoneShape.Items[i];
                if (lstShape != null && lstShape.Selected)
                {
                    listShape.Add(Convert.ToInt32(lstShape.Value));
                }
            }
            return listShape.ToArray();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //save the details of the side stone
                int total_row = dgvSideStone.Rows.Count;
                //define varibales
                HiddenField hdnStoneID = null;
                CheckBox chkAvialable = null;
                TextBox txtNoOfStone = null;
                DropDownList ddlSettingType = null;
                DropDownList ddlDesignType = null;
                RadioButton rdoCustomize = null;
                GridView dgvStoneType = null;
                //
                HiddenField hdnStoneTypeStoneId = null;
                CheckBox chkStoneTypeAvailable = null;
                //
                GridViewRow row = null, rowStoneType = null; ;
                for (int i = 0; i < total_row; i++)
                {
                    //acces the grid row
                    row = dgvSideStone.Rows[i];
                    if (row != null)
                    {
                        //acces the controls
                        hdnStoneID = (HiddenField)row.FindControl("hdnStoneID");
                        chkAvialable = (CheckBox)row.FindControl("chkAvialable");
                        txtNoOfStone = (TextBox)row.FindControl("txtNoOfStone");
                        ddlDesignType = (DropDownList)row.FindControl("ddlDesignType");
                        ddlSettingType = (DropDownList)row.FindControl("ddlSettingType");
                        rdoCustomize = (RadioButton)row.FindControl("rdoCustomize");
                        dgvStoneType = (GridView)row.FindControl("dgvStoneType");
                        //now for some validation
                        if (hdnStoneID != null)
                        {
                            #region Side Stone
                            long stoneID = Convert.ToInt64(hdnStoneID.Value);
                            bool status = chkAvialable.Checked ? true : false;
                            int no_side_stone = txtNoOfStone.Text.Trim().Length > 0 ? Convert.ToInt32(txtNoOfStone.Text) : 0;
                            int stone_category_setting_type_id = ddlSettingType.SelectedIndex > 0 ? Convert.ToInt32(ddlSettingType.SelectedValue) : 0;
                            //create model
                            //save the details of the side stone details
                            ProductSideStoneModel psModel = new ProductSideStoneModel()
                            {
                                ProductId = _productID,
                                Status = status,
                                StoneCategoryId = _stoneCategoryId,
                                StoneId = stoneID,
                                NoOfStone = no_side_stone,
                                StoneCategorySettingTypeId = stone_category_setting_type_id,
                                IsCustomize = rdoCustomize.Checked ? true : false,
                                DesignTypeId = Convert.ToInt32(ddlDesignType.SelectedValue)
                            };
                            psModel = objController.SaveUpdateProductSideStone(psModel, _pageView);
                            #endregion

                            if (_stoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE && psModel.ProductSideStoneId>0 && chkAvialable.Checked)
                            {
                                #region Side Stone Avialbale Type
                                //save details of the type
                                int total_type = dgvStoneType.Rows.Count;
                                if (total_type > 0)
                                {
                                    for (int j = 0; j < total_type; j++)
                                    {
                                        rowStoneType = dgvStoneType.Rows[j];
                                        if (rowStoneType != null)
                                        {
                                            //access the controls
                                            hdnStoneTypeStoneId = (HiddenField)rowStoneType.FindControl("hdnStoneTypeStoneId");
                                            chkStoneTypeAvailable = (CheckBox)rowStoneType.FindControl("chkStoneTypeAvailable");
                                            if (hdnStoneTypeStoneId != null)
                                            {
                                                try
                                                {
                                                    ProductSideStoneAvialableStoneTypeModel stoneSideStoneType = new ProductSideStoneAvialableStoneTypeModel()
                                                    {
                                                        ProductSideStoneAvialableId = 0,
                                                        ProductSideStoneId = psModel.ProductSideStoneId,
                                                        Status = chkStoneTypeAvailable.Checked ? true : false,
                                                        StoneId = Convert.ToInt64(hdnStoneTypeStoneId.Value)
                                                    };
                                                    objController.SaveUpdateProductSideStoneAvialableStoneType(stoneSideStoneType, _pageView);
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
                                        }
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }

                #region Range Model
                //save the detasils of the side stone 
                ProductSideStoneRangeModel pssrModel = new ProductSideStoneRangeModel()
                {
                    ProductId = _productID,
                    StoneCategoryId = _stoneCategoryId,
                    StoneMaxCarat = Convert.ToDouble(txtMaxCarat.Text),
                    StoneMinCarat = Convert.ToDouble(txtMinCarat.Text),
                };
                //save the details of range
                pssrModel = objController.SaveUpdateProductSideStoneRange(pssrModel, _pageView);
                #endregion

                #region Shape Model
                if (pssrModel.ProductSideStoneRangeId > 0)
                {
                    int total_shape = chkLstStoneShape.Items.Count;
                    for (int i = 0; i < total_shape; i++)
                    {
                        ProductSideStoneShapeModel shapeModel = new ProductSideStoneShapeModel()
                        {
                            ProductSideStoneRangeId = pssrModel.ProductSideStoneRangeId,
                            ProductSideStoneShapeId = 0,
                            Status = chkLstStoneShape.Items[i].Selected ? true : false,
                            StoneShapeId = Convert.ToInt32(chkLstStoneShape.Items[i].Value)
                        };
                        //now save the shape
                        objController.SaveUpdateProductSideStoneShape(shapeModel, _pageView);
                    }
                }
                #endregion

                //redirect to same page
                Response.Redirect("/Product/ProductSideStone.aspx?id=" + _productID + "&stone_category=" + _stoneCategoryId + "&view=" + _view + "&status=success");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadSideStone(_stoneCategoryId);
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

        protected void dgvSideStone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    //access the controls
                    HiddenField hdnStoneID = (HiddenField)e.Row.FindControl("hdnStoneID");
                    CheckBox chkAvialable = (CheckBox)e.Row.FindControl("chkAvialable");
                    TextBox txtNoOfStone = (TextBox)e.Row.FindControl("txtNoOfStone");
                    DropDownList ddlDesignType = (DropDownList)e.Row.FindControl("ddlDesignType");
                    DropDownList ddlSettingType = (DropDownList)e.Row.FindControl("ddlSettingType");
                    RadioButton rdoCustomize = (RadioButton)e.Row.FindControl("rdoCustomize");
                    //added by sumit on 13-04-2013
                    HiddenField hdnShapeId = (HiddenField)e.Row.FindControl("hdnShapeId");
                    HiddenField hdnCarat = (HiddenField)e.Row.FindControl("hdnCarat");
                    //added partha (06-05-13_
                    GridView dgvStoneType = (GridView)e.Row.FindControl("dgvStoneType");
                    if (hdnStoneID != null)
                    {
                        //apend no char event Partha @ 31-05-13
                        txtNoOfStone.Attributes.Add("onkeydown", "return allow_only_number(event)");
                        //for customize check change
                        rdoCustomize.Attributes.Add("onclick", "checkRadioChangeInGrid('" + dgvSideStone.ClientID + "','" + rdoCustomize.ClientID + "')");
                        //set the setting type list
                        if (_lstStoneCategorySettingType != null)
                        {
                            ListHelper.BindList(ddlSettingType, _lstStoneCategorySettingType, "StoneCategorySettingTypeId", "SettingTypeName", ListHelper.DefaultList);
                        }
                        // to bind StoneType List
                        if (_stoneCategoryId == ConstantHelper.STONE_CATEGORY_GEMSTONE)
                        {
                            //this will display in only in case of side stone (partha)
                            List<SideStoneModel> lstSideStoneTypeModel = new SideStoneController().GetSideStoneTypeForProductCreation(ConstantHelper.STONE_CATEGORY_GEMSTONE, Convert.ToInt32(hdnShapeId.Value), Convert.ToDouble(hdnCarat.Value));
                            if (lstSideStoneTypeModel != null && dgvSideStone != null)
                            {
                                //bind data grid
                                dgvStoneType.DataSource = lstSideStoneTypeModel;
                                dgvStoneType.DataBind();
                                dgvStoneType.HeaderRow.TableSection = TableRowSection.TableHeader;
                            }
                        }

                        //
                        if (_lstProductSideStoneModel != null)
                        {
                            int total_side_stone = _lstProductSideStoneModel.Count;
                            if (total_side_stone > 0)
                            {
                                long stone_id = Convert.ToInt64(hdnStoneID.Value);
                                HiddenField hdnStoneTypeStoneId = null;
                                CheckBox chkStoneTypeAvailable = null;
                                for (int i = 0; i < total_side_stone; i++)
                                {
                                    ProductSideStoneModel sideStone = _lstProductSideStoneModel[i];
                                    if (sideStone != null && sideStone.StoneId == stone_id && sideStone.Status)
                                    {
                                        //chnage the row color
                                        e.Row.CssClass = "selected_row";
                                        //
                                        rdoCustomize.Checked = sideStone.IsCustomize ? true : false;
                                        //set the control values
                                        chkAvialable.Checked = true;
                                        txtNoOfStone.Text = sideStone.NoOfStone.ToString();
                                        //select design type
                                        ddlDesignType.SelectedValue = sideStone.DesignTypeId.ToString();
                                        //set the stone category settinf type
                                        ddlSettingType.SelectedValue = sideStone.StoneCategorySettingTypeId.ToString();
                                        //set the stone type
                                        List<long> lstStoneTypeSideStoneId = objController.StoneTypeSideStoneIdList(sideStone.ProductSideStoneId, _pageView);
                                        if (lstStoneTypeSideStoneId != null)
                                        {
                                            int total_stone_type_id = lstStoneTypeSideStoneId.Count;
                                            for (int k = 0; k < total_stone_type_id; k++)
                                            {
                                                foreach (GridViewRow rowSideStoneType in dgvStoneType.Rows)
                                                {
                                                    hdnStoneTypeStoneId = (HiddenField)rowSideStoneType.FindControl("hdnStoneTypeStoneId");
                                                    chkStoneTypeAvailable = (CheckBox)rowSideStoneType.FindControl("chkStoneTypeAvailable");
                                                    if (hdnStoneTypeStoneId != null)
                                                    {
                                                        if (Convert.ToInt64(hdnStoneTypeStoneId.Value) == lstStoneTypeSideStoneId[k])
                                                        {
                                                            chkStoneTypeAvailable.Checked = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
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
        }

        void FillDesignType()
        {
            _lstProductSideStoneDesignType = objController.GetProductSideStoneDesignType();
            //more flexible for user partha @ 31-05-13
            if(_lstProductSideStoneDesignType!=null)
            {
                if(_stoneCategoryId==ConstantHelper.STONE_CATEGORY_DIAMOND)
                {
                    //just order
                    _lstProductSideStoneDesignType = _lstProductSideStoneDesignType.OrderByDescending(tbl => tbl.DesignType).ToList();
                }
            }
        }

        public List<ProductSideStoneDesignTypeModel> DesignTypeSource()
        {
            if (_lstProductSideStoneDesignType != null)
                return _lstProductSideStoneDesignType;
            else
                return new List<ProductSideStoneDesignTypeModel>();
        }
    }
}