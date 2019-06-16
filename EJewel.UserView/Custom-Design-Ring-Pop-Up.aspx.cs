using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EJewel.Model.Admin.Extras;
using EJewel.Controller.Admin.Extras;
using EJewel.Model.Admin.Common.Sfm;
using EJewel.Controller.Admin.Common.Sfm;
using System.IO;

namespace EJewel.UserView
{
    public partial class Custom_Design_Ring_Pop_Up : System.Web.UI.Page
    {
        CustomDesignRingController objController = new CustomDesignRingController();
        CustomDesignRingModel objModel = new CustomDesignRingModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMetalName();
                BindRingSize();
                //1048576
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // check for file upload
            // for image -------------------

            string imagename = null;
            string fileExtn = null;
            imagename = fdFileUpload.FileName.ToString();
            fileExtn = Path.GetExtension(imagename).ToLower();
            if (fileExtn != "")
            {
                if (CheckImagePath(fileExtn))
                {
                    objModel.FileExtension = fileExtn;
                }
                else
                {
                    lblMessage.Text = "File extention is invalid";
                    return;
                }
                if (!CheckFileSize())
                {
                    lblMessage.Text = "Please upload file less than 1 MB.";
                    return;
                }

            }
            
            objModel.DiamondItem = txtDiamondInformation.Text;
            objModel.SideStones = txtSideStone.Text;
            objModel.RingSizeId = Convert.ToInt32(ddlRingSize.SelectedValue);
            objModel.MetalTypeId = Convert.ToInt32(ddlMetalType.SelectedValue);
            if (txtBudget.Text != "")
            {
                objModel.Budget = (float)Convert.ToDouble(txtBudget.Text.Trim());
            }
            else
            {
                objModel.Budget = 0;
            }
            objModel.LinkstoDesign = txtLike.Text;
            objModel.Comments = txtComments.Text;
            objModel.FullName = txtFullName.Text;
            objModel.Email = txtEmail.Text;
            objModel.Phone = txtPhone.Text;
            objModel.BestTimeToCall = ddlBestTimeToCall.SelectedItem.Text;
            objModel=objController.SaveUpdateCustomDesign(objModel);

         
          
            fdFileUpload.SaveAs(Server.MapPath("/upload/customdesign/" + objModel.CustomDesignRequestID + fileExtn));
            new CustomDesignRingController().SaveUpdateCustomDesign(objModel);
        }
        public void BindMetalName()
        {
            List<SfmModel> model=new SfmController().GetSfmList(0,CommonModel.RecordStatus.Enabled,SfmModel.PageName.MetalNameMaster).ToList();
            if (model != null && model.Count > 0)
            {
                ddlMetalType.DataSource = model;
                ddlMetalType.DataTextField = "Name";
                ddlMetalType.DataValueField = "AutoID";
                ddlMetalType.DataBind();
            }
            ddlMetalType.Items.Insert(0, new ListItem("Please Select", "0"));

        }
        public void BindRingSize()
        {
            List<SfmModel> model = new SfmController().GetSfmList(0, CommonModel.RecordStatus.Enabled, SfmModel.PageName.RingSize).ToList();
            if (model != null && model.Count > 0)
            {
                ddlRingSize.DataSource = model;
                ddlRingSize.DataTextField = "Name";
                ddlRingSize.DataValueField = "AutoID";
                ddlRingSize.DataBind();
            }
            ddlRingSize.Items.Insert(0, new ListItem("Please Select", "0"));

             
        }

        private bool CheckImagePath(string path)
        {

            string ext = Path.GetExtension(path);
            switch (ext.ToLower())
            {
                case ".jpg": return true;
                case ".png": return true;
                case ".jpeg": return true;
                case ".gif": return true;
                case ".JPG": return true;
                case ".GIF": return true;
                default: return false;

            }

        }
        private bool CheckFileSize()
        {
            bool flag = false;
            if (fdFileUpload.FileBytes.Length >1048576)
            {

            }
            else
            {
                flag = true;
            }
            return flag;
        }
       // 1048576


    }
}