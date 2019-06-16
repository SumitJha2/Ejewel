
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Payment/AddOrderStatus.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableOrderStatus").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Name','Edit', 'Delete'],
        colModel: [
   		{ name: 'OrderStatusName', index: 'id', width: 50 },   	
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Order Status',

        gridComplete: function () {
            var ids = jQuery("#tableOrderStatus").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Payment/AddOrderStatus.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteOrderStatus(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableOrderStatus").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableOrderStatus").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadOrderStatusGrid() {

    EJewel.AdminView.Services.AdminServices.GetOrderStatus(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableOrderStatus").jqGrid('addRowData', value.OrderStatusID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteOrderStatus(ordid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new orderstatusmodel(ordid);
        EJewel.AdminView.Services.AdminServices.DeleteOrderStatus(entityObject, function (result) {
            displayMsg('S', "Order Status  Deleted Successfully");
            $("#tableOrderStatus").empty();
            loadOrderStatusGrid();
        },
             onServiceError);
    }

}
function orderstatusmodel(orderstatusid) {
    this.OrderStatusID = orderstatusid;
    this.Status = false;
}

loadOrderStatusGrid();

