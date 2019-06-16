
$(document).ready(function () {
    initGrid();
  $('#lnkCreateNew').attr('href', '/Master/Stone/AddStoneClarity.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableStoneClarity").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Clarity Name', 'Category Name', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'StoneClarityName', index: 'id', width: 50 },
   		{ name: 'StoneCategoryName', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Stone Clarity', 

        gridComplete: function () {
            var ids = jQuery("#tableStoneClarity").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Stone/AddStoneClarity.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteStoneClarity(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableStoneClarity").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableStoneClarity").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadStoneClarityGrid() {

    EJewel.AdminView.Services.AdminServices.GetStoneClarityModel(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneClarity").jqGrid('addRowData', value.StoneClarityID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteStoneClarity(stoneclid) {
 if (confirm('Are you sure, you want to delete this record ?'))
{
    var entityObject = new stoneclaritymodel(stoneclid);
    EJewel.AdminView.Services.AdminServices.DeleteStoneClarity(entityObject, function (result) {
        displayMsg('S', "Stone Clarity Deleted Successfully");
        $("#tableStoneClarity").empty();
        loadStoneClarityGrid();
    },
             onServiceError);
     }

}
function stoneclaritymodel(stoneclid) {
    this.StoneClarityID = stoneclid;
    this.Status = false;
}

loadStoneClarityGrid();

