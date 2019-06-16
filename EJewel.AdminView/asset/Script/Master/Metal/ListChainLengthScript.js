
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Metal/AddChainLength.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableChainLength").jqGrid({
        datatype: "local",
        colNames: ['Chain Length', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'ChainLength', index: 'id', width: 50 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableChainLength").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Metal/AddChainLength.aspx?eid=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteChainLength(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableChainLength").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableChainLength").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadChainLengthGrid() {
    EJewel.AdminView.Services.AdminServices.GetChainLength(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableChainLength").jqGrid('addRowData', value.ChainLengthID, value);
                 });
             }, onServiceError);
}
function onServiceError() {

}
//function used for delete category from grid
function deleteChainLength(lengthid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new chainLengthmodel(lengthid);
        EJewel.AdminView.Services.AdminServices.DeleteChainLength(entityObject, function (result) {
            displayMsg('S', "Chain Length Deleted Successfully");
            $("#tableChainLength").empty();
            loadChainLengthGrid();
        },
             onServiceError);
    }

}
function chainLengthmodel(lengthid) {
    this.ChainLengthID = lengthid;
    this.Status = false;
}
loadChainLengthGrid();

