/*
    Partha Ranjan
    @ 28-12-12
    
    This script helps to load certificte master list in page
*/

/*
Partha Ranjan
@ 28-12-12
This function will helps to initialize the grid
*/
function initGrid(view,grid_heading) {
    var edit_link = '';
    var delete_link = '';
    jQuery("#tableCertificateMaster").jqGrid({
        height: 'auto',
        datatype: "local",
        colNames: ['Name', 'Status', 'Edit', 'Delete'],
        colModel: [
   		{ name: 'Name', index: 'id' },
   		{ name: 'Status', index: 'invdate', width: 20 },
   		{ name: 'edit', index: 'edit', width: 20, align: 'center' },
   		{ name: 'dlt', index: 'dlt', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        autowidth: true,
        gridComplete: function () {
            var ids = jQuery("#tableCertificateMaster").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                edit_link = "<a href='/Master/Certificate/ManageCertificateMaster.aspx?view=" + view + "&edit_id=" + data + "'><img src='/asset/template/images/extra/edit_16.png' /></a>";
                delete_link = "<a href='javascript:void(0)' onclick=\"deleteCertificateMaster(" + data + ",'" + view + "')\"><img src='/asset/template/images/extra/delete_16.png' /></a>";
                jQuery("#tableCertificateMaster").jqGrid('setRowData', ids[i], { edit: edit_link });
                jQuery("#tableCertificateMaster").jqGrid('setRowData', ids[i], { dlt: delete_link });
            }
        }
    });
}
/*
    Partha Ranjan
    @ 28-12-12
    This function load the grid data accoring to the view
*/
function loadCertificateMaster(view) {
    switch (view) {
        case 'gridle':
            {
                //init grid
                initGrid(view, 'Gridle Details');
                //load the Certificate Gridle
                loadGridle();
            } break;
        case 'symmerty':
            {
                //init grid
                initGrid(view, 'Symmerty Details');
                //load the Certificate symmetry
                loadSymmetry();
            } break;
        case 'culet':
            {
                //init grid
                initGrid(view, 'Culet Details');
                //load the Certificate culet
                loadCulet();
            } break;
        case 'polish':
            {
                //init grid
                initGrid(view, 'Polish Details');
                //load the Certificate polish
                loadPolish();
            } break;
        case 'flouresence':
            {
                //init grid
                initGrid(view, 'Flouresence Details');
                //load the Certificate flouresence
                loadFlouresence();
            } break;
        case 'lab':
            {
                //init grid
                initGrid(view, 'Lab Details');
                //load the Certificate lab
                loadLab();
            } break;
    }
}

/*
Partha Ranjan
@ 28-12-12
This function is helps to handle the error in services call
*/
function onServiceError(result) {
    hide_seek('loader', false);
    displayMsg('E', result._message);
    pageScroll('loader');
}

/*
Partha Ranjan
@ 28-12-12
This functions are helps to load the different view on user demand
*/
        //load Grildle
        function loadGridle() {
            EJewel.AdminView.Services.AdminServices.GetCertificateGridle(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }
         //load Symmetry
         function loadSymmetry() {
             EJewel.AdminView.Services.AdminServices.GetCertificateSymmetry(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }
         //load Culet
         function loadCulet() {
             EJewel.AdminView.Services.AdminServices.GetCertificateCulet(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }
         //load Polish
         function loadPolish() {
             EJewel.AdminView.Services.AdminServices.GetCertificatePolish(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }
         //load Flouresence
         function loadFlouresence() {
             EJewel.AdminView.Services.AdminServices.GetCertificateFlouresence(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }
         //load lab
         function loadLab() {
             EJewel.AdminView.Services.AdminServices.GetCertificateLab(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tableCertificateMaster").jqGrid('addRowData', value.ID, value);
                 });
             }, onServiceError);
         }

/*
    Partha Ranjan
    @ 28-12-12

    This function helps to delete the  certificate master
*/
         function deleteCertificateMaster(id, view_name) {
           
                 switch (view_name) {
                     case 'gridle':
                         {
                            
                             deleteGridle(id);
                         } break;
                     case 'symmerty':
                         {                             
                             deleteSymmetry(id);
                         } break;
                     case 'culet':
                         {
                             deleteCulet(id);
                         } break;
                     case 'polish':
                         {
                             deletePolish(id);
                         } break;
                     case 'flouresence':
                         {
                             deleteFlouresence(id);
                         } break;
                     case 'lab':
                         {
                             deleteLab(id);
                         } break;               
             }
         }

/*
    Partha Ranjan
    @ 28-12-12
    These functions are helps to delete the data from certificate master
*/
         function deleteGridle(id) {
             //DeleteGridle
             EJewel.AdminView.Services.AdminServices.DeleteCertificateGridle(id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadGridle();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
         function deleteSymmetry(id) {
             alert('xxx');
             //DeleteGridle
             EJewel.AdminView.Services.AdminServices.DeleteCertificateSymmetry(id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadSymmetry();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
         function deleteCulet(id) {
             //DeleteGridle
             EJewel.AdminView.Services.AdminServices.DeleteCertificateCulet (id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadCulet();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
         function deletePolish(id) {
             //DeleteGridle
             EJewel.AdminView.Services.AdminServices.DeleteCertificatePolish(id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadPolish();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
         function deleteFlouresence(id) {
             //DeleteGridle
             EJewel.AdminView.Services.AdminServices.DeleteCertificateFlouresence(id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadFlouresence();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
         function deleteLab(id) {
             //Delete Lab
             EJewel.AdminView.Services.AdminServices.DeleteCertificateLab(id,
             function (result) {
                 if (result == true) {
                     deleteSuccess();
                     loadLab();
                 }
                 else {
                     deleteError();
                 }
             }, onServiceError);
         }
/*
    Partha Ranjan
    @ 28-12-12
    This function us global for through delete
*/
         function deleteError() {
             hide_seek('loader', false);
             displayMsg('E', 'Oops..!Error in delete.Try again');
             pageScroll('loader');
         }
         /*
         Partha Ranjan
         @ 28-12-12
         This function  global for through success
         */
         function deleteSuccess() {
             hide_seek('loader', false);
             displayMsg('S', 'Delete done successfully');
             pageScroll('loader');
             //clear data
             jQuery("#tableCertificateMaster").jqGrid("clearGridData");
         }