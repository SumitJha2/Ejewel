
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Payment/AddShipmentMethod.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableShipmentMethod").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Name','Price','Edit', 'Delete'],
        colModel: [
   		{ name: 'ShipmentName', index: 'id', width: 50 },
        { name: 'Price', index: 'inv', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Shipment Methods',

        gridComplete: function () {
            var ids = jQuery("#tableShipmentMethod").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Payment/AddShipmentMethod.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteShipmentMethod(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableShipmentMethod").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableShipmentMethod").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadShipmentMethodGrid() {

    EJewel.AdminView.Services.AdminServices.GetShipmentMethod(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableShipmentMethod").jqGrid('addRowData', value.ShipmentID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteShipmentMethod(shipmentid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new shipmentmethodmodel(shipmentid);
        EJewel.AdminView.Services.AdminServices.DeleteShipmentMethod(entityObject, function (result) {
            displayMsg('S', "Shipment Method  Deleted Successfully");
            $("#tableShipmentMethod").empty();
            loadShipmentMethodGrid();
        },
             onServiceError);
    }
}
function shipmentmethodmodel(shipmentid) {
    this.ShipmentID = shipmentid;
    this.Status = false;
}
loadShipmentMethodGrid();

