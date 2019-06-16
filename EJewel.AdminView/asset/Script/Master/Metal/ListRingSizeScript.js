
$(document).ready(function () {
    initGrid();
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableRingSize").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Category', 'Metal','Size','Price','Is Default','Edit', 'Delete'],
        colModel: [
   		{ name: 'CategoryName', index: 'id', width: 50 },
   		{ name: 'MetalName', index: 'invdate', width: 20 },
        { name: 'Size', index: 'invdate', width: 20 },
        { name: 'Price', index: 'invdate', width: 20 },
        { name: 'RingDefault', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableRingSize").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Metal/AddRingSize.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteRingSize(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableRingSize").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableRingSize").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadRingSizeGrid() {

    EJewel.AdminView.Services.AdminServices.GetRingSize(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableRingSize").jqGrid('addRowData', value.RingSizeID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteRingSize(ringsizeid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new Ringsizemodel(ringsizeid);
        EJewel.AdminView.Services.AdminServices.DeleteRingSize(entityObject, function (result) {
            displayMsg('S', "Ring Size Deleted Successfully");
            $("#tableRingSize").empty();
            loadRingSizeGrid();
        },
             onServiceError);
    }

}
function Ringsizemodel(ringsizeid) {
    this.RingSizeID = ringsizeid;
    this.Status = false;
}

loadRingSizeGrid();

