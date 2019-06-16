<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="EJewel.AdminView.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/asset/template/js/jquery/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/asset/opencontrol/tooltips/jquery.tooltip.css" rel="stylesheet" type="text/css" />
    <script src="/asset/opencontrol/tooltips/jquery.tooltip.js" type="text/javascript"></script>
    <script src="/asset/opencontrol/tooltips/tooltip.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("a[rel*=fd_tool_tips]").tooltip({
                track: true,
                delay: 0,
                showURL: false,
                fade: 250,
                bodyHandler: function () {
                    var result = "";
                    //access the data from the jquery ajax
                    $.ajax(
					{
					    // The link we are accessing.
					    url:$( this ).attr('href'),
					    // The type of request.
					    type: "get",
					    async: false,
					    // The type of data that is getting returned.
					    dataType: "html",
					    beforeSend: function () {
					        result = "Please wait...";
					    },
					    success: function (strData) {
					        result = strData;
					    }
					}
					);
                    return result;
                },
                showURL: false
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="/Handler/ProductDescriptionHandler.ashx" rel="fd_tool_tips">Partha</a>
    
    </div>
    </form>
</body>
</html>
