
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Payment/AddTax.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableTax").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Tax Class','Tax Percent','Edit', 'Delete'],
        colModel: [
   		{ name: 'TaxClass', index: 'id', width: 50 },
   		{ name: 'TaxPercent', index: 'invdate', width: 20 },       
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Tax',

        gridComplete: function () {
            var ids = jQuery("#tableTax").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Payment/AddTax.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteTax(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableTax").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableTax").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadTaxGrid() {

    EJewel.AdminView.Services.AdminServices.GetTax(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableTax").jqGrid('addRowData', value.TaxID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete tax from grid
function deleteTax(taxid) {
    try {
        if (confirm('Are you sure, you want to delete this record ?')) {
         var entityObject = new taxmodel(taxid);
         EJewel.AdminView.Services.AdminServices.DeleteTax(entityObject, function (result) {
                displayMsg('S', "Tax Deleted Successfully");
                $("#tableTax").empty();
                loadTaxGrid();
            },
             onServiceError);
        }
    }
    catch (e) {
    }
}
function taxmodel(taxid) {
    this.TaxID = taxid;
    this.Status = false;
}
loadTaxGrid();

