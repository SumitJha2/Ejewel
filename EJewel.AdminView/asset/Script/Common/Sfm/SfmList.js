var PAGE_NAME = '';
var count = 0;
var qs = querystring("view");
if (qs.length > 0) {
    PAGE_NAME = qs[0];
}
$(document).ready(function () {
    initGrid(); 
});
function initGrid() {
    jQuery("#tblSfm").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Name ', 'Status', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'Name', index: 'Name', width: 50 },
        { name: 'Status', index: 'Name', width: 50 },
   		{ name: 'edit', index: 'Name', width: 20, align: 'center' },
   		{ name: 'delete', index: 'Name', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        afterInsertRow: function (rowid, rowdata, rowelem) {
        //create link
           var edit_link = "<a href='/Common/Sfm/Sfm.aspx?view=" + PAGE_NAME + "&id=" + rowdata.AutoID + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
           var delete_link = "<a href='javascript:void(0)' onclick='deleteSfm(" + rowdata.AutoID + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
            var status_link = rowdata.Status==true?"Enabled":"Disabled";
            //set cell
            $("#tblSfm").jqGrid('setCell', rowid, 'edit', edit_link, '');
            $("#tblSfm").jqGrid('setCell', rowid, 'delete', delete_link, '');
            $("#tblSfm").jqGrid('setCell', rowid, 'Status', status_link, '');
            //set row color
         }
    });
}
function onServiceError(errorResult) {
}
function loadSingleFieldList() {
    EJewel.AdminView.Services.AdminServices.GetSfmList(PAGE_NAME,
             function (result) {                 
                 $.each(result, function (key, value) {                                     
                     jQuery("#tblSfm").jqGrid('addRowData', value.AutoID, value);
                 });
             }, onServiceError);
}

function deleteSfm(id,row_id) {
    if (confirm('Are you sure...?')) {
        EJewel.AdminView.Services.AdminServices.DeleteSfm(id,PAGE_NAME, function (result) {
            $("#tblSfm").empty();
            loadSingleFieldList();
        },
             onServiceError);
    }
}
loadSingleFieldList();
