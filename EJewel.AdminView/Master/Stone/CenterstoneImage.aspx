<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CenterstoneImage.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.CenterstoneImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Center Stone Image</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
        .color
        {
        	color:Red;
        }
        .message
        {
        	color:green;
        }
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
             Upload Center Stone Image</th></tr>
         </thead>         
         <tbody>
         <tr><td colspan="5">&nbsp;<span id="spnMessage" class="message"  runat="server"></span></td></tr>
		<tr>
			<td >Image url<span  class="small_error">&nbsp;*</span></td>
			<td>
               <asp:TextBox ID="txtImage" runat="server" CssClass="common_width"></asp:TextBox> 
               <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic" ControlToValidate="txtImage" CssClass="color" ErrorMessage="Please enter Image url."></asp:RequiredFieldValidator>          
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  CssClass="color" Display="Dynamic" ControlToValidate="txtImage" runat="server" 
                   ErrorMessage="Enter url in correct format." ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>  
                
               <asp:HiddenField ID="hdnCenterstoneImageId" runat="server" />                  
            </td>
            </tr>
            <tr><td colspan="5">
           
             <asp:GridView ID="gvCenterStoneImage" runat="server" 
                    CssClass="table table-bordered table-striped"  AutoGenerateColumns="False"  
                    PageSize="20" AllowPaging="true" onrowdatabound="gv_rowdataBound">
       <Columns>
     <asp:TemplateField HeaderText="Sl.">
     <ItemTemplate>
      <%# Container.DataItemIndex+1 %>  
     <asp:HiddenField ID="hdnImageId" runat="server" Value='<% #Eval("CenterstoneImageID") %>' />  
      <asp:HiddenField ID="hdnCenterstoneId" runat="server" Value='<% #Eval("CenterstoneID") %>' />  
      </ItemTemplate>
     </asp:TemplateField>
      <asp:BoundField DataField="ImagePath" HeaderText="ImagePath" />

     <asp:TemplateField HeaderText="Image">
     <ItemTemplate>
      <asp:HiddenField ID="hdnCSImageID" runat="server" Value='<% #Eval("ImagePath") %>' />  
       <asp:Label ID="lblImage" runat="server"></asp:Label>
      </ItemTemplate>
     </asp:TemplateField>
    
    
      <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
         <asp:ImageButton ID="imgEdit" runat="server" OnClick="imgEdit_Click" CausesValidation="false"  CssClass="border" ImageUrl="/assets/themes/admin/images/icon/edit_16.png"  width="15px" height="15px" />        
        </ItemTemplate>        
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
        <ItemTemplate>
         <asp:ImageButton ID="imgDelete" runat="server" OnClick="imgDelete_Click"  CausesValidation="false" CssClass="border" ImageUrl="/assets/themes/admin/images/icon/delete_16.png"  width="15px" height="15px" />        
        </ItemTemplate>        
        </asp:TemplateField>


    
       </Columns>
       </asp:GridView>            
            </td></tr>




           
          <tr>
			<td  colspan="5"> 
            <asp:Button ID="btnSave" runat="server"  Text="Save" class="btn btn-small" onclick="btnSave_Click" />        
                		
		      </td>
		</tr>
        </tbody>
          </table>
    </form>
</body>
</html>
