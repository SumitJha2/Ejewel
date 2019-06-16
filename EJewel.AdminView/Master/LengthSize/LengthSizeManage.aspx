<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LengthSizeManage.aspx.cs" Inherits="EJewel.AdminView.Master.LengthSize.LengthSizeManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Ring Size Master</h1>      
                        </div>
                        <div class="block-fluid">
		<!--  end step-holder -->
		<!-- start id-form -->
		<table border="0" cellpadding="0" cellspacing="0" class="table">
		 <tr>
		<td valign="top">Category</td>
		<td>	
		    <asp:DropDownList ID="ddlCategory" runat="server">
            </asp:DropDownList>
&nbsp;</td>
        </tr>
         <tr>
		<td valign="top">Metal</td>
		<td>	
		 &nbsp;<asp:DropDownList ID="ddlMetal" runat="server">
            </asp:DropDownList>
		</td>
        </tr>  
       <tr>
			<td valign="top"> Length/Size</td>
			<td>
                <asp:TextBox ID="txtLengthSize" runat="server"></asp:TextBox>&nbsp;
                </td>
		</tr>	
          <tr>
			<td valign="top">Weight Of Metal Used</td>
			<td>
                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
              </td>
		</tr>
          <tr>
			<td valign="top">Price</td>
			<td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
              </td>
		</tr>
        <tr>
		<td valign="top">Status</td>
		<td>	
		 
		    <asp:DropDownList ID="ddlStatus" runat="server">
            </asp:DropDownList>
		 
		</td>
        </tr>
	<tr>
		<th colspan="2">
			<input id="btnSave" type="button" value="Save" onclick="return btnSave_onclick()" /></th>
	</tr>
	</table>
    </div>
    </div>
       <script language="javascript" type="text/javascript">
    <!--

           function btnSave_onclick() {
               //access the control
               try {
                   var category = $("#<%= ddlCategory.ClientID %>").val();
                   var metal = $("#<%= ddlMetal.ClientID %>").val();
                   var length_size = $("#<%= txtLengthSize.ClientID %>").val();
                   var metal_weight = $("#<%= txtWeight.ClientID %>").val();
                   var price = $("#<%= txtPrice.ClientID %>").val();
                   var status = $("#<%= ddlStatus.ClientID %>").val();
                   //apply the validation rules
                   //create model

               }
               catch (e) {
                   alert(e);
               }
           }

           /*
           Partha Ranjan
           @ 02-02-13
           This function used to save the details of the type and size
           */
           function LengthSizeModel(lengthSizeId,categoryId,metalId,lengthSize,metalWeight,price,status) {
               this.LengthSizeId =lengthSizeId;
               this.CategoryId =categoryId;
               this.MetalId =metalId;
               this.LengthSize =lengthSize;
               this.MetalWeight =metalWeight;
               this.Price =price;
               this.Status = status;
           }

    // -->
    </script>
</asp:Content>
