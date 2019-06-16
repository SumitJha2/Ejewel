<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProposalStories.aspx.cs" Inherits="EJewel.AdminView.Extras.ManageProposalStories" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">         
        .color
        {
         	color:Red;
        	
        }
    </style>
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/assets/webcontrols/fileupload/ajaxupload.3.5.js" type="text/javascript"></script>


   <div id="contentHeader">
    <h1>Manage Proposal Stories</h1>
</div>

 <div class="container">
 <div class="grid-24">
       <asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>
<table class="table table-bordered table-striped" style="width:100%">
<tr><td>Story Header<span class="small_error">&nbsp;*</span></td><td>
    <asp:HiddenField ID="hdnID" runat="server" Value="0" />
    <asp:TextBox ID="txtStoryHeader" runat="server" CssClass="common_width"></asp:TextBox> 
    <asp:RequiredFieldValidator ID="rfvStoryHeader" CssClass="color" runat="server"  ControlToValidate="txtStoryHeader" ErrorMessage="Please enter story header"></asp:RequiredFieldValidator>
    </td>
    </tr>
<tr><td>Story Description<span class="small_error">&nbsp;*</span></td><td>
<cc1:Editor runat="server" ID="txtDescription" Height="100px" AutoFocus="true" />  
 <%-- <asp:TextBox ID="txtDescription" runat="server" CssClass="common_width" Width="215px" TextMode="MultiLine"></asp:TextBox>--%>
  <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Please enter story description"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td>Status</td><td>
    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width"  Height="26px" Width="228px">
    </asp:DropDownList>   
    </td></tr>
<tr><td>
Image&nbsp;<span class="hints">Size </span></td><td>
     <input type="file" name="FileUpload" id="FileUpload" onchange="uploadFile()"/> &nbsp;
                <span id="spnProgress" runat="server"></span>
                <asp:HiddenField ID="hdnFile" runat="server" />
               <%-- <input type="hidden" id="hdnFile" value="" />--%>
                    </td></tr>
<tr>
<td colspan="2">
			<%--<input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" class="btn btn-smalll" />--%>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-smalll" Text="Save" />
            <span id="spnMessage" runat="server"></span>
            </td>
</tr>
</table>
<script type="text/javascript">
    //for upload file
    function uploadFile() {
        try {
           // $("#<%=hdnFile.ClientID %>").val('');
            var FileUpload = $("#FileUpload");
            var spnProgress = $("#<%=spnProgress.ClientID %>");
            new AjaxUpload(FileUpload, {
                action: '/Handler/ImageUploadHandler.ashx',
                //Name of the file input box  
                name: 'FileUpload',
                data: { 'upload_folder': 'proposalstory', 'check_size': 0, 'width': 0, 'height': 0 },
                onChange: function (file, ext) {
                    spnProgress.html('<img src="/asset/template/images/extra/loader_16.gif" alt="please wait" />');
                },
                onComplete: function (file, response) {
                    //remove html formating
                    response = response.replace(/(<([^>]+)>)/ig, "");
                    var resText = response.split('$');
                    if (resText[0] == 'success') {
                        spnProgress.html('<img src="/upload/images/proposalstory/' + resText[1] + '" alt="Photo" style="width:50px;height:50px;" />');
                        document.getElementById("<%=hdnFile.ClientID %>").value = resText[1];
                       
                    }
                    else {
                        spnProgress.html(resText[1]);

                    }
                }
            });
        }
        catch (e) {
            alert(e);
        }
    }

    uploadFile();

</script>
 </div>
 </div>
</asp:Content>
