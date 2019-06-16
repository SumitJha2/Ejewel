$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Payment/AddPaymentVia.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tablePaymentVia").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Name', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'PaymentOption', index: 'id', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Payment Via',
        gridComplete: function () {
            var ids = jQuery("#tablePaymentVia").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Payment/AddPaymentVia.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deletePaymentVia(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tablePaymentVia").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tablePaymentVia").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadPaymentViaGrid() {

    EJewel.AdminView.Services.AdminServices.GetPaymentVia(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tablePaymentVia").jqGrid('addRowData', value.PaymentID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deletePaymentVia(paymentid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new paymentmodel(paymentid);
        EJewel.AdminView.Services.AdminServices.DeletePaymentVia(entityObject, function (result) {
            displayMsg('S', "Payment Via  Deleted Successfully");
            $("#tablePaymentVia").empty();
            loadPaymentViaGrid();
        },
             onServiceError);
    }

}
function paymentmodel(paymentid) {
    this.PaymentID = paymentid;
    this.Status = false;
}

loadPaymentViaGrid();

