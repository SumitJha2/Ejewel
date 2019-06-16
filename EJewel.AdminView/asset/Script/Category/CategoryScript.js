function saveCategory() {
    try {
        //access the value of the controls
        hide_seek('loader', true);
        $("#loader").css("visibility", "visible");
        //$("#btnProcess")
        var name = $("#txtCategoryName").val();
        var categoryorder = $("#ddlCategoryOrder").val();
        var description = $("#txtDescription").val();
        var pageTitle = $("#txtPageTitle").val();
        var metaDescription = $("#txtMetaDescription").val();
        var metaKeywords = $("#txtMetaKeywords").val();
        // var MetaKeywords = $("#chkShowTop").val();
        var status = parseInt($("#ddlStatus").val()) == 1 ? true : false;
        //apply the validation rule
        // type casting
        var entityObject = new StoneCategoryEntity(name, Status);
        //send the request to services
        EJewel.AdminView.Services.AdminServices.SaveUpdateCategory(entityObject, OnCategorySuccess, OnCategoryError);
    }
    catch (e) {
        hide_seek('loader', false);
        displayMsg('S', e.Message);
    }
    function OnCategorySuccess(result) {
        hide_seek('loader', false);
        displayMsg('S', "Category Added Successfully");

    }
    function OnStoneCategoryError(result) {
        hide_seek('loader', false);
        displayMsg('E', result._message);
    }
}
//create Category Entity class
function CategoryEntity(name, status)
 {
    this.CategoryName = name;
    this.CategoryOrder = categoryorder;
    this.Description = description;
    this.PageTitle = pageTitle;
    this.MetaDescription = metaDescription;
    this.MetaKeywords = metaKeywords;
    var showTop = $('#chkShowTop');
    if (showTop.is(':checked')) 
    {
        this.ShowOnTop = true;
    }
    else
     {
        this.ShowOnTop = false;
    }

    this.Status = status;
}