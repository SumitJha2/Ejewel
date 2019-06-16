
$(document).ready(function () {
    
    initGrid();
    $('#lnkCreateNew').attr('href', '/Master/Stone/AddStone.aspx');

});
function initGrid() {
    var edit_link = '';
    var delete_link = '';
    var edit_certificate = '';
    jQuery("#tableStoneDetails").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['SKU', 'Category', 'Type', 'Color', 'Shape', 'Clarity', 'Cut', 'Carate', 'Cert.', 'Edit', 'Dlt'],
        colModel: [
   		{ name: 'SKU', index: 'id', width: 30 },
   		{ name: 'StoneCategory', index: 'invdate', width: 20 },
       { name: 'StoneCategoryType', index: 'invdate', width: 20 },
        { name: 'StoneColor', index: 'invdate', width: 20 },
         { name: 'StoneShape', index: 'invdate', width: 20 },
          { name: 'StoneClarity', index: 'invdate', width: 20 },
          { name: 'StoneCut', index: 'invdate', width: 20 },
          { name: 'StoneCarate', index: 'Stone_Carate', width: 20 },
          { name: 'edit_cert', index: 'edit_cert', width: 10, align: "center" },
   		{ name: 'edit', index: 'edit', width: 10, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 10, align: "center" }

   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        afterInsertRow: function (rowid, rowdata, rowelem) {
            if (rowdata.HasCertificate) {
                edit_certificate = "<a href='javascript:void(0);' onclick='openWindow(\"/Master/Certificate/StoneCertificate.aspx?id=" + rowdata.StoneId + "\", 500, 500);'><img src='/asset/template/images/extra/certificate_16.png' /></a>";
            }
            else {
                edit_certificate = '-';
            }
            edit_link = "<a href='/Master/Stone/AddStone.aspx?id=" + rowdata.StoneId + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
            delete_link = "<a href='javascript:void(0)' onclick='deleteStone(" + rowdata.StoneId + ")'><img src='/asset/template/images/extra/delete_16.png' /></a>";
            //set value
            $("#tableStoneDetails").jqGrid('setCell', rowid, 'edit_cert', edit_certificate, '');
            $("#tableStoneDetails").jqGrid('setCell', rowid, 'edit', edit_link, '');
            $("#tableStoneDetails").jqGrid('setCell', rowid, 'dlt', delete_link, '');
        }

    });
}
function loadStoneGrid() {

    EJewel.AdminView.Services.AdminServices.GetStoneList(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneDetails").jqGrid('addRowData', value.StoneId, value);
                 });
                 $("#loader").css("display", "none");
             }, onServiceError);
}
function onServiceError() {
}
//function used for delete category from grid
function deleteStone(stoneclid) {
    if (confirm('Are you sure, you want to delete this record ?')) {
        var entityObject = new deleteStoneModel(stoneclid);
        EJewel.AdminView.Services.AdminServices.DeleteStone(entityObject, function (result) {
            displayMsg('S', "Stone Details Deleted Successfully");
            $("#tableStoneDetails").empty();
            loadStoneGrid();
        },
             onServiceError);
    }

}
function deleteStoneModel(stoneid) {
    this.StoneID = stoneid;
    this.Status = false;
}

loadStoneGrid();

