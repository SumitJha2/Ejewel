<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" Inherits="EJewel.AdminView.Extras.ManageNews" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" Inherits="EJewel.AdminView.Extras.ManageNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


 <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  
  <script>
      $(function () {
          $("#<%=txtNewsDate.ClientID %>").datepicker();
      });
  </script>

<style type="text/css">
       
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
        
        .validation_cls
        {
            color:red;
        }
    </style>
   




 <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
 <div id="contentHeader">
    <h1>Manage News</h1>
</div>
 <div class="container">
 <div class="grid-24">
 
<table class="table table-bordered table-striped" style="width:100%">
<tr><td colspan="2"><asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label></td></tr>
<tr><td>Category<span class="small_error">&nbsp;*</span></td><td>
    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
    <asp:DropDownList ID="ddlNewsCategory" runat="server" CssClass="common_width" 
        Height="26px" Width="222px">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
        ErrorMessage="Please select news category." ControlToValidate="ddlNewsCategory" CssClass="validation_cls" InitialValue=""></asp:RequiredFieldValidator>
    </td></tr>
<tr><td>Heading<span class="small_error">&nbsp;*</span></td><td>
  <asp:TextBox ID="txtHeading" runat="server" CssClass="common_width" Width="215px"></asp:TextBox>
   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Please enter news heading." ControlToValidate="txtHeading" CssClass="validation_cls">
        </asp:RequiredFieldValidator>
    </td></tr>
<tr><td>Description<span class="small_error">&nbsp;*</span></td><td>
 <cc2:Editor ID="txtdescription" runat="server" AutoFocus="true" Height="100px" />   
    </td></tr>
   
<tr><td>Status</td><td>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width" 
        Height="26px" Width="228px">
    </asp:DropDownList>
    </td></tr>
<tr><td>
Image&nbsp;<span class="hints">Size </span></td><td>
    <asp:FileUpload ID="fuImage" runat="server" />
               <span id="spnProgress" runat="server"></span>
                <input type="hidden" id="hdnFile" value="" />
                    </td></tr>

                   <tr><td>Date<span class="small_error">&nbsp;*</span></td><td>
    <asp:TextBox ID="txtNewsDate" runat="server" CssClass="common_width" Width="222px"></asp:TextBox>
                       
                       <%--<cc1:CalendarExtender ID="txtNewsDate_CalendarExtender" runat="server" Format="dd-MM-yyyy" 
                           Enabled="True" TargetControlID="txtNewsDate">
                       </cc1:CalendarExtender>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="Please enter date." ControlToValidate="txtNewsDate" CssClass="validation_cls">
        </asp:RequiredFieldValidator>
    </td></tr>
<tr>
<td colspan="2">
<asp:Button ID="btnSubmit" runat="server"  class="btn btn-smalll" Text="Save" 
        onclick="btnSubmit_Click" />		
            <span id="spnMessage"></span>
            </td>
</tr>
</table>
</div>
 </div>



</asp:Content>






    

  


       



