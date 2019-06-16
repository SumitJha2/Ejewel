
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Payment/AddPaymentStatus.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tablePaymentStatus").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Name', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'PaymentStatus', index: 'id', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Payment Status',

        gridComplete: function () {
            var ids = jQuery("#tablePaymentStatus").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Payment/AddPaymentStatus.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deletePaymentStatus(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tablePaymentStatus").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tablePaymentStatus").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadPaymentStatusGrid() {

    EJewel.AdminView.Services.AdminServices.GetPaymentStatus(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tablePaymentStatus").jqGrid('addRowData', value.PaymentStatusID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deletePaymentStatus(paymentstatusid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new paymentstatusmodel(paymentstatusid);
        EJewel.AdminView.Services.AdminServices.DeletePaymentStatus(entityObject, function (result) {
            displayMsg('S', "Payment Status  Deleted Successfully");
            $("#tablePaymentStatus").empty();
            loadPaymentStatusGrid();
        },
             onServiceError);
    }
}
function paymentstatusmodel(paymentstatusid) {
    this.PaymentStatusID = paymentstatusid;
    this.Status = false;
}
loadPaymentStatusGrid();

