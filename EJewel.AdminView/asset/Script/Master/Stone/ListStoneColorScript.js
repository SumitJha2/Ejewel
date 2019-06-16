$(document).ready(function () {
    initGrid();
    $("#lnkCreateNew").attr('href', '/Master/Stone/AddStoneColor.aspx');

});


function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableStoneColor").jqGrid({
        width: 800,
        height: 300,
        datatype: "local",
        colNames: ['Color ', 'Category ', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'StoneColorName', index: 'id', width: 50 },
   		{ name: 'StoneCategoryName', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Stone Color',

        gridComplete: function () {
            var ids = jQuery("#tableStoneColor").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Stone/AddStoneColor.aspx?EID=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteStoneColor(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableStoneColor").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableStoneColor").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function onServiceError() {
}
function loadStoneColorGrid() {
    EJewel.AdminView.Services.AdminServices.GetStoneColorModel(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneColor").jqGrid('addRowData', value.StoneColorID, value);
                 });
             }, onServiceError);
         }

         function deleteStoneColor(colorid) {
             if (confirm('Are you sure you want to delete this record ?')) {
                 var entityObject = new stonecolormodel(colorid);
                 EJewel.AdminView.Services.AdminServices.DeleteStoneColor(entityObject, function (result) {
                     displayMsg('S', "Stone Color Deleted Successfully");
                     $("#tableStoneColor").empty();
                     loadStoneColorGrid();
                 },
             onServiceError);
             }
         }
     function stonecolormodel(colorid){
     this.Status=false;
     this.StoneColorID=colorid;
     }
      loadStoneColorGrid();
