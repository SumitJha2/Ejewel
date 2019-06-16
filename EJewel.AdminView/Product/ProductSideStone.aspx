<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="ProductSideStone.aspx.cs" Inherits="EJewel.AdminView.Product.ProductSideStone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        var active_tab = <%= _activeTab %>;
        $(document).ready(function () {
            $("#tabs").tabs({
                active: active_tab,
                activate: function (event, ui) {
                    active_tab = active_tab == 0 ? 1 : 0;
                    switch (active_tab) {
                        case 0:
                            {
                                //for diamond
                                location.href = "<%= _lnkDiamond %>";
                            }
                            break;
                        case 1:
                            {
                                //for gemstone
                                location.href = "<%= _lnkGemStone %>";
                            }
                            break;
                    }
                }
            });
        });

          function Validate_Available_Selection(){
         if (document.getElementById("<%=txtMinCarat.ClientID %>").value.trim() == "") {
            alert('Please enter min carat.');           
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtMinCarat.ClientID %>").value)) {
            alert('Please enter min carat in correct format.');
            return false;
        }
        else if (document.getElementById("<%=txtMaxCarat.ClientID %>").value.trim() == "") {
            alert('Please enter max carat.');
            return false;
        }
        else if (isNaN(document.getElementById("<%=txtMaxCarat.ClientID %>").value)) {
            alert('Please enter max carat correct format.');
            return false;
        }
        else {
            var isavailable = false;
            var chkLstStoneShape = document.getElementById('<%=chkLstStoneShape.ClientID%>');               
            var chkBoxCount= chkLstStoneShape.getElementsByTagName("input");         
            for(var i=0;i<chkBoxCount.length;i++)
            {
              if(chkBoxCount[i].checked==true)
              {            
              isavailable=true;
              }              
            }
            if(isavailable==false){
            alert('Please select atleast one shape.');
            return false;
            }
            else{
            return true;
            }

          }
       }

      
       function Validate_Grid_Section(){
       var sidestone_grid=document.getElementById("<%=dgvSideStone.ClientID %>");
      var rows_count = sidestone_grid.rows.length;
      var ischecked=false;

      //used for gemstone
      var iscustomize=false;
      var ischecked_gems_type=false;

      //validation used for checkbox

         // --------This section used for check atleast one parent checkbox----------   
       for(var k=1;k<rows_count;k++) {
         grid_elements=sidestone_grid.rows[k].getElementsByTagName("input");
         
      var control_checkbox=grid_elements[3]; 
      if(control_checkbox.checked==true){
         ischecked=true;
         }
       }
        if(ischecked==false){
         alert('Please check atleast one checkbox.');  
            return false;
         }
   // -------End  section---------- ----------------------------
   
   //--------------------section starts for the controls in grid view--------------  
       for(var i=1;i<rows_count;i++) {
         grid_elements=sidestone_grid.rows[i].getElementsByTagName("input");         
      var control_checkbox=grid_elements[3];      
       var  control_noofstone=grid_elements[4];
        var  control_radio=null;

       // portion used for gemsstone get customize radio button
       if(control_checkbox.checked==true)
       {
      if(active_tab==1)
      {
       control_radio=grid_elements[5];   
       if(control_radio.checked==true){
       iscustomize=true;
       }
      }
       
       var  control_dropdown=sidestone_grid.rows[i].getElementsByTagName("select");
        var control_settingtype=control_dropdown[0];

         if(control_checkbox.checked==true){
         ischecked=true;
         }        
      
        if(control_noofstone.value.trim() == "") {
            alert('Please enter no of stone in selected checkbox.');  
            return false;
          }
         else if(isNaN(control_noofstone.value)){
             alert('Please enter no of stone in correct format.');  
            return false;
            }
          else if(control_settingtype.selectedIndex==0){
         alert('Please selected setting type of selected checkbox.');  
           return false;
         }


         // this portion is used for gemstone 

     else if(active_tab==1)
      {
       control_radio=grid_elements[5]; 
       //for customization
        
                      
       if(control_radio.checked==true && ischecked==true){      
       iscustomize=true;    
       //get child grid for gemstone
       var control_table=sidestone_grid.rows[i].getElementsByTagName("table");
       var control_gems_child=control_table[0];
       var gems_noof_rows=control_gems_child.rows.length;
       for(var j=1;j<gems_noof_rows;j++){
       gems_grid_elements=control_gems_child.rows[j].getElementsByTagName("input");
       control_gems_checkbox_availableType=gems_grid_elements[1];
       if(ischecked==true)
       {
       if(control_gems_checkbox_availableType.checked==true){
       ischecked_gems_type=true; }      
       }
     }//end of inner forloop
     if(ischecked_gems_type==false){
     alert('Please checked atleast one available type.');
     return false;
     }
    }
    }
//end of portion used in gemstone

      }   }//end of outer forloop
        
        if(iscustomize==false){
        alert('Please check corrosponding cusmomize');
         return false;
        }
            return true;
       }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="contentHeader">
    <h1><asp:Literal ID="ltrlHeading" runat="server"></asp:Literal>&nbsp; (<asp:Label ID="lblSKU" runat="server"></asp:Label>)</h1>
</div>
<div class="container">
        <div class="grid-24">
        <!--Tab-->
<div id="tabs">
  <ul>
    <li><a href="#tabs-1">Diamond</a></li>
    <li><a href="#tabs-1">Gemstone</a></li>
    <li></li>
  </ul>
  <div id="tabs-1">
   <table class="table table-bordered table-striped" style="width:100%">
    <thead>
    </thead>
    <tbody>
    <tr><td colspan="3"><asp:Label ID="lblMessage" runat="server" Text="" CssClass="small_error"></asp:Label></td></tr>
     <tr><td>Stone Category</td><td>
         <asp:Label ID="lblStoneCategory" runat="server" ForeColor="Red"></asp:Label>
         </td><td>
             Shape</td></tr>
     <tr><td>Min. - Max.&nbsp; Ct. Range </td><td>
         <asp:TextBox ID="txtMinCarat" runat="server">0.00</asp:TextBox>
         &nbsp;-
          <asp:TextBox ID="txtMaxCarat" runat="server">0.00</asp:TextBox>
         </td><td rowspan="2">
      <div style="height:120px; width:250px;overflow:auto;">
          <asp:CheckBoxList ID="chkLstStoneShape" runat="server" RepeatLayout="Flow">
          </asp:CheckBoxList>
          </div>
         </td></tr>
      <tr><td colspan="2" valign="bottom">
      <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-green" 
              onclick="btnSearch_Click" OnClientClick="return Validate_Available_Selection()" /></td></tr>
      <tr><td colspan="3">
      <asp:GridView ID="dgvSideStone" runat="server" AutoGenerateColumns="False" 
                                Width="100%" 
              ShowHeaderWhenEmpty="True" CssClass="table table-bordered table-striped" 
              onrowdatabound="dgvSideStone_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnStoneID" runat="server" Value='<%# Eval("SideStoneId") %>' />
                                        <asp:HiddenField ID="hdnShapeId" runat="server" Value='<%# Eval("StoneShapeId") %>' />
                                        <asp:HiddenField ID="hdnCarat" runat="server" Value='<%# Eval("StoneCarate") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAvialable" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Shape" DataField="StoneShape" />
                                    <asp:BoundField HeaderText="Carat" DataField="StoneCarate"/>
                                    <asp:BoundField HeaderText="Cut" DataField="StoneCut"/>
                                    <asp:BoundField HeaderText="Color" DataField="StoneColor"/>
                                    <asp:BoundField HeaderText="Clarity" DataField="StoneClarity"/>
                                    <asp:TemplateField HeaderText="# Stone">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNoOfStone" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Setting Type">
                                    <ItemTemplate>
                                            <asp:DropDownList ID="ddlSettingType" runat="server" Width="120px">
                                            </asp:DropDownList>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Design Type">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlDesignType" runat="server" DataSource="<%# DesignTypeSource() %>" DataTextField="DesignType" DataValueField="DesignTypeId">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customize">
                                        <ItemTemplate>
                                            <asp:RadioButton ID="rdoCustomize" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:GridView ID="dgvStoneType" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.">
                                                    <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                        <asp:HiddenField ID="hdnStoneTypeStoneId" runat="server" Value='<%# Eval("SideStoneId") %>' />
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Available">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkStoneTypeAvailable" runat="server" />
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Color" DataField="StoneColor" />
                                                    <asp:BoundField HeaderText="Type" DataField="StoneType" />
                                                    <asp:BoundField HeaderText="Price ($)" DataField="StonePrice"/>
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
      </td></tr>
      <tr>
      <td colspan="3">
      <asp:Button ID="btnSave" runat="server" Text="Save Side Stone" CssClass="btn btn-green" 
              onclick="btnSave_Click" OnClientClick="return sure('Do you want to save...?')" 
              Visible="False" />&nbsp;
              <input type="button" value="« Back To Product" style="float:right;" class="btn btn-error" onclick="location.href='/Product/ProductList.aspx'" />
       
      </td>
        </tr>
        </tbody>
    </table>
  </div>
  </div>
    
    </div>
    </div>
    </asp:Content>