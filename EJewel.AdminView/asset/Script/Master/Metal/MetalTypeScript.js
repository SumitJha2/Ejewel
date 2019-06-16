
$(document).ready(function () {

    //function used in edit mode to bind corrosponding field
    var qs_name = '';
    var metaltypeid = querystring('EID');
    if (metaltypeid.length > 0) {
        qs_name = metaltypeid[0];
        EJewel.AdminView.Services.AdminServices.GetMetalType(qs_name, OnSuccess, OnServiceError);
    }
});

function SaveMetalType() { 
       try {

           // hide_Seek('Loader', true);
             var metaltypename=$("#txtMetalTypeName").val();
             var price=parseFloat($("#txtMetalPrice").val());
             var status=parseInt($("#ddlStatus").val())==1?true:false;
             var model=new MetaltypeModel(metaltypename,price,status);
             EJewel.AdminView.Services.AdminServices.SaveMetalType(model, function (result) {
                 //hide_Seek('loader', false);
                 displayMsg('S', 'Add MetalType Successfully');
                 $("#btnreset").click();
                 window.location.href = "/Master/Metal/ListMetalType.aspx";

             },
             OnServiceError);

         }
         catch(e)
         {
           //hide_Seek('loader',false);
           displaymsg('S',e.Message);
           pageScroll('loader');
         
         }
   }
   function OnServiceError( result) {
       hide_seek('loader', false);
       displayMsg('E', result._message);
       pageScroll('loader');
   }

function MetaltypeModel(MetalTypename, Price, Status) {
    this.MetalTypeName = MetalTypename;
    this.Price = Price;
    this.Status = Status;
   var metaltypeid = querystring('EID');
   if (metaltypeid.length > 0) {
       this.MetalTypeId= metaltypeid[0];
   }

}
function OnSuccess(result) {
    $.each(result, function (key, value) {
        $("#txtMetalTypeName").val(value.MetalTypeName);
        $("#txtMetalPrice").val(value.Price);
        $("#ddlStatus").val(value.Status);
    });
}