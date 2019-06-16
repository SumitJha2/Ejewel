<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoneCertificate.aspx.cs" Inherits="EJewel.AdminView.Master.Certificate.StoneCertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stone Certificate</title>
    <style type="text/css">
        @import url(http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600);
        body { font: 12px/1.7em "Open Sans", "trebuchet ms", arial, sans-serif; color: #444; }
    </style>
    <!--CSS-->
     <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/form.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/message.css" type="text/css" />
    <link rel="stylesheet" href="~/assets/themes/admin/stylesheets/table.css" type="text/css" />
    <!--Script-->
    <script src="/assets/themes/admin/javascripts/all.js" type="text/javascript"></script>
    <script src="/assets/themes/admin/javascripts/globalscript.js" type="text/javascript"></script>
    <script src="/asset/opencontrol/fileupload/ajaxupload.3.5.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">   

      <table class="table table-bordered table-striped" style="width:100%">
        <thead>
         <tr><th colspan="5">
             Stone Certificate</th></tr>
         </thead>
         <tbody>         
        <tr>
			<td>SKU:</td>
			<td>
            <asp:Label ID="lblSKU" runat="server" CssClass="common_width"></asp:Label>
            <br />
            <asp:HiddenField ID="hdnid" runat="server" Value="0" />
            <asp:HiddenField ID="hdnStoneid" runat="server" />
           </td>
		</tr>
		<tr>
			<td>Depth:<span class="small_error">&nbsp;*</span></td>
			<td>
          <asp:TextBox ID="txtDepth" runat="server" CssClass="common_width"></asp:TextBox>            
            </td>
		</tr>
        <tr>
			<td>Table:<span class="small_error">&nbsp;*</span></td>
			<td>
             <asp:TextBox ID="txtTable" runat="server" CssClass="common_width"></asp:TextBox>       
            
            </td>
		</tr>
        <tr>
			<td>Gridle:<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:DropDownList ID="ddlGridle" runat="server" CssClass="common_width"></asp:DropDownList>            
            </td>
		</tr>
        <tr>
			<td>Symmetry:<span class="small_error">&nbsp;*</span></td>
			<td>
           <asp:DropDownList ID="ddlSymmetry" runat="server" CssClass="common_width">
            </asp:DropDownList>            
            </td>
		</tr>
        <tr>
			<td>Culet:<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:DropDownList ID="ddlCulet" runat="server" CssClass="common_width">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<td>Polish:<span class="small_error">&nbsp;*</span></td>
			<td>          
             <asp:DropDownList ID="ddlPolish" runat="server" CssClass="common_width">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<td>Flouresence:<span class="small_error">&nbsp;*</span></td>
			<td>         
             <asp:DropDownList ID="ddlFlouresence" runat="server" CssClass="common_width">
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<td>Measurement:<span class="small_error">&nbsp;*</span></td>
			<td>
          <asp:TextBox ID="txtMeasurement" runat="server" CssClass="common_width"></asp:TextBox>
  
            </td>
		</tr>
         <tr>
			<td>Crown:<span class="small_error">&nbsp;*</span></td>
			<td>          
               <asp:TextBox ID="txtCrown" runat="server" CssClass="common_width"></asp:TextBox>
            </td>
		</tr>
         <tr>
			<td>Crown Angle:<span class="small_error">&nbsp;*</span></td>
			<td>         
             <asp:TextBox ID="txtCrownAngle" runat="server" CssClass="common_width"></asp:TextBox>    
            </td>
		</tr>
         <tr>
			<td>Pavillion:<span class="small_error">&nbsp;*</span></td>
			<td>          
             <asp:TextBox ID="txtPavillion" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>
		</tr>
        <tr>
			<td>Pavillion Angle:<span class="small_error">&nbsp;*</span></td>
			<td>          
              <asp:TextBox ID="txtPavillionAngle" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>
		</tr>
        <tr>
			<td>Certification:<span class="small_error">&nbsp;*</span></td>
			<td>           
             <asp:TextBox ID="txtCertification" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>
		</tr>
         <tr>
			<td>Lab:<span class="small_error">&nbsp;*</span></td>
			<td>           
            <asp:DropDownList ID="ddlLab" runat="server" CssClass="common_width"></asp:DropDownList>
            </td>
		</tr>
         <tr>
			<td>File:</td>
			<td>  
             
             <input type="file" name="FileUpload" id="FileUpload" onchange="uploadFile()" CssClass="common_width"/> &nbsp;               
             
                <asp:Label ID="spnProgress" runat="server"></asp:Label>

                <input type="hidden" id="hdnFile" value="" />
          
                    </td> 
		</tr>
            <tr>
			<td>Status:</td>
			<td>           
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="common_width">           
            </asp:DropDownList>
            </td>
		</tr>
         <tr>
			<td colspan="2">            
                    <input type="button" value="Save" onclick="btnSave()" class="btn btn-small" />            
		     </td>
             </tr>
             </tbody>		
        </table> 
       

        <script type="text/javascript">
            function validate() {
                if (document.getElementById("<%=txtDepth.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter depth.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtDepth.ClientID %>").value)) {
                    $("#spnMessage").html('Enter depth in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtTable.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter depth.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtTable.ClientID %>").value)) {
                    $("#spnMessage").html('Enter depth in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=ddlGridle.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select griddle.');
                    return false;
                }
                else if (document.getElementById("<%=ddlSymmetry.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select symmetry.');
                    return false;
                }
                else if (document.getElementById("<%=ddlCulet.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select culet.');
                    return false;
                }
                else if (document.getElementById("<%=ddlPolish.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select polish.');
                    return false;
                }
                else if (document.getElementById("<%=ddlFlouresence.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select flouresence.');
                    return false;
                }
                else if (document.getElementById("<%=txtMeasurement.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter depth.');
                    return false;
                }
                else if (document.getElementById("<%=txtCrown.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter crown.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtCrown.ClientID %>").value)) {
                    $("#spnMessage").html('Enter crown in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtCrownAngle.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter crown angle.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtCrownAngle.ClientID %>").value)) {
                    $("#spnMessage").html('Enter crown angle in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtPavillion.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter pavillion.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtPavillion.ClientID %>").value)) {
                    $("#spnMessage").html('Enter pavillion  in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtPavillionAngle.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter pavillion angle.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtPavillionAngle.ClientID %>").value)) {
                    $("#spnMessage").html('Enter pavillion angle in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtCertification.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter certification.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtCertification.ClientID %>").value)) {
                    $("#spnMessage").html('Enter certification angle in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=ddlLab.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select lab.');
                    return false;
                }
                else {
                    return true;
                }
          
            
            
            }
            function btnSave() {
                try {
                    if (validate()) {
                        var sku = $("#<%=lblSKU.ClientID %>").val();
                        var id = parseInt($("#<%=hdnid.ClientID %>").val());
                        //stoneid     
                        var stoneid = parseInt($("#<%=hdnStoneid.ClientID %>").val());
                        var depth = parseFloat($("#<%=txtDepth.ClientID %>").val());
                        var table = parseFloat($("#<%=txtTable.ClientID %>").val());
                        var gridle = parseInt($("#<%=ddlGridle.ClientID %>").val());
                        var symmetry = parseInt($("#<%=ddlSymmetry.ClientID %>").val());
                        var culet = parseInt($("#<%=ddlCulet.ClientID %>").val());
                        var polish = parseInt($("#<%=ddlPolish.ClientID %>").val());
                        var fluorence = parseInt($("#<%=ddlFlouresence.ClientID %>").val());
                        var measurement = $("#<%=txtMeasurement.ClientID %>").val();
                        var crown = parseFloat($("#<%=txtCrown.ClientID %>").val());
                        var crownangle = parseFloat($("#<%=txtCrownAngle.ClientID %>").val());
                        var pavillion = parseFloat($("#<%=txtPavillion.ClientID %>").val());
                        var pavillionangle = parseFloat($("#<%=txtPavillionAngle.ClientID %>").val());
                        var cerification = parseFloat($("#<%=txtCertification.ClientID %>").val());
                        var lab = parseFloat($("#<%=ddlLab.ClientID %>").val());
                        var status = parseInt($("<%=ddlStatus.ClientID %>").val())
                        var uploadFileName = $("#hdnFile").val();
                        var status = parseInt($("#<%=ddlStatus.ClientID %>").val()) == 1 ? true : false;
                        var model = { CertificateID: id, CertificateDepth: depth, StoneID: stoneid, CertificateTable: table, GridleId: gridle, SymmetryId: symmetry, PolishId: polish, CuletId: culet, FlouresenceID: fluorence, CertificateMeasurement: measurement, CertificateCrown: crown, CertificateCrownAngle: crownangle, CertificatePavillion: pavillion, CertificatePavillionAngle: pavillionangle, CertificateCertification: cerification, LabId: lab, CertificationFile: uploadFileName, Status: status };
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/SaveUpdateStoneCertificate",
                            data: JSON.stringify({ model: model }),
                            // data: "{model:" + JSON.stringify(model) + "}",
                            dataType: "json",
                            success: function (data) {
                                if (id == 0) {
                                    alert("Certificate details saved successfully.");
                                    document.getElementById('form1').reset();
                                }
                                else {
                                    alert("Certificate details updated successfully.");
                                }

                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    }

                }
                catch (e) {
                    alert(e);
                } 
                }       

        function uploadFile() {
            try {
                $("#hdnFile").val('');
                var FileUpload = $("#FileUpload");
                //var spnProgress = $('#spnProgress');
                var spnProgress = $("#<%=spnProgress.ClientID %>");
                new AjaxUpload(FileUpload, {
                    action: '/Handler/ImageUploadHandler.ashx',
                    //Name of the file input box  
                    name: 'FileUpload',
                    data: { 'upload_folder': 'certificate', 'check_size': 0, 'width': 0, 'height': 0 },
                    onChange: function (file, ext) {
                        spnProgress.html('<img src="/asset/template/images/extra/loader_16.gif" alt="please wait" />');
                    },
                    onComplete: function (file, response) {
                        //remove html formating
                        response = response.replace(/(<([^>]+)>)/ig, "");
                        var resText = response.split('$');
                        if (resText[0] == 'success') {
                            spnProgress.html('<img src="/upload/images/certificate/' + resText[1] + '" alt="Photo" style="width:50px;height:50px;" />');
                            $("#hdnFile").val(resText[1]);
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
    </form>
</body>
</html>
