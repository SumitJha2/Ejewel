<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageCenterStone.aspx.cs" Inherits="EJewel.AdminView.Master.Stone.ManageCenterStone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contentHeader">
    <h1>Manage Center Stone (FD)</h1>
</div>

<div class="container">
        <div class="grid-24">
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
         <tr><th colspan="5">
             Manage Center Stone</th></tr>
         </thead>         
         <tbody>
         <tr><td colspan="5"> &nbsp;<span id="spnMessage"></span></td></tr>
         <tr>
			<td>SKU<span class="small_error">&nbsp;*</span></td>
			<td>
                <asp:HiddenField ID="hdnID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnCSId" runat="server" />
         <asp:TextBox ID="txtSKU" runat="server" CssClass="common_width"></asp:TextBox>           
            </td>
            <td>&nbsp;</td>
            <td>Cut <span class="small_error">&nbsp;*</span></td>
			<td>           
            <asp:DropDownList ID="ddlCut" runat="server" CssClass="common_width"></asp:DropDownList>  
            </td>
		</tr>


		<tr>
					
			<td>Color<span class="small_error">&nbsp;*</span></td>
			<td>
          <asp:DropDownList ID="ddlColor" runat="server" CssClass="common_width"></asp:DropDownList>    
            </td>
            <td>&nbsp;</td>
            <td>Clarity<span class="small_error">&nbsp;*</span></td>
			<td>           
                <asp:DropDownList ID="ddlClarity" runat="server" CssClass="common_width"></asp:DropDownList>       
            </td>
		</tr>
       
        <tr>
			<td>           
                Shape<span class="small_error">&nbsp;*</span></td>
			<td>           
         <asp:DropDownList ID="ddlShape" runat="server" CssClass="common_width"></asp:DropDownList>       
            </td>
			<td>           
                &nbsp;</td>
                <td>Carate<span class="small_error">&nbsp;*</span></td>
			<td>
         <asp:TextBox ID="txtCarate" runat="server" CssClass="common_width"></asp:TextBox>   
            </td>	
			
		</tr>
        <tr>
        <td>
           Price ($) <span class="small_error">&nbsp;*</span></td>
			<td>
              <asp:TextBox ID="txtPrice" runat="server" CssClass="common_width"></asp:TextBox>    
            </td>
			
			<td>
                &nbsp;</td>
                <td>Discount</td>
                <td> <asp:TextBox ID="txtDisCount" runat="server" CssClass="common_width"></asp:TextBox>
                &nbsp;
                <asp:DropDownList ID="ddlDiscountType" runat="server">
                <asp:ListItem Text="$" Value="1"></asp:ListItem>
                 <asp:ListItem Text="%" Value="2"></asp:ListItem>
                </asp:DropDownList>
                </td>
			
		</tr>
      
        <tr>
			<td colspan="5"><b>Certificate Details</b></td>
			</tr>
			

          <tr>
			<td>Depth(%)<span class="small_error">&nbsp;*</span></td>
			<td>
             <asp:TextBox ID="txtDepth" runat="server" CssClass="common_width"></asp:TextBox>      
            </td>	
			<td>
                &nbsp;</td>
			<td>
                Table(%)<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:TextBox ID="txtTable" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>
		</tr>
           <tr>
			<td>Gridle<span class="small_error">&nbsp;*</span></td>
			<td>
              <asp:DropDownList ID="ddlGridle" runat="server" CssClass="common_width"></asp:DropDownList>        
            </td>	
			<td>
                &nbsp;</td>
			<td>
                Symmetry<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:DropDownList ID="ddlSymmetry" runat="server" CssClass="common_width">
            </asp:DropDownList>       
            </td>
		</tr>

          <tr>
			<td>Culet<span class="small_error">&nbsp;*</span></td>
			<td>
            <asp:DropDownList ID="ddlCulet" runat="server" CssClass="common_width">
            </asp:DropDownList>       
            </td>	
			<td>
                &nbsp;</td>
			<td>
                Polish<span class="small_error">&nbsp;*</span></td>
			<td>
             <asp:DropDownList ID="ddlPolish" runat="server" CssClass="common_width">
            </asp:DropDownList>   
            </td>
		</tr>

         <tr>
			<td>Flouresence<span class="small_error">&nbsp;*</span></td>
			<td>
              <asp:DropDownList ID="ddlFlouresence" runat="server" CssClass="common_width">
            </asp:DropDownList>    
            </td>	
			<td>
                &nbsp;</td>
			<td>
                Measurement(mm.)<span class="small_error">&nbsp;*</span></td>
			<td>
               <asp:TextBox ID="txtMeasurement" runat="server" CssClass="common_width"></asp:TextBox> 
            </td>
		</tr>

          <tr>
			<td>Crown</td>
			<td>
                <asp:TextBox ID="txtCrown" runat="server" CssClass="common_width"></asp:TextBox>
            </td>	
			<td>
                &nbsp;</td>
			<td>
               Crown Angle</td>
			<td>
               <asp:TextBox ID="txtCrownAngle" runat="server" CssClass="common_width"></asp:TextBox> 
            </td>
		</tr>

          <tr>
			<td>Pavillion</td>
			<td>
               <asp:TextBox ID="txtPavillion" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>	
			<td>
                &nbsp;</td>
			<td>
              Pavillion Angle</td>
			<td>
              <asp:TextBox ID="txtPavillionAngle" runat="server" CssClass="common_width"></asp:TextBox> 
            </td>
		</tr>
          <tr>
			<td>Certificate</td>
			<td>
              <asp:TextBox ID="txtCertification" runat="server" CssClass="common_width"></asp:TextBox>  
            </td>	
			<td>
                &nbsp;</td>
			<td>
             Lab<span class="small_error">&nbsp;*</span></td>
			<td>
             <asp:DropDownList ID="ddlLab" runat="server" CssClass="common_width"></asp:DropDownList>
            </td>
		</tr>
            

         <tr>
			<td>File(URL)</td>
			<td>                  
                    <asp:TextBox ID="txtFile" runat="server" CssClass="common_width"></asp:TextBox>
                    </td> 
                    <td></td>
			<td>
             Status</td>
			<td>
             <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="common_width">  
              </asp:DropDownList> 
            </td>
		</tr>
        <tr>
			<td colspan="5">
<input id="btnSave" type="button" value="Save" onclick="btnSave_onclick()" class="btn btn-small" />
<input id="btnImage" type="button" value="Add Image"  class="btn btn-small" onclick="return btnImage_onclick()" />
            
               </td>
		</tr>
    </tbody>
        </table>
        </div>
        </div>
        <script type="text/javascript">
        var sku=null;
            function loadStoneDetails(value) {
                //load cut
                fill_dropdown_data(value, 'cut', "<%= ddlCut.ClientID %>");
                //load color
                fill_dropdown_data(value, 'color', "<%= ddlColor.ClientID %>");
                //load clarity
                fill_dropdown_data(value, 'clarity', "<%= ddlClarity.ClientID %>");
                //load shape
                fill_dropdown_data(value, 'shape', "<%= ddlShape.ClientID %>");
                //load type
            }
            function fill_dropdown_data(catgeory_id, view_name, drop_down_id) {
                //
                try {
                    $("#" + drop_down_id).empty();
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetStoneSpecificationListFromCategory",
                        data: JSON.stringify({ categoryID: catgeory_id, pageName: view_name }),
                        dataType: "json",
                        success: function (successResult) {
                            $("#" + drop_down_id).append('<option value="">--Select--</option>');
                            $.each(successResult.d, function (key, val) {
                                fillDropDown(drop_down_id, val.AutoID, val.Name);
                            });
                        },
                        error: function (data) {
                        }
                    });
                }
                catch (e) {
                    alert(e);
                }
            }
            // function for validation
            function validate() {
                $("#spnMessage").css("color", "red");
                if (document.getElementById("<%=txtSKU.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter sku.');
                    return false;
                }
                else if (document.getElementById("<%=ddlCut.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select cut.');
                    return false;
                }
                else if (document.getElementById("<%=ddlColor.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select color.');
                    return false;
                }
                else if (document.getElementById("<%=ddlClarity.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select clarity.');
                    return false;
                }
                else if (document.getElementById("<%=ddlShape.ClientID %>").selectedIndex == 0) {
                    $("#spnMessage").html('Please select shape.');
                    return false;
                }
                else if (document.getElementById("<%=txtCarate.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter carate.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtCarate.ClientID %>").value)) {
                    $("#spnMessage").html('Enter carate in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtPrice.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter price.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtPrice.ClientID %>").value)) {
                    $("#spnMessage").html('Enter price in correct format.');
                    return false;
                }
                else if (document.getElementById("<%=txtDepth.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter depth.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtDepth.ClientID %>").value)) {
                    $("#spnMessage").html('Enter depth in correct format.');
                    return false;
                }

                else if (document.getElementById("<%=txtTable.ClientID %>").value.trim() == "") {
                    $("#spnMessage").html('Please enter table.');
                    return false;
                }
                else if (isNaN(document.getElementById("<%=txtTable.ClientID %>").value)) {
                    $("#spnMessage").html('Enter table in correct format.');
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
                    $("#spnMessage").html('Please enter measurement.');
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

            //save the details of the save
            function btnSave_onclick() {
                try {
                    if (sure("Do you want to save...?")) {
                        if (validate()) {
                            var id = parseInt($("#<%= hdnID.ClientID %>").val());

                             sku = $("#<%= txtSKU.ClientID %>").val();
                            var cut = parseInt($("#<%= ddlCut.ClientID %>").val());
                            var color = parseInt($("#<%= ddlColor.ClientID %>").val());
                            var clarity = parseInt($("#<%= ddlClarity.ClientID %>").val());
                            var shape = parseInt($("#<%= ddlShape.ClientID %>").val());
                            var carate = parseFloat($("#<%= txtCarate.ClientID %>").val());
                            var price = parseFloat($("#<%= txtPrice.ClientID %>").val());
                            var status = parseInt($("#<%= ddlStatus.ClientID %>").val()) == 1 ? true : false;
                            //---------------------------------------
                            var discount = isNaN($("#<%=txtDisCount.ClientID %>"))?0:parseFloat($("#<%=txtDisCount.ClientID %>").val());

                            var discountype = $("#<%=ddlDiscountType.ClientID %>").val();

                            // certificate details

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
                            var cerification = $("#<%=txtCertification.ClientID %>").val();                     
                            crown = isNaN(crown) ? 0 : crown;
                            crownangle = isNaN(crownangle) ? 0 : crownangle;
                            pavillion = isNaN(pavillion) ? 0 : pavillion;
                            pavillionangle = isNaN(pavillionangle) ? 0 : pavillionangle;
                            //
                            var lab = parseFloat($("#<%=ddlLab.ClientID %>").val());
                            lab = isNaN(lab) ? 0 : lab;
                            var uploadFileName = $("#<%= txtFile.ClientID %>").val();
                            var model = { StoneId: id, SKU: sku, StoneCutId: cut, StoneColorId: color, StoneClarityId: clarity, StoneShapeId: shape, StoneCarate: carate, StonePrice: price, CertificateDepth: depth, CertificateTable: table, CertificateGridleId: gridle, CertificateSymmetryId: symmetry, CertificatePolishId: polish, CertificateCuletId: culet, CertificateFlouresenceId: fluorence, CertificateMeasurement: measurement, CertificateCrown: crown, CertificateCrownAngle: crownangle, CertificatePavillion: pavillion, CertificatePavillionAngle: pavillionangle, Certification: cerification, CertificateCertificationLabId: lab, CertificationFile: uploadFileName, Status: status, Discount: discount, DiscountType: discountype
                            };
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "/Services/AdminServices.asmx/SaveUpdateCenterStone",
                                data: JSON.stringify({ model: model }),
                                dataType: "json",
                                success: function (data) {
                                    $("#spnMessage").html(data.d);
                                    $("#spnMessage").css("color", "green");
                                    if (id == 0) {                                    
                                        $("#spnmsg").html(data.d);
                                    
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
                }
                catch (e) {
                    alert(e);
                }
            }
            function btnImage_onclick() {
               
                popupwindow("/Master/Stone/CenterstoneImage.aspx?sku=" + $("#<%= txtSKU.ClientID %>").val(), 700, 500); 
            }

        </script>
</asp:Content>
