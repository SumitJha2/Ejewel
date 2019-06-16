<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="EJewel.AdminView.Master.Category.AddCategory1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sub Category</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script> 
</head>
<body>
 <form id="form1" runat="server">
  <table class="table table-bordered table-striped" style="width:100%">
        <thead>
         <tr><th colspan="5">
             Sub Category</th></tr>
         </thead>         
         <tbody>
         <tr><td colspan="5">&nbsp;<span id="spnMessage"></span></td></tr>
		<tr>
			<td >Parent Category<span  class="small_error">&nbsp;*</span></td>
			<td>
                <asp:DropDownList ID="ddlParentCategory" runat="server" CssClass="common_width"></asp:DropDownList>  
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />               
            </td>         
			<td>&nbsp;</td>
			<td>Sub Category Name<span class="small_error">&nbsp;*</span></td>         
			<td>
            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="common_width" ></asp:TextBox>
              </td>            
		</tr>   
        <tr>
		<td >Page Title<span  class="small_error">&nbsp;*</span></td>
		<td><asp:TextBox ID="txtPageTitle" runat="server" CssClass="common_width"></asp:TextBox>
        </td>
		<td>
            &nbsp;</td>
		<td>
           Meta Keywords<span  class="small_error">&nbsp;*</span></td>
		<td>
                <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="common_width" ></asp:TextBox> &nbsp;              
                <input type="hidden" id="hdnFile" value="" />           
                </td>
        </tr>
        <tr>
		<td >Meta Description<span class="small_error">&nbsp;*</span></td>
		<td>
          <asp:TextBox ID="txtMetaDescription" runat="server" TextMode="MultiLine" Height="100px" CssClass="common_width"></asp:TextBox>      
            </td>
		<td>
            &nbsp;</td>
		<td>
                Status</td>
		<td>
        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">
        </asp:DropDownList>		 
            </td>
        </tr>      
          <tr>
			<td  colspan="5"> 
                <input id="btnSave" type="button" value="Save" class="btn btn-small" onclick="btnSave_onclick()" />
                		
		      </td>
		</tr>
        </tbody>
          </table>
    </form>
    <script type="text/javascript">
        function validate() {
            $("#spnMessage").css("color", "red");
            if (document.getElementById("<%=ddlParentCategory.ClientID %>").selectedIndex == 0) {
                $("#spnMessage").html('Please select parent category.');
                return false;
            }
           else if (document.getElementById("<%=txtCategoryName.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter category name.');
                return false;
            }         

            else if (document.getElementById("<%=txtPageTitle.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter page title.');
                return false;
            }
            else if (document.getElementById("<%=txtMetaKeywords.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter meta keyword.');
                return false;
            }
            else if (document.getElementById("<%=txtMetaDescription.ClientID %>").value.trim() == "") {
                $("#spnMessage").html('Please enter meta description.');
                return false;
            }
                  
            else {
                return true;
            }
        }
        function btnSave_onclick() {
            if (confirm("Do you Save...?")) {
                try {                  
                    if (validate()) {
                        var id = parseInt($("#<%=hdnID.ClientID %>").val());
                        var txtCategoryName = $("#<%=txtCategoryName.ClientID %>").val();
                        //Appearance
                        var ddlParentCategory = parseInt($("#<%=ddlParentCategory.ClientID %>").val());                     
                        var status = parseInt($("#<%=ddlStatus.ClientID %>").val()) == 1 ? true : false;                    
                        //seo 
                        var txtPageTitle = $("#<%=txtPageTitle.ClientID %>").val();
                        var txtMetaKeywords = $("#<%=txtMetaKeywords.ClientID %>").val();
                        var txtMetaDescription = $("#<%=txtMetaDescription.ClientID %>").val();
                        var model = {SubCategoryId: id, SubCategoryName: txtCategoryName,PageTitle: txtPageTitle, MetaDescription: txtMetaDescription, MetaKeywords: txtMetaKeywords, CreateBy: 1, ModifiedBy: 1, Status: status,CategoryId: ddlParentCategory };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateSubCategory",
                            data: "{model:" + JSON.stringify(model) + "}",
                            dataType: "json",
                            success: function (successData) {
                                $("#spnMessage").html(successData.d);
                                $("#spnMessage").css("color", "green");
                                if (id == 0) {
                                    document.getElementById("form1").reset();
                                }
                            },
                            error: function (result) {
                                var error = JSON.parse(result.responseText);
                                $("#spnMessage").css("color", "red");
                                $("#spnMessage").html(error.Message);
                            }
                        });

                    }
                }
                catch (e) {
                    alert(e);
                }
            }
        }
      </script>
</body>
</html>
