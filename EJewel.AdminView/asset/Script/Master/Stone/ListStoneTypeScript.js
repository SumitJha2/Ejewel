
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Stone/AddStoneType.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableStoneType").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Name', 'Category', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'StoneTypeName', index: 'id', width: 50 },
   		{ name: 'StoneCategoryName', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Stone Type',

        gridComplete: function () {
            var ids = jQuery("#tableStoneType").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Stone/AddStoneType.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteStoneType(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableStoneType").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableStoneType").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadStoneTypeGrid() {

    EJewel.AdminView.Services.AdminServices.GetStoneType(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneType").jqGrid('addRowData', value.StoneTypeID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteStoneType(stoneclid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new stonetypemodel(stoneclid);
        EJewel.AdminView.Services.AdminServices.DeleteStoneType(entityObject, function (result) {
            displayMsg('S', "Stone Type Deleted Successfully");
            $("#tableStoneType").empty();
            loadStoneTypeGrid();
        },
             onServiceError);
    }

}
function stonetypemodel(stoneclid) {
    this.StoneTypeID = stoneclid;
    this.Status = false;
}

loadStoneTypeGrid();

