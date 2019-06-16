<%@ Page Title="Product List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EJewel.AdminView.Product.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
.ui-menu-item
{
 
   list-style-type:none; 
}
.color
{
	background-color:Red !important;
}


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="contentHeader">
    <h1>FD Product Listing</h1>
</div>
<div class="container">
        <div class="grid-24">
      
           <div align="center">
        <table class="table table-bordered table-striped" align="center" style="width:100%;">
       <tr style="height:20px;"><td colspan="9">
       
     <div style="float:left; "> <h4> Narrow Your Search</h4></div>


     <div style="float:right; color:Red;">
     Note (SKU Search): Slowly type the SKU ID and Select it..
     </div>
       </td>
      
       
       </tr>
        <tr>
        <td>Category</td>
        <td>:</td>
        <td>
        <asp:DropDownList ID="ddlCategory" Width="180px" runat="server">    
        </asp:DropDownList>    
        </td>
       <td>Sub Category</td>
        <td >:</td>
        <td>
          <asp:DropDownList ID="ddlSubCategory" Width="180px" runat="server">         
          </asp:DropDownList>
        </td>
        <td><b>SKU</b></td>
        <td>:</td>
        <td>
          <input id="txtSKU" type="text" onkeypress="return clickButton(event,'btnSearch')" />
        </td>
            </tr>

             <tr><td colspan="9">
            <table class="table table-bordered table-striped">
            <tbody>           
              <tr>
              <td><asp:CheckBox ID="chkBestSelling" runat="server" Text="Best Selling" /></td>
           
            <td> <asp:CheckBox ID="chkNewProduct" runat="server" Text=" New Product" />
           </td>
          
               <td><asp:CheckBox ID="chkMensGift" runat="server" Text="Men's Gift" />
           </td>
          
              <td><asp:CheckBox ID="chkWomensGift" runat="server"  Text="Women's Gift" />
            </td>
             
              <td><asp:CheckBox ID="chkChildrensGift" runat="server" Text="Children's Gift" />
           </td>   
            <td><asp:CheckBox ID="chkOthersGift" runat="server" Text="Other Gifts" />
             </td>
                
             <td><asp:CheckBox ID="chkSales" runat="server" Text="Sales" />
            </td>
             <td><asp:CheckBox ID="chkExtraOrdinary" runat="server" Text="Extra Ordinary" /></td>           
            </tr>        
          </tbody>
            </table>
            </td> </tr>
      
        <tr>
        <td align="center" colspan="9"> <input type="button" id="btnSearch" onclick="btnSearch_Click()" class="btn btn-small btn-green" value="Search" />
        <input type="button" id="btnShowAll" onclick="btnShowAll_Click()" class="btn btn-small btn-green" value="Show All" />
        <input type="button" value="Create New" onclick="location.href='/Product/ProductDetails.aspx'" class="btn btn-small btn-green" />
         <input type="button" value="Export" onclick="location.href='/Product/ProductExport.aspx'" class="btn btn-small btn-green" />
            </td>
            </tr>
        </table>
        </div>

        <br /> 
        <br />
        <table class="table table-bordered table-striped" style="width:100%">
        <thead>
        <tr>
            <th>Sl.</th>
            <th>SKU</th>
            <th>Product Title</th>
            <th>Price</th>
            <th>Sub Category</th>
            <th>Category</th>
            <th>Info</th>
            <th>Metal</th>
            <th>Center Stone</th>
            <th>Side Stone</th>
            <th>Matching Band</th>
            <th>Chain</th>
            <th>Image/Video</th>
            <th>Details</th>
            <th>Setting</th>
            <th>Delete</th>
        </tr>
        </thead>
        <tbody id="tblProductList">
        </tbody>
        </table>
        <!--Pagination-->
     <%--   <div class="pagination" id="pagination" style="float:right"></div>--%>
       <div id="Pagination" style="float:right;" class="pagination"></div>
        </div>
        </div>
        <!--Load data-->
        <script type="text/javascript">
            var total_record=<%= _totalRecord %>;
            var per_page_value =10;
            var current_page_index = 0;
            var categoryId=0;
            var subCategoryId=0;
             var sku="";
             var chkbestselling=false;
            var chkNewProduct=false;
            var chkMensGift=false;
            var chkWomensGift=false;
            var chkChildrensGift=false;
            var chkOthersGift=false;
            var chkSales=false;
            var chkExtraOrdinary=false;

               var FIRST_TIME_LOAD = true;

            $(document).ready(function () {
               load_data(current_page_index);
               loadSkuByName();
               $("#<%=ddlSubCategory.ClientID %>").append("<option value='0'>--Sub Category--</option>");
               $("#<%=ddlCategory.ClientID %>").change(function(){
               loadSubcategoryFromCategory();
               });
            });

            //load data
            function load_data(arg_current_page_index) {
                show_message_popup('Please wait...', 'message_loading');
                //clear rows
                $("#tblProductList").empty();
                //load the data
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetProductList",
                        data:JSON.stringify({productid:0,currentPageIndex:arg_current_page_index,perPageSize:per_page_value,categoryId:categoryId,subCategoryId:subCategoryId,sku:sku,bestselling:chkbestselling,newproduct:chkNewProduct,mengift:chkMensGift,womengift:chkWomensGift,childgift:chkChildrensGift,othergift:chkOthersGift,sale:chkSales,IsExtraOrdinary:chkExtraOrdinary}),
                        dataType: "json",
                        success: function (successData) {
                            //for serial no
                            var counter = (arg_current_page_index*per_page_value);
                            $.each(successData.d, function (key, value) {
                                counter++;
                                //create chain_16.png detail_16.png
                                var row = create_row();
                                create_cell(row, counter, [['align', 'center']]);
                                create_cell(row, value.SKU);
                                var product_title=value.ProductTitle;
                                product_title=(product_title.length>40)?product_title.substring(0,40)+'...':product_title;
                                //
                                create_cell(row, '<span title="'+value.ProductTitle+'">'+product_title+'</span>');
                                //price
                                create_cell(row,'<a   href="javascript:void(0)" onclick="show_price_dialog('+ value.ProductID +')">$'+value.ProductDefaultPrice+'</a>');
                                //category and sub category
                                create_cell(row, value.SubCategoryName);
                                create_cell(row, value.PrimaryCategoryName);
                                //details
                                create_cell(row, '<a href="/Product/ProductDetails.aspx?id=' + value.ProductID + '"><img src="/assets/themes/admin/images/icon/info_16.png" /></a>', [['align', 'center']]);
                                //metal
                                 create_cell(row, '<a href="/Product/ProductMetal.aspx?id=' + value.ProductID + '"><img src="/assets/themes/admin/images/icon/product/circle_16.png" /></a>', [['align', 'center']]);
                                //center stone
                                create_cell(row, '<a href="/Product/ProductCenterStone.aspx?id=' + value.ProductID + '"><img src="/assets/themes/admin/images/icon/product/circle_16.png" /></a>', [['align', 'center']]);
                                //side stone
                                create_cell(row, '<a href="/Product/ProductSideStone.aspx?id=' + value.ProductID + '&stone_category=1&view=side_stone" ><img src="/assets/themes/admin/images/icon/product/circle_16.png" /></a>', [['align', 'center']]);
                                //matching band
                                create_cell(row, '<a href="/Product/ProductSideStone.aspx?id=' + value.ProductID + '&stone_category=1&view=matching_band" ><img src="/assets/themes/admin/images/icon/product/circle_16.png" /></a>', [['align', 'center']]);
                                  //chain
                                 create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Product/ProductChain.aspx?id=' + value.ProductID + '\',500,500,\'window_chain\')"><img src="/assets/themes/admin/images/icon/product/circle_16.png" /></a>', [['align', 'center']]);
                                //images
                                create_cell(row, '<a href="javascript:void(0)" title="Prodocut Image" onclick="popupwindow(\'/Product/ProductImage.aspx?id=' + value.ProductID + '\',700,500,\'window_image\')"><img src="/assets/themes/admin/images/icon/product/image_16.png" /></a> <a  href="javascript:void(0)" title="Prodocut Video" onclick="popupwindow(\'/Product/ProductVideo.aspx?id=' + value.ProductID + '\',700,500,\'window_video\')"><img src="/assets/themes/admin/images/icon/product/video_16.png" /></a>', [['align', 'center']]);
                                 //details
                                create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Product/ProductView.aspx?id=' + value.ProductID + '\',700,500,\'window_product_view\')"><img src="/assets/themes/admin/images/icon/product/detail_16.png" /></a>', [['align', 'center']]);
                                //setting
                            create_cell(row, '<a href="javascript:void(0)" onclick="popupwindow(\'/Product/ProductSetting.aspx?id=' + value.ProductID + '\',500,500,\'window_setting\')"><img src="/assets/themes/admin/images/icon/product/setting_16.png" /></a>', [['align', 'center']]);
                                //delete
                                create_cell(row, '<a href="#"><img src="/assets/themes/admin/images/icon/delete_16.png" /></a>', [['align', 'center']]);
                                //add data
                                add_row('tblProductList', row);
                            });
                            hide_message_popup();
                            if(counter>0)
                            {
                                    //increate current page index
                                    //current_page_index=arg_current_page_index;
                                    //show pagination
                                   // create_pagination('pagination',total_record,arg_current_page_index,per_page_value,5,load_data);
                                 if(FIRST_TIME_LOAD==true)
                                   {
                                        $("#Pagination").pagination(total_record, getPagingOption());
                                        FIRST_TIME_LOAD=false;
                                   }

                            }
                            else{
                                var row = create_row();
                                create_cell(row, '<span class="small_error">No record found.</span>',[['colspan','15'],['align','center']]);
                                add_row('tblProductList', row);
                            }
                           
                        },
                        error: function (errorData) {
                            var result = JSON.parse(errorData.responseText);
                            show_message_popup(result.Message, 'message_error');
                        }
                    });
                }
                catch (e) {
                    alert(e);
                }
            }

            function show_price_dialog(productId)
            {
                try
                {
                    $("#dialog_price").load("/Product/ProductPrice.aspx?id="+productId).dialog({bgiframe: true,width:800,modal:true});
                }
                catch(e)
                {
                    alert(e);
                }
            }
              // load sub category
            function loadSkuByName() {             
                $("#txtSKU").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/AdminServices.asmx/GetSkuByName",
                            data: "{'name': '" + request.term + "'}",
                            dataType: "json",
                            success: function (data) {                
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item
                                                              
                                    }
                                }))
                            },
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) { 
                   
                    },
                    minLength:3
                });
            }

           function btnSearch_Click()
            {
              FIRST_TIME_LOAD=true;
              categoryId=parseInt($("#<%=ddlCategory.ClientID %>").val());            
              subCategoryId=parseInt($("#<%=ddlSubCategory.ClientID %>").val());             
              sku=$("#txtSKU").val(); 

              //used for productsettingsearching
              chkbestselling=document.getElementById("<%=chkBestSelling.ClientID %>").checked==true?true:false;          
              chkNewProduct=document.getElementById("<%=chkNewProduct.ClientID %>").checked==true?true:false;
              chkMensGift=document.getElementById("<%=chkMensGift.ClientID %>").checked==true?true:false;
              chkWomensGift=document.getElementById("<%=chkWomensGift.ClientID %>").checked==true?true:false;
              chkChildrensGift=document.getElementById("<%=chkChildrensGift.ClientID %>").checked==true?true:false;
              chkOthersGift=document.getElementById("<%=chkOthersGift.ClientID %>").checked==true?true:false;
              chkSales=document.getElementById("<%=chkSales.ClientID %>").checked==true?true:false;
              chkExtraOrdinary=document.getElementById("<%=chkExtraOrdinary.ClientID %>").checked==true?true:false;
             load_data(0);
            }

            function btnShowAll_Click()
            {
              FIRST_TIME_LOAD=true;
            categoryId=0;
            subCategoryId=0;
            sku="";
            chkbestselling=false;
            chkNewProduct=false;
            chkMensGift=false;
            chkWomensGift=false;
            chkChildrensGift=false;
            chkOthersGift=false;
             chkSales=false;
           chkExtraOrdinary=false;
          
            load_data(0);
            document.getElementById("txtSKU").value="";
            document.getElementById("<%=ddlSubCategory.ClientID %>").selectedIndex=0;
            document.getElementById("<%=ddlCategory.ClientID %>").selectedIndex=0;
            }

            function loadSubcategoryFromCategory(){
      //clear rows
                $("#<%=ddlSubCategory.ClientID %>").empty();
                 $("#<%=ddlSubCategory.ClientID %>").append("<option value='0'>--SubCategory--</option>");
                //load the data
                var categoryID=parseInt($("#<%=ddlCategory.ClientID %>").val());
                try {
                    $.ajax({
                        type: "POST",
                        async: true,
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/AdminServices.asmx/GetSubCategoryListFromCategory",
                        data:JSON.stringify({categoryID:categoryID}),
                        dataType: "json",
                        success: function (successData) {                        
                        $.each(successData.d,function(key,value){
                        $("#<%=ddlSubCategory.ClientID %>").append("<option value='"+value.SubCategoryId+"'>"+value.SubCategoryName+"</option>");
                        });
                        },
                        Error:function(errorData){
                        }
                        });
                     }
                 catch(e)
                 {
                  }
          }

           function clickButton(e, buttonid) {           
                 var evt = e ? e : window.event;                  
                 var bt = document.getElementById(buttonid);
                 if (bt) {
                
                     if (evt.keyCode == 13) {
                         bt.click();
                         return false;
                     }
                 }
             }

             
             //should be define
        function getPagingOption() {
    var opt = { callback: pagingCallback };
    opt['items_per_page'] = per_page_value;
    opt['num_display_entries'] = 5;
    opt['num_edge_entries'] = 2;
    return opt;
    }
        //paging call back
        function pagingCallback(page_index, jq) {
        // Get number of elements per pagionation page from form
        FIRST_TIME_LOAD=false;
        load_data(page_index);
    }
        </script>
        <!--Dialog-->
        <div id="dialog_price" title="Product Price Details"></div>
</asp:Content>
