 var PAGE_NAME = '';
 var qs = querystring("view");
 var count = 0;
    if (qs.length > 0) {
        PAGE_NAME = qs[0];
    }

$(document).ready(function () {
    initGrid();
    $("#lnkCreateNew").attr('href', '/Master/Stone/AddStoneCut.aspx');
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tblSingleField").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Name ', 'Category', 'Status', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'Name', index: 'id' },
   		{ name: 'StoneCategory', index: 'invdate' },
        { name: 'IsActive', index: 'invdate' },
   		{ name: 'edit', index: 'edit', width: 50, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 50, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tblSingleField").jqGrid('getDataIDs');        
                      
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                var Name = $('#tblSingleField').jqGrid('getCell', i, 'IsActive');
                if (Name == "Disabled") {              
                    $('#tblSingleField').jqGrid('setCell', i, "IsActive", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "Name", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "StoneCategory", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "edit", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "dlt", "", { 'background-color': '#EED4D4' });
                }
                edit_link = "<a href='/Master/Stone/StoneSpecificationManagement.aspx?id=" + data + "&view=" + PAGE_NAME + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='DeleteStoneSpecification(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tblSingleField").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tblSingleField").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
 
function onServiceError() {
}
function loadStoneSpecificationGrid() {
    EJewel.AdminView.Services.AdminServices.GetStoneSpecificationList(0, PAGE_NAME,
             function (result) {
                 jQuery("#tblSingleField").jqGrid('addRowData',0, '');
                 $.each(result, function (key, value) {
                     jQuery("#tblSingleField").jqGrid('addRowData', value.AutoID, value);               
                 });
             }, onServiceError);
}
function DeleteStoneSpecification(id) {
    if (confirm('Are you sure you want to delete this record ?')) {        
        EJewel.AdminView.Services.AdminServices.DeleteStoneSpecification(id,PAGE_NAME, function (result) {
            $("#tblSingleField").empty();
            loadStoneSpecificationGrid();
        },
             onServiceError);
    }
}
loadStoneSpecificationGrid();
