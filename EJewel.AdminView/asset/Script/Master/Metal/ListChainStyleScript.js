
$(document).ready(function () {
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Metal/AddChainStyle.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';

    jQuery("#tableChainStyle").jqGrid({
        height: 'auot',
        datatype: "local",
        colNames: ['Chain Style','Edit', 'Delete'],
        colModel: [
   		{ name: 'ChainStyle', index: 'id' },   		
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableChainStyle").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Metal/AddChainStyle.aspx?eid=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteChainStyle(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableChainStyle").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableChainStyle").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
function loadChainStyleGrid() {
    EJewel.AdminView.Services.AdminServices.GetChainStyle(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableChainStyle").jqGrid('addRowData', value.ChainStyleID, value);
                 });
             }, onServiceError);
}
function onServiceError() {
    
}
//function used for delete category from grid
function deleteChainStyle(styleid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new chainStylemodel(styleid);
        EJewel.AdminView.Services.AdminServices.DeleteChainStyle(entityObject, function (result) {
            displayMsg('S', "Chain Style Deleted Successfully");
            $("#tableChainStyle").empty();
            loadChainStyleGrid();
        },
             onServiceError);
    }

}
function chainStylemodel(styleid) {
    this.ChainStyleID = styleid;   
    this.Status = false;
}

loadChainStyleGrid();

