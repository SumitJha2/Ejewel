var PAGE_NAME = '';
var count = 0;
var qs = querystring("view");
if (qs.length > 0) {
    PAGE_NAME = qs[0];
}
initGrid();
$(document).ready(function (){
    initGrid();
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tblSetterPrice").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Price ','SubCategory', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'Price', index: 'id', width: 50 },
   		{ name: 'SubCategory', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tblSetterPrice").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Setting/PriceManagement.aspx?view=" + PAGE_NAME + "&id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deletePrice(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tblSetterPrice").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tblSetterPrice").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }

        }
    });
}
function onServiceError() {
}
function loadPriceManagementList() {
    EJewel.AdminView.Services.AdminServices.GetSettingPriceModel(0,PAGE_NAME,
             function (result) {
                 //jQuery("#tblSingleField").jqGrid('addRowData', 0, '');
                 $.each(result, function (key, value) {
                     jQuery("#tblSetterPrice").jqGrid('addRowData', value.AutoID, value);
                 });
             }, onServiceError);
}

function deletePrice(id) {
    if (confirm('Are you sure you want to delete this record ?')) {
        EJewel.AdminView.Services.AdminServices.Delete_Setter_Setting_Price(id, PAGE_NAME, function (result) {
            $("#tblSetterPrice").empty();
            loadPriceManagementList();
        },
             onServiceError);
    }
}
//alert(PAGE_NAME);
loadPriceManagementList();
