
$(document).ready(function () {
    initGrid();
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tblRingSize").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Sub Category', 'Ring Size', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'SubCategory', index: 'SubCategory', width: 50 },
        { name: 'RingSize', index: 'RingSize', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        autowidth: true,
        viewrecords: true,
        gridComplete: function () {
            var ids = jQuery("#tblRingSize").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Setting/RingSizeManagement.aspx?id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteRingSize(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tblRingSize").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tblRingSize").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadRingSizeGrid() {
    EJewel.AdminView.Services.AdminServices.GetRingSizeList(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tblRingSize").jqGrid('addRowData', value.RingSizeId, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteRingSize(ringsizeid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        EJewel.AdminView.Services.AdminServices.DeleteRingSize(ringsizeid, function (result) {
            displayMsg('S', "Ring Size Deleted Successfully.");
            $("#tblRingSize").empty();
            loadRingSizeGrid();
        },
             onServiceError);
    }

}
loadRingSizeGrid();

