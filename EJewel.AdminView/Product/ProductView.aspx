<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="EJewel.AdminView.Product.ProductView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Details</title>
    <link href="/asset/template/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/asset/template/css/table.css" rel="stylesheet" type="text/css" />
  
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
    <!--Product Details-->
    <table class="table table-bordered table-striped" style="width:100%">
    <tr><th colspan="4" >Product Details
    </th></tr>
    <tr>
    <td colspan="4"> 
    <table width="100%"  class="table table-bordered table-striped">
    <tbody>
    <tr><td>   
    <asp:DetailsView ID="dvProductDetails" runat="server" AutoGenerateRows="false" GridLines="None">
    <Fields>
    <asp:BoundField HeaderText="Product Category" DataField="SubCategoryName"   /> 
     <asp:BoundField HeaderText="SKU" DataField="SKU"  />
      <asp:BoundField HeaderText="Title" DataField="ProductTitle"  /> 
       <asp:BoundField HeaderText="Page Title" DataField="PageTitle"  /> 
       <asp:BoundField HeaderText="Description" DataField="ProductDescripation"  />          
         <asp:BoundField HeaderText="Meta Keyword" DataField="MetaKeyword"  /> 
          <asp:BoundField HeaderText="Meta Description" DataField="MetaDescripation"  />
    </Fields> 
    <HeaderStyle CssClass="header_grid" />    
    </asp:DetailsView>
    </td></tr>
    </tbody>
    </table>    
    </td>
    </tr>

    <!------------Metal Information Part-------------------------------------->
    
    <tr><td colspan="4">
    <table width="100%" class="table table-bordered table-striped">
    <tbody>
     <tr><th>Metal Information</th></tr>
      <tr><td><b>Metal Weight (g.m.) : </b>
    <asp:Label ID="lblMetalWeight" runat="server"></asp:Label>
    </td></tr>
    <tr><td>
   <b>Metal Width (g.m.) : </b> 
    <asp:Label ID="lblMetalWidth" runat="server"></asp:Label>  
 </td></tr>
    <tr>
    <td>
     <asp:GridView ID="dgvMetalType" runat="server" class="table table-bordered table-striped" AutoGenerateColumns="False" Width="100%" 
        onrowdatabound="dgvMetalType_RowDataBound" GridLines="None" >
            <Columns>
                <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                <asp:Label ID="lblSRNO" runat="server"></asp:Label>
                  <%-- <%# Container.DataItemIndex+1 %>--%>
                    <asp:HiddenField ID="hdnMetalTypeID" runat="server" Value='<%# Eval("MetalTypeId") %>' />
                 </ItemTemplate>
                 </asp:TemplateField>
                <asp:TemplateField HeaderText="Avialable" Visible="false">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAvialableMetal" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>           
               <asp:TemplateField HeaderText="Available Metal Type">
               <ItemTemplate>
               <asp:Label ID="lblMetaltype" runat="server" Text='<%# Eval("MetalTypeName") %>'></asp:Label>
               </ItemTemplate>
               </asp:TemplateField>

                <asp:TemplateField HeaderText="Default">
                    <ItemTemplate>

                    <asp:Label ID="lblImage" runat="server"></asp:Label>
                 <%--   <img id="imgCorrect" runat="server"/>--%>         
                
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>   
    </td>
    </tr>
    </tbody>
    </table>   
   </td>
   </tr>
   
    <!---------------------- Center Stone Information-------------------------------------->
    
  <tr><th colspan="4" >Center Stone Information</th>
  </tr>
  
  <tr><td colspan="4">
  <table width="100%" class="table table-bordered table-striped">
  <tbody>
   <tr><td>
           <b><asp:Label ID="MinCarat" runat="server" Text="Min Carat :"></asp:Label></b>
                <asp:Label ID="lblMinCarat" runat="server"></asp:Label>
           </td></tr> 
            <tr><td><b><asp:Label ID="MaxCarat" runat="server" Text="Max Carat :"></asp:Label></b>
                <asp:Label ID="lblMaxCarat" runat="server"></asp:Label>
           </td></tr> 
           
           <tr><td><b><asp:Label ID="SettingType" runat="server" Text="Setting Type :"></asp:Label></b>
                <asp:Label ID="lblSettingTypeCenterStone" runat="server"></asp:Label>
           </td></tr>          
  
  <tr><td>
     <asp:GridView ID="dgvCenterStone" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-striped"
                Width="100%" onrowdatabound="dgvCenterStone_RowDataBound" GridLines="None" CellPadding="0"          
    ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Available Shape">
                    <ItemTemplate>
                    <asp:Label ID="lblCenterStoneShape" runat="server" Text='<%# Eval("StoneShape") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Default">
                    <ItemTemplate>
                    <asp:Label ID="lblImage" runat="server"></asp:Label>          
                    <asp:HiddenField ID="hdnDefault" runat="server" Value='<% #Eval("DefaultShape") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>


                  </Columns>
            </asp:GridView>
            </td></tr>
               </tbody>
            </table>
            
</td></tr>

 <!---------------------- Side Stone Information-------------------------------------->
    <tr><th colspan="4">Side Stone Information</th></tr>

  <tr><th colspan="4">Side Stone (Diamond)</th></tr>
  <tr><td colspan="4">
  <table width="100%" class="table table-bordered table-striped">
  <tbody>
  <tr><td><b>Category :</b>
  <asp:Label ID="lblCategory" runat="server" Text="Diamond"></asp:Label></td></tr>
         
     <tr><td><b>Min. Ct. Range :</b>
         <asp:Label ID="lblMinCaratDiamondSS" runat="server"></asp:Label>
         </td></tr>
      <tr><td><b>Max. Ct. Range :</b>
          <asp:Label ID="lblMaxCaratDiamondSS" runat="server"></asp:Label>
          </td></tr>
          
         <tr><td>
         <b>Available Shape</b>
         <asp:BulletedList ID="bltSideStoneDiamondShape" runat="server"></asp:BulletedList></td></tr>
          

        <tr><td>
           
           <!----------  Used for Side Stone Details-------------------------------------->
            <asp:GridView ID="dgvSideStone_Diamond" runat="server"  AutoGenerateColumns="False" 
                                Width="100%" 
              ShowHeaderWhenEmpty="True" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnSideStoneID" runat="server" Value='<%# Eval("ProductSideStoneId") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>                                 
                                    <asp:BoundField HeaderText="Shape" DataField="shape" />
                                    <asp:BoundField HeaderText="Carat" DataField="StoneCarate"/>
                                    <asp:BoundField HeaderText="Cut" DataField="cut"/>
                                    <asp:BoundField HeaderText="Color" DataField="color"/>
                                    <asp:BoundField HeaderText="Clarity" DataField="clarity"/>                                   
                                    <asp:BoundField HeaderText="# Stone" DataField="NoOfStone"/>
                                    <asp:BoundField HeaderText="Setting Type" DataField="settingType"/> 
                                                          
                               </Columns>                             
                            </asp:GridView>
                      
          </td>
          </tr>
          </tbody>
          </table>
  </td>
  </tr>



    
  <tr><th colspan="4" >Side Stone(Gemstone)</th></tr>
  <tr><td colspan="4">
  <table width="100%" class="table table-bordered table-striped">
  <tbody>
  <tr><td><b>Category :</b>
  <asp:Label ID="Label1" runat="server" Text="Gemstone"></asp:Label></td></tr>
         
     <tr><td><b>Min. Ct. Range :</b>
         <asp:Label ID="lblGemstoneMin" runat="server"></asp:Label>
         </td></tr>
      <tr><td><b>Max. Ct. Range :</b>
          <asp:Label ID="lblGemstoneMax" runat="server"></asp:Label>
          </td></tr>

          <tr><td>
          <b>Available Shape</b>
          <asp:BulletedList ID="bltSideStoneGemstone_Shape" runat="server"></asp:BulletedList>

          </td></tr>


       <!-- Load stone shape for side stone diamond-->
          <tr>
          <td>
          <asp:GridView ID="gvSidestoneGemsShape" runat="server" AutoGenerateColumns="False"  class="table table-bordered table-striped"
                Width="100%" 
               GridLines="None" CellPadding="0"
               
    ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Available Shape">
                    <ItemTemplate>
                    <asp:Label ID="lblSideStoneShape" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                   <asp:HiddenField ID="hdnSideStoneShapeID" runat="server" Value='<%# Eval("AutoID") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
            </asp:GridView>             
               <asp:GridView ID="dgvSideStone_GemesStone" runat="server" AutoGenerateColumns="False" 
                                Width="100%" ShowHeaderWhenEmpty="True"  OnRowDataBound="dgvSideStone_Gems_rowDataBound" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnSideStoneID" runat="server" Value='<%# Eval("ProductSideStoneId") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>                                 
                                    <asp:BoundField HeaderText="Shape" DataField="shape" />
                                    <asp:BoundField HeaderText="Carat" DataField="StoneCarate"/>
                                    <asp:BoundField HeaderText="Cut" DataField="cut"/>
                                    <asp:BoundField HeaderText="Color" DataField="color"/>
                                    <asp:BoundField HeaderText="Clarity" DataField="clarity"/>                                   
                                    <asp:BoundField HeaderText="# Stone" DataField="NoOfStone"/>
                                     <asp:BoundField HeaderText="Setting Type" DataField="settingType"/> 
                                    <asp:TemplateField HeaderText="Customize">
                                     <ItemTemplate>
                                    <asp:HiddenField ID="hdnCustomize" runat="server" Value='<%# Eval("IsCustomize") %>' />
                                    <asp:Label ID="lblCustomize" runat="server"></asp:Label>
                                     </ItemTemplate>                                                                
                                     </asp:TemplateField>  

                                     <asp:TemplateField HeaderText="Type">
                                     <ItemTemplate>  
                                     <asp:GridView ID="lstSideStoneGems" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                                Width="100%" ShowHeaderWhenEmpty="True">
                                <Columns>
                                   <asp:BoundField HeaderText="Color" DataField="StoneColor" />
                                    <asp:BoundField HeaderText="Type" DataField="StoneType"/>
                                    <asp:BoundField HeaderText="Price" DataField="StonePrice"/>
                                </Columns>
                                </asp:GridView>
                                     
                                                                                               
                                    
                                     </ItemTemplate>                                                                
                                     </asp:TemplateField>  
                                                                   
                               </Columns>
                            </asp:GridView>
                      
          </td>
          </tr>
          </tbody>
         </table>
         </td>
         </tr>

<!----------------------Matching Band Information-------------------------------------->
    <tr><th colspan="4" >Matching Band Information
    </th></tr>

  <tr><th colspan="4">Matching Band (Diamond)</th></tr>
  <tr><td colspan="4">
  <table width="100%" class="table table-bordered table-striped">
  <tbody>
  <tr><td><b>Category :</b>
  <asp:Label ID="Label2" runat="server" Text="Diamond"></asp:Label></td></tr>
         
     <tr><td><b>Min. Ct. Range :</b>
         <asp:Label ID="lblMinRangeForMatchingBand" runat="server"></asp:Label>
         </td></tr>
      <tr><td><b>Max. Ct. Range :</b>
          <asp:Label ID="lblMaxRangeForMatchingBand" runat="server"></asp:Label>
          </td></tr>

           <tr><td>
         <b>Available Shape</b>
         <asp:BulletedList ID="bltMatchingBandDiamond" runat="server"></asp:BulletedList></td></tr>
          



               <!-- Load stone shape for Matching Band diamond-->
          <tr>
          <td>
          <asp:GridView ID="gvStoneShapeForMatchingBand" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                Width="100%" 
               GridLines="None" CellPadding="0"
               
    ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Available Shape">
                    <ItemTemplate>
                    <asp:Label ID="lblSideStoneShape" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                   <asp:HiddenField ID="hdnSideStoneShapeID" runat="server" Value='<%# Eval("AutoID") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
            </asp:GridView> 
   
            
 <asp:GridView ID="gvMatchingBandDiamond" runat="server" AutoGenerateColumns="False" 
                                Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnStoneID" runat="server" Value='<%# Eval("ProductSideStoneId") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>                                 
                                    <asp:BoundField HeaderText="Shape" DataField="shape" />
                                    <asp:BoundField HeaderText="Carat" DataField="StoneCarate"/>
                                    <asp:BoundField HeaderText="Cut" DataField="cut"/>
                                    <asp:BoundField HeaderText="Color" DataField="color"/>
                                    <asp:BoundField HeaderText="Clarity" DataField="clarity"/>                                  
                                    <asp:BoundField HeaderText="# Stone" DataField="NoOfStone"/>
                                     <asp:BoundField HeaderText="Setting Type" DataField="settingType"/>                               
                               </Columns>
                            </asp:GridView>
                      
          </td>
          </tr>
          </tbody>
          </table>
          </td>
          </tr>

<!----------------------Matching Band Gemestone Information-------------------------------------->
     
  <tr><th colspan="4">Matching Band (Gemstone)</th></tr>
  <tr><td colspan="4">
  <table width="100%" class="table table-bordered table-striped">
  <tbody>
  <tr><td><b>Category :</b>
  <asp:Label ID="Label3" runat="server" Text="Gemestone"></asp:Label></td></tr>
         
     <tr><td><b>Min. Ct. Range :</b>
         <asp:Label ID="lblMinGemsMatchingBand" runat="server"></asp:Label>
         </td></tr>
      <tr><td><b>Max. Ct. Range :</b>
          <asp:Label ID="lblMaxGemsMatchingBand" runat="server"></asp:Label>
          </td></tr>
          <tr>
          <td>
          <b>Available Shape</b><br />
           <asp:BulletedList ID="bltMatchingBandGemsstone" runat="server"></asp:BulletedList>
          </td>
          </tr>
               <!-- Load stone shape for Matching Band diamond-->    
          <tr>
          <td>
          <asp:GridView ID="gvMatchingBandGemsStoneShape" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped"
                Width="100%" 
               GridLines="None" CellPadding="0"
               
    ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                    <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Available Shape">
                    <ItemTemplate>
                    <asp:Label ID="lblSideStoneShape" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                   <asp:HiddenField ID="hdnSideStoneShapeID" runat="server" Value='<%# Eval("AutoID") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
            </asp:GridView> 
            
 <asp:GridView ID="gvMatchingBandGemstone_sidestone" runat="server" AutoGenerateColumns="False" 
                                Width="100%" ShowHeaderWhenEmpty="True" OnRowDataBound="dgvMatchingBand_Gems_rowDataBound" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="hdnSideStoneID" runat="server" Value='<%# Eval("ProductSideStoneId") %>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>                                 
                                    <asp:BoundField HeaderText="Shape" DataField="shape" />
                                    <asp:BoundField HeaderText="Carat" DataField="StoneCarate"/>
                                    <asp:BoundField HeaderText="Cut" DataField="cut"/>
                                    <asp:BoundField HeaderText="Color" DataField="color"/>
                                    <asp:BoundField HeaderText="Clarity" DataField="clarity"/>                                 
                                    <asp:BoundField HeaderText="# Stone" DataField="NoOfStone"/>
                                     <asp:BoundField HeaderText="Setting Type" DataField="settingType"/> 
                                

                                 <asp:TemplateField HeaderText="Customize">
                                     <ItemTemplate>
                                    <asp:HiddenField ID="hdnCustomize" runat="server" Value='<%# Eval("IsCustomize") %>' />
                                    <asp:Label ID="lblCustomize" runat="server"></asp:Label>
                                     </ItemTemplate>                                                                
                                     </asp:TemplateField>  
                                       <asp:TemplateField HeaderText="Type">
                                     <ItemTemplate>  
                                     <asp:GridView ID="lstMatchingBandGems" runat="server" AutoGenerateColumns="False" 
                                Width="100%" ShowHeaderWhenEmpty="True">
                                <Columns>
                                   <asp:BoundField HeaderText="Color" DataField="StoneColor" />
                                    <asp:BoundField HeaderText="Type" DataField="StoneType"/>
                                    <asp:BoundField HeaderText="Price" DataField="StonePrice"/>
                                </Columns>
                                </asp:GridView>                                       
                                    
                                     </ItemTemplate>                                                                
                                     </asp:TemplateField>  
                                     
                                                               
                               </Columns>
                            </asp:GridView>
                      
          </td>
          </tr>
          </tbody>
          
          </table>
  </td>
  </tr>

   </table>
   
    </form>
</body>
</html>
