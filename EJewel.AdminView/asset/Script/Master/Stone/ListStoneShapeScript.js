
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Stone/AddStoneShape.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableStoneShape").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Shape', 'Category ', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'StoneShapeName', index: 'id', width: 50 },
   		{ name: 'StoneCategoryName', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Stone Shape',

        gridComplete: function () {
            var ids = jQuery("#tableStoneShape").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Stone/AddStoneShape.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteStoneShape(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableStoneShape").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableStoneShape").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadStoneShapeGrid() {

    EJewel.AdminView.Services.AdminServices.GetStoneShape(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneShape").jqGrid('addRowData', value.StoneShapeID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteStoneShape(stoneclid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new stoneshapemodel(stoneclid);
        EJewel.AdminView.Services.AdminServices.DeleteStoneShape(entityObject, function (result) {
            displayMsg('S', "Stone Shape Deleted Successfully");
            $("#tableStoneShape").empty();
            loadStoneShapeGrid();
        },
             onServiceError);
    }

}
function stoneshapemodel(stoneclid) {
    this.StoneShapeID = stoneclid;
    this.Status = false;
}

loadStoneShapeGrid();

