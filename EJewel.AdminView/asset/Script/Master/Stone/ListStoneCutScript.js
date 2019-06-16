$(document).ready(function () {
    initGrid();
    $("#lnkCreateNew").attr('href', '/Master/Stone/AddStoneCut.aspx');

});

function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableStoneCut").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Cut ', 'Category ', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'StoneCutName', index: 'id', width: 50 },
   		{ name: 'StoneCategoryName', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Stone Cut',

        gridComplete: function () {
            var ids = jQuery("#tableStoneCut").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Stone/AddStoneCut.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='DeleteStoneCut(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableStoneCut").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableStoneCut").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function onServiceError() {
}
function loadStoneCutGrid() {
    EJewel.AdminView.Services.AdminServices.GetStoneCut(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneCut").jqGrid('addRowData', value.StoneCutID, value);
                 });
             }, onServiceError);
}

function DeleteStoneCut(cutid) {
    if (confirm('Are you sure you want to delete this record ?')){
        var entityObject = new stonecutmodel(cutid);
        EJewel.AdminView.Services.AdminServices.DeleteStoneCut(entityObject, function (result) {
            displayMsg('S', "Stone Cut Deleted Successfully");
            $("#tableStoneCut").empty();
            loadStoneCutGrid();
        },
             onServiceError);
    }
}
function stonecutmodel(cutid) {
    this.Status = false;
    this.StoneCutID = cutid;
}
loadStoneCutGrid();
