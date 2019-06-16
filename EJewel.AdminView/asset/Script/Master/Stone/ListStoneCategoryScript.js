
$(document).ready(function () {
    initGrid();
    $("#lnkCreateNew").attr('href', '/Master/Stone/AddStoneCategory.aspx');

});
    function initGrid() {
        var edit_link = '';
        var delete_link = '';
        jQuery("#tableStoneCategory").jqGrid({
            height: 'auto',
            datatype: "local",
           // colNames: ['Category Name', 'Status', 'Edit', 'Delete'],
            colNames: ['Stone Category Name'],
            colModel: [
   		{ name: 'StoneCategoryName', index: 'id'}
   	],
            rownumbers: true,
            viewrecords: true,
            autowidth: true,  
           

        });
//        jQuery("#tableStoneCategory").jqGrid('navGrid', '#pager2', { edit: true, add: false, del: true });
    } 

    function loadStoneCategoryGrid(){

        EJewel.AdminView.Services.AdminServices.GetStoneCategory(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableStoneCategory").jqGrid('addRowData', value.StoneCategoryID, value);
                 });
             }, onServiceError);
         }
         function onServiceError() {
         }
         //function used for delete category from grid
         function deleteStoneCategory(stonecatgid) {
             if (confirm('Are you sure you want to delete this record ?')) {
                 var entityObject = new stonecategorymodel(stonecatgid);
                 EJewel.AdminView.Services.AdminServices.DeleteStoneCategory(entityObject, function (result) {
                     displayMsg('S', "Stone Category Deleted Successfully");
                     $("#tableStoneCategory").empty();
                     loadStoneCategoryGrid();
                 },
             onServiceError);
             }

     }
     function stonecategorymodel(stonecatgid) {
         this.StoneCategoryID = stonecatgid;
         this.Status = false;
     }
     loadStoneCategoryGrid();
     


