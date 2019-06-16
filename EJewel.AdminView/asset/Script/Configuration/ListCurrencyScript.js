
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Configuration/Currency/ManageCurrency.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableCurrency").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Title','Code','Symbol','Value','Edit','Delete'],
        colModel: [
   		{ name: 'Title', index: 'id', width: 50 },
        { name: 'Code', index: 'invdate', width: 50 },
        { name: 'Symbol', index: 'invdate', width: 50 },
        { name: 'Value', index: 'invdate', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Currency',

        gridComplete: function () {
            var ids = jQuery("#tableCurrency").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Configuration/Currency/ManageCurrency.aspx?eid=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteCurrency(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableCurrency").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableCurrency").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadCurrencyGrid() {
    EJewel.AdminView.Services.AdminServices.GetCurrency(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCurrency").jqGrid('addRowData', value.CurrencyID, value);
                 });
             }, onServiceError);
}
function onServiceError() {

}

//function used for delete category from grid
function deleteCurrency(currencyid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        alert('sumit');
        var entityObject = new currencymodel(currencyid);     
        EJewel.AdminView.Services.AdminServices.DeleteCurrency(entityObject, function (result) {
            displayMsg('S', "Currency Deleted Successfully");
            $("#tableCurrency").empty();
            loadCurrencyGrid();
        },
             onServiceError);
    }

}
function currencymodel(currencyid) {
    this.CurrencyID = currencyid;
    this.Status = false;
}
loadCurrencyGrid();

