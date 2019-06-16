var PAGE_NAME = '';
var count = 0;
var qs = querystring("view");
if (qs.length > 0) {
    PAGE_NAME = qs[0];
}
initGrid();
$(document).ready(function () {
    initGrid(); 
});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tblSingleField").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Name ', 'Status', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'Name', index: 'id', width: 50 },
   		{ name: 'IsActive', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
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
                    $('#tblSingleField').jqGrid('setCell', i, "Name", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "IsActive", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "edit", "", { 'background-color': '#EED4D4' });
                    $('#tblSingleField').jqGrid('setCell', i, "dlt", "", { 'background-color': '#EED4D4' });                    
                }
                edit_link = "<a href='/Common/SingleField/SingleFieldManagement.aspx?view=" + PAGE_NAME + "&id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick='deleteSingleField(" + data + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tblSingleField").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tblSingleField").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }

        }
    });
}
function onServiceError() {
}
function loadSingleFieldList() {
    EJewel.AdminView.Services.AdminServices.GetSingleFieldModel(PAGE_NAME,
             function (result) {                 
                 //jQuery("#tblSingleField").jqGrid('addRowData', 0, '');
                 $.each(result, function (key, value) {                                     
                     jQuery("#tblSingleField").jqGrid('addRowData', value.AutoID, value);
                 });
             }, onServiceError);
}

function deleteSingleField(id) {
    if (confirm('Are you sure you want to delete this record ?')) {
        EJewel.AdminView.Services.AdminServices.DeleteSingleField(id,PAGE_NAME, function (result) {
            $("#tblSingleField").empty();
            loadSingleFieldList();
        },
             onServiceError);
    }
}
loadSingleFieldList();
