
$(document).ready(function () {
    initGrid();   
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tblCategorySettingType").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Stone Category', 'Setting Type','Price','Edit','Delete'],
        colModel: [
   		{ name: 'StoneCategoryTypeName', index: 'StoneCategoryTypeName', width: 50 },
        { name: 'SettingTypeName', index: 'SettingTypeName', width: 50 },
         { name: 'Price', index: 'Price', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        autowidth: true,
        viewrecords: true,
        gridComplete: function () {
            var ids = jQuery("#tblCategorySettingType").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Setting/StoneCategorySettingType.aspx?id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteCategorySettingType(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tblCategorySettingType").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tblCategorySettingType").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadCategorySettingTypeGrid() {
    EJewel.AdminView.Services.AdminServices.StoneSettingTypeList(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tblCategorySettingType").jqGrid('addRowData', value.StoneCategorySettingTypeId, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteCategorySettingType(categorysettingtype) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        EJewel.AdminView.Services.AdminServices.DeleteStoneSettingType(categorysettingtype, function (result) {
            displayMsg('S', "Category Setting Type Deleted Successfully.");
            $("#tblCategorySettingType").empty();
            loadCategorySettingTypeGrid();
        },
             onServiceError);
    }

}
loadCategorySettingTypeGrid();

