
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Configuration/Store/MultiStore.aspx');
});

function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableMultiStore").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Store Name', 'Store Url','Edit', 'Delete'],
        colModel: [
   		{ name: 'StoreName', index: 'id', width: 50 },
        { name: 'StoreUrl', index: 'invdate', width: 50 },       
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Store',

        gridComplete: function () {
            var ids = jQuery("#tableMultiStore").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Configuration/Store/MultiStore.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteStore(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableMultiStore").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableMultiStore").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadGrid() 
{
    EJewel.AdminView.Services.AdminServices.GetMultiStore(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableMultiStore").jqGrid('addRowData', value.StoreID, value);
                 });
             }, onServiceError);
}
function onServiceError() {

}

//function used for delete category from grid
function deleteStore(id) {
    if (confirm('Are you sure, you want to delete this record ?')) {      
        var entityObject = new model(id);
        EJewel.AdminView.Services.AdminServices.DeleteMultiStore(entityObject, function (result) {
            displayMsg('S', "Store Deleted Successfully");
            $("#tableMultiStore").empty();
            loadGrid();
        },
             onServiceError);
    }

}
function model(id) {
    this.StoreID = id;    
}
loadGrid();

