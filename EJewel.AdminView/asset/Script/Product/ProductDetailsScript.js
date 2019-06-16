/*
Partha Ranjan
@ 19-01-2013
This file manage all basic details of the product
This is for page 1 for product
*/
function fill_product_category(ddlProduct) {
    EJewel.AdminView.Services.AdminServices.GetProductCategoryList(
             function (result) {
                 //add default items
                 fillDropDown(ddlProduct, '0', '--Select--');
                 $.each(result, function (key, value) {
                     //add item in categort drop down
                     fillDropDown(ddlProduct, value.CategoryID, value.CategoryName);
                 });
             }, onServiceError);
         }
         /*
            Partha Ranjan
            @ 19-01-2013
            Through the server error
         */
         function onServiceError(result) {
             hide_seek('loader', false);
             displayMsg('E', result._message);
             pageScroll('loader');
         }
         /*
         Partha Ranjan
         @ 19-01-2013
         This function store the product details
         */
         function save_update_product_details() {
             //get value from the product details
             var pID = parseInt($('#hdnID').val());
             var cat = parseInt($('#ddlProductCategory').val());
             var sku = $('#txtSKU').val();
             var title = $('#txtTitle').val();
             var desc = $('#txtDesc').val();
             var pageTitle = $('#txtPageTitle').val();
             var metakeyword = $('#txtMetaKeyword').val();
             var metadesc = $('#txtMetaDesc').val();
             //validation goes here
             var model = new ProductDetailsModel(pID,cat,sku, title, desc, pageTitle, metakeyword, metadesc);
             //do the save update process
             EJewel.AdminView.Services.AdminServices.SaveUpdateProductDetails(model,
             function (result) {
                 if (pID == 0) {
                     //for save
                     displayMsg('S', 'Product Details Save Successfully');
                     //redirect to the metal page
                     location.href = "/Product/ProductMetal.aspx?id=" + result.ProductID;
                 }
                 else {
                     //for update
                 }
             }, onServiceError);
         }
         /*
         Partha Ranjan
         @ 19-01-2013
         This create the product details model
         */
         function ProductDetailsModel(productID, categoryID, sku, productTitle, productDescripation, pageTitle, metaKeyword, metaDescripation) {
             this.ProductID = productID;
             this.CategoryID = categoryID;
             this.SKU = sku;
             this.ProductTitle = productTitle;
             this.ProductDescripation = productDescripation;
             this.PageTitle = pageTitle;
             this.MetaKeyword = metaKeyword;
             this.MetaDescripation = metaDescripation;
         }
         /*
         Partha Ranjan
         @ 19-01-2013
         This script manage the product whole details
         */
         function get_product_details(product_id) {
             var model = null;
             try {
                 product_id = parseInt(product_id);
                 if (product_id > 0) {
                     EJewel.AdminView.Services.AdminServices.GetProductDetails(product_id,
             function (data) {
                 //get the details of the product
                model = new ProductDetailsModel(data.ProductID, data.CategoryID, data.SKU, data.ProductTitle, data.ProductDescripation, data.PageTitle, data.MetaKeyword, data.MetaDescripation);
             }, onServiceError);
                 }
             }
             catch (e) {
                 alert(e);
             }
             return model;
         }