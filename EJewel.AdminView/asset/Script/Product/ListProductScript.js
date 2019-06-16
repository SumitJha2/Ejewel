$(document).ready(function () {
    initGrid();
});
function initGrid() {

    jQuery("#tableProduct").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Category', 'Sub Category', 'SKU', 'Product Title', 'Price','View', 'Details', 'Metal', 'Setting', 'Center Stone', 'Side Stone', 'Matching Band', 'Chain', 'Image', 'Delete'],
        colModel: [
        { name: 'PrimaryCategoryName', index: 'PrimaryCategoryName', width: 50 },
   		{ name: 'SubCategoryName', index: 'SubCategoryName', width: 50 },
        { name: 'SKU', index: 'SKU', width: 50 },
        { name: 'ProductTitle', index: 'SKU', width: 50 },
        { name: 'ProductDefaultPrice', index: 'ProductDefaultPrice', width: 50 },
        { name: 'view', index: 'SKU', width: 20, align: 'center' },
        { name: 'details', index: 'SKU', width: 20, align: 'center' },
        { name: 'metal', index: 'SKU', width: 20, align: 'center' },
        { name: 'setting', index: 'SKU', width: 20, align: 'center' },
        { name: 'center_stone', index: 'SKU', width: 20, align: 'center' },
        { name: 'side_stone', index: 'SKU', width: 20, align: 'center' },
        { name: 'matching_band', index: 'SKU', width: 20, align: 'center' },
        { name: 'chain', index: 'SKU', width: 20, align: 'center' },
        { name: 'image', index: 'SKU', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'SKU', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        afterInsertRow: function (rowid, rowdata, rowelem) {
            var metal_link = "<a href='/Product/ProductMetal.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var setting_link = "<a href='/Product/ProductSetting.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var center_stone_link = "<a href='/Product/ProductCenterStone.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var side_stone_link = "<a href='/Product/ProductSideStone.aspx?id=" + rowdata.ProductID + "&ref=main&view=default'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var chain_link = "<a href='/Product/ProductChain.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";

            var matching_band_link = "<a href='/Product/ProductSideStone.aspx?id=" + rowdata.ProductID + "&ref=main&view=matching_band'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var image_link = "<a href='/Product/ProductImage.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var details_link = "<a href='/Product/ProductDetails.aspx?id=" + rowdata.ProductID + "&ref=main'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            var delete_link = "<a href=''><img src='/asset/template/images/extra/delete_16.png' /></a>";

            var view_link = "<a href='javascript:void(0)' onclick=\"openWindow('/Product/ProductView.aspx?id=" + rowdata.ProductID + "',600,500)\"><img src='/asset/template/images/extra/search_16.png' /></a>";

            //defaut price pop up 
            $("#tableProduct").jqGrid('setCell', rowid, 'ProductDefaultPrice', '<a href="javascript:void(0)" onclick="showPriceModel(' + rowdata.ProductID + ')">' + rowdata.ProductDefaultPrice + '</a>', '');
            //details
            $("#tableProduct").jqGrid('setCell', rowid, 'details', details_link, '');
            //metal
            $("#tableProduct").jqGrid('setCell', rowid, 'metal', metal_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'setting', setting_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'center_stone', center_stone_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'side_stone', side_stone_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'matching_band', matching_band_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'chain', chain_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'image', image_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'dlt', delete_link, '');
            //
            $("#tableProduct").jqGrid('setCell', rowid, 'view', view_link, '');
        }
    });
}
function loadProductDetails() {
    EJewel.AdminView.Services.AdminServices.GetProductList(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableProduct").jqGrid('addRowData', value.ProductID, value);
                 });
             }, onServiceError);
}
function onServiceError() {

}
//function used for delete category from grid
function deleteProduct(lengthid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new chainLengthmodel(lengthid);
        EJewel.AdminView.Services.AdminServices.DeleteChainLength(entityObject, function (result) {
            displayMsg('S', "Product Deleted Successfully");
            $("#tableProduct").empty();
            loadProductDetails();
        },
             onServiceError);
    }

}
function productmodel(lengthid) {
    this.ProductID = lengthid;
    this.Status = false;
}
loadProductDetails();

