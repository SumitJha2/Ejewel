/*
Partha
@ 21-01-13
This file give the details of the chain product
*/
$(document).ready(function () {
    init_chain_style_grid();
    init_chain_length_grid();
});
/*
partha
@ 21-1-13
this is for chain style 
*/
function init_chain_style_grid() {
    var avi_cont = '';
    var def_cont = '';

    jQuery("#tblChainStyle").jqGrid({
        width: 800,
        datatype: "local",
        colNames: ['Avialable','Chain Style', 'Default'],
        colModel: [
   		{ name: 'avialabe', index: 'avialabe',align:'center',width: 20 },
   		{ name: 'ChainStyle', index: 'ChainStyle', align: 'left' },
   		{ name: 'def', index: 'def', width: 20, align: "center" }
   	],
        rownumbers: true,
        viewrecords: true,
        caption: 'Avialable Chain Style',
        gridComplete: function () {
            var ids = jQuery("#tblChainStyle").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var data = ids[i];
                avi_cont = "<input type='checkbox' name='chkStyle" + data + "' id='chkStyle" + data + "' value='" + data + "' />";
                def_cont = "<input type='radio' name='rdoDefStyle' id='rdoDefStyle" + data + "' value='" + data + "' />";
                jQuery("#tblChainStyle").jqGrid('setRowData', ids[i], { avialabe: avi_cont });
                jQuery("#tblChainStyle").jqGrid('setRowData', ids[i], { def: def_cont });
            }
        }
    });
}

function load_chain_style() {
    EJewel.AdminView.Services.AdminServices.GetChainStyle(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tblChainStyle").jqGrid('addRowData', value.ChainStyleID, value);
                 });
             }, onServiceError);
         }
         /*
         partha
         @ 21-1-13
         this is for chain length 
         */
         function init_chain_length_grid() {
             var avi_cont = '';
             var def_cont = '';

             jQuery("#tblChainLength").jqGrid({
                 width: 800,
                 datatype: "local",
                 colNames: ['Avialable', 'Chain Length', 'Default'],
                 colModel: [
   		{ name: 'avialabe', index: 'avialabe', align: 'center', width: 20 },
   		{ name: 'ChainLength', index: 'ChainLength', align: 'left' },
   		{ name: 'def', index: 'def', width: 20, align: "center" }
   	],
                 rownumbers: true,
                 viewrecords: true,
                 caption: 'Avialable Chain Length',
                 gridComplete: function () {
                     var ids = jQuery("#tblChainLength").jqGrid('getDataIDs');
                     for (var i = 0; i < ids.length; i++) {
                         var data = ids[i];
                         avi_cont = "<input type='checkbox' name='chkLength" + data + "' id='chkLength" + data + "' value='" + data + "' />";
                         def_cont = "<input type='radio' name='rdoDefLength' id='rdoDefLength" + data + "' value='" + data + "' />";
                         jQuery("#tblChainLength").jqGrid('setRowData', ids[i], { avialabe: avi_cont });
                         jQuery("#tblChainLength").jqGrid('setRowData', ids[i], { def: def_cont });
                     }
                 }
             });
         }

         function load_chain_length() {
             EJewel.AdminView.Services.AdminServices.GetChainLength(0,
             function (result) {
                 $.each(result, function (key, value) {
                     jQuery("#tblChainLength").jqGrid('addRowData', value.ChainLengthID, value);
                 });
             }, onServiceError);
         }

         function onServiceError(result) {

         }