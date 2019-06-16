
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Metal/AddMetalType.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    var img_link = '';

    jQuery("#tableMetalType").jqGrid({
        height:'auto',
        datatype: "local",
        colNames: ['Metal Weight','Metal Name','Price','Image','Status','Edit', 'Delete'],
        colModel: [
   		{ name: 'MetalWeight', index: 'MetalWeight', width: 50 },
        { name: 'MetalName', index: 'MetalName', width: 50 },
   		{ name: 'MetalPrice', index: 'MetalPrice', width: 20 },
        { name: 'MetalImage', index: 'MetalImage', width: 36 },
        { name: 'Status', index: 'Status', width: 36 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableMetalType").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Metal/AddMetalType.aspx?id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteMetalType(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                img_link = "<a href='/Master/Metal/AddMetalType.aspx?id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                jQuery("#tableMetalType").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableMetalType").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadMetalTypeGrid() {

    EJewel.AdminView.Services.AdminServices.GetMetalTypeList(
    function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableMetalType").jqGrid('addRowData', value.MetalTypeId, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteMetalType(metaltypeid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new metaltypemodel(metaltypeid);
        EJewel.AdminView.Services.AdminServices.DeleteMetalType(entityObject, function (result) {
            displayMsg('S', "Metal Type Deleted Successfully");
            $("#tableMetalType").empty();
            loadMetalTypeGrid();
        },
             onServiceError);
    }

}
function metaltypemodel(metaltypeid) {
    this.MetalTypeId = metaltypeid;
    this.Status = false;
}

loadMetalTypeGrid();

