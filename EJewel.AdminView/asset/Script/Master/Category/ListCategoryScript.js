
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Category/AddCategory.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tableCategory").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['SubCategory', 'Category', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'SubCategoryName', index: 'SubCategoryName' },
        { name: 'CategoryName', index: 'CategoryName' },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableCategory").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Category/AddCategory.aspx?ID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteCategory(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableCategory").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableCategory").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadCategoryGrid() {

    EJewel.AdminView.Services.AdminServices.GetSubCategoryList(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCategory").jqGrid('addRowData', value.SubCategoryId, value);
                 });
                 //                 $('#tableCategory tr').each(function () {
                 //                     $(this).find('td:eq(3)').hide();
                 //                     $('#tableCategory tr').find('th:eq(3)').hide();
                 //                 });
             }, onServiceError);
}




function onServiceError() {
}
//function used for delete category from grid
function deleteCategory(catid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new categorymodel(catid);
        EJewel.AdminView.Services.AdminServices.DeleteCategory(catid, function (result) {
            displayMsg('S', "Category Deleted Successfully");
            $("#tableCategory").empty();
            loadCategoryGrid();
        },
             onServiceError);
    }
}
function categorymodel(catid) {
    this.SubCategoryId = catid;
    this.Status = false;
}
loadCategoryGrid();

