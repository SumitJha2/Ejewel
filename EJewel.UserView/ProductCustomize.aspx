<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCustomize.aspx.cs" Inherits="EJewel.UserView.ProductCustomize" %>

<%@ Register src="controls/LooseDiamondContent.ascx" tagname="LooseDiamondContent" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/assets/themes/css/extra/swatch_stone.css" rel="stylesheet" type="text/css" />
    <link href="/assets/themes/css/extra/loose_diamond.css" rel="stylesheet" type="text/css" />
    <!--Loose Diamond-->
    <script src="/assets/controls/centerstone_fillter.js" type="text/javascript"></script>
    <script src="/assets/themes/js/tabcontent.js" type="text/javascript"></script>
    <link href="/assets/themes/tabs/tabcontent.css" rel="stylesheet" type="text/css" />

    <script src="/assets/themes/js/jquery.carouFredSel-6.2.1-packed.js" type="text/javascript"></script>

    <script src="/assets/controls/jquery.lazyload.js" type="text/javascript"></script>

     <script type="text/javascript">

         function popitup(url) {
             newwindow = window.open(url, 'name', 'height=500,width=500');
             if (window.focus) { newwindow.focus() }
             return false;
         }
</script>
    <!-- style for popover on table -->

    <style type="text/css">
        
        .item_head
        {
            background-image:url('/assets/themes/img/icon/fd_list.png');
            height:10px;
            width:10px;
            display:inline-block;
        }
    .validation_cls
     {
     	color:Red;
     	display:inline !important;
     }
        
        #ds_diamond_details
        {
        height: 300px;
        width: 120px;
        position: absolute;
        border :1px solid #ddd !important;
        
        }
    </style>

    <style type="text/css">    
    #images-fd{ width:470px; height:470px; left:0px!important;}
    #thumbs-fd img {
				    border: 0px solid #c9c9c9;
				    padding: 0px;
				    margin: 10px 0px 5px 0px;
				    cursor: pointer;
                    box-sizing:border-box;
                    width:120px;
                    height:120px;
			    }
    /*#thumbs-fd img.selected, #thumbs-fd img:hover {border:1px solid #888;}*/
    #thumbs-fd img.selected:before{    
        content: "2222";
    display: block;
    position: absolute;
    top: 53px;
    left: 100%;
    width: 0;
    height: 0;
    border-color: transparent transparent transparent #fff;
    border-style: solid;
    border-width: 7px;
    }

    #prev-fd, #next-fd{ 
    text-indent: -119988px;
    overflow: hidden;
    text-align: left;
    background: #fff url('/assets/themes/img/sprite/next-prev.png') 50% 0 no-repeat;
    width: 122px;
    height: 12px;
    display: block;
    cursor: pointer;
    }
    #prev-fd{margin-bottom:3px;}
    #prev-fd:hover{background-position: 50% -24px;}

    #next-fd{background-position: 50% -12px; margin-top:3px;}
    #next-fd:hover{background-position: 50% -36px;}

    </style>

    <style type="text/css">        
        /******************* Pravin 1-6-13 customize widget*************************/
        #prod-customize .hdr {
            
            color: #fff;
            font-weight: normal;
            padding: 10px 7px;
              font-family:'EB Garamond', serif; 
              text-transform:uppercase;
              font-size:18px;
              border: 2px solid #BF1E2E;
            /*  background-color: #ce686d;*/
              background-color:#ce686d;
              background-color:  rgba(206, 104, 109, 1.0);
 -webkit-transition: border-color 0.25s ease-in;
 -moz-transition: border-color 0.25s ease-in;
 -ms-transition: border-color 0.25s ease-in;
 -o-transition: border-color 0.25s ease-in;
 transition: border-color 0.25s ease-in;
 text-align:center;
 
 -webkit-box-sizing: border-box;
 -moz-box-sizing: border-box;
 box-sizing: border-box;
              
              
              

        }

        #customize-list {
            border: 1px solid #ddd;
            margin: 0;
            padding: 0;
            margin-top: -20px;
            box-sizing: border-box;
        }

            #customize-list .customize-item {
                margin: 0px 0px;
                padding: 0px 3px;
                position: relative;
            }

            
        #customize-list .customize-item:hover .customize-item-heading dl,
        #customize-list .customize-item-heading dl.active,
        .customize-item-heading span.active {
             cursor: pointer;
             background-color: #ececec; color:#000;
        }

        .customize-item-heading:hover span {
            color:#333; 
        }

        .customize-item-heading dl {
            margin: 3px;
            padding: 5px;
            border: 1px solid #DDD;
        }

        .customize-item-heading dt, .customize-item-heading dd {
            display: inline-block;
        }

        .customize-item-heading dd {
            float: right;
            margin-right: 1px;            
        }

        .customize-item-heading dd i[class^='swatch-stone']{margin-top:0px;}
        .customize-item-heading dd i[class^='swatch-metal']{ margin-top:15%;}
              
        
        .customize-item-heading span[class^='title'] {
            display: block;
        }

        .customize-item-heading .title1 {
            text-transform: uppercase;
        }

        .customize-item-description {
            display: none;
            padding: 5px 3px;
            position: relative;
        }
            .customize-item-description .swatch-wrap {
                margin: 10px;
            }
            
           
            .customize-item-description .swatch-wrap i{
                cursor:pointer; 
                transition:all ease-in-out 0.10s;
            }
            
            .customize-item-description .item-details {
                outline: 1px solid #ddd;
                min-height: 20px;
                margin: 10px;
                padding: 4px;
                font-size:10pt;
                color:Black;
            }
     
    </style>

    <style type="text/css">
        
        /******************************** General *************************************/
        .pull-right {float: right;}
        .pull-left{float:left;}
        .text-center{text-align:center;}
        .text-right{text-align:right;}

        .page-header-fd {            
            margin: 0px 0px 0px 0px;
            border-bottom: 1px solid #eee;        
            overflow:hidden;
            color:#6E6E6E;
        }

       .page-header-fd .section-heading{ margin:37px 0px 0px 0px;  font-family:'EB Garamond', serif; font-size:24px;  }
        .page-header-fd #price_tag{ margin-top:-20px; display: block; text-align:right; font-weight:bold;  font-family:'LaneNarrowRegular',serif; font-size:22px; color:#CE686D;}

</style>

    <style type="text/css">
        /************************* Buttons************************/
        .btn-fd {
            border-left: 1px solid #e6e6e6;
            border-right: 1px solid #e6e6e6;
            border-top: 1px solid #e6e6e6;
            border-bottom: 1px solid #b3b3b3;
            display: inline-block;
            padding: 4px 12px;
            margin-bottom: 0;
            font-size: 12px;
            line-height: 16px;
            color: #333;
            text-align: center;
            text-shadow: 0 1px 1px rgba(255,255,255,0.75);
            vertical-align: middle;
            cursor: pointer;
            background-color: #f5f5f5;
            background-repeat: repeat-x;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
            background-image: linear-gradient(to bottom,#fff,#e6e6e6);
        }


        .btn-block-fd {
        display: block;
        width: 100%;
        padding-right: 0;
        padding-left: 0;
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
        }

        .btn-12-fd { padding:12px; margin:10px 0;}
        
        
        
    .btn-addtocart-fd {
            display: block;
           
           font-family:'EB Garamond', serif; 
          
             width:100%;
            background: #70a3d8;            
            font-size: 18px;
            text-align: center;
            padding: 10px;
            background: #e9e9e9;
            border: 1px solid #c2c2c2;
            color: dimgrey;
            text-shadow: 0 1px #fff;
            line-height: 19px;
            padding: 10px 21px 7px;
            border-radius: 2px;
            text-transform: uppercase;
            transition: all ease-in-out 0.18s;
            -moz-transition: all ease-in-out 0.18s;
            -o-transition: all ease-in-out 0.18s;
            -webkit-transition: all ease-in-out 0.18s;
        }/* 7-6-13 */

            .btn-addtocart-fd:hover {
                color: #cb4c61;
            }

            .btn-fd:hover, .btn-addtocart-fd:hover {
                background: #dcdcdc;
                font-family:'EB Garamond', serif; 
                border-color: #b2b2b2;
                text-decoration: none;
                -webkit-box-shadow: inset 0 1px 0 rgba(255,255,255,0.35),inset 0 -1px 0 rgba(0,0,0,0.08);
                -moz-box-shadow: inset 0 1px 0 rgba(255,255,255,0.35),inset 0 -1px 0 rgba(0,0,0,0.08);
                box-shadow: inset 0 1px 0 rgba(255,255,255,0.35),inset 0 -1px 0 rgba(0,0,0,0.08);
            }
            
            
             .btn-white {
            background: #fff;
            border: 1px solid #c2c2c2;
            font-family:'EB Garamond', serif; 
            color: dimgrey;
            text-shadow: 0 1px #fff;
            font-weight: normal;
            font-size:15px;
            text-transform:uppercase;
        }

            .btn-white:hover {
                background: #f6f6f6;
                border-color: #c6c6c6;
                color: dimgrey;
            }

        .lnk-care {
            font-size: 8.5pt;
            text-align: center;
            display: block;
        }

            .lnk-care:hover {
                color: #2e3942;
            }
        
        .btn-wishlist {   padding:7px 0;}
         .icon-addtocart {
            background:url('/assets/themes/img/icon/shop_cart.png') no-repeat left center;
            width:16px; height:16px; padding-right:7px;
        }
        .heart-icon {
            background:url('/assets/themes/img/icon/icon_heart.png') no-repeat left center;     
            width:20px; height:20px; margin:10px; padding:8px;
        }
   

</style>

    <style type="text/css">
        #price_tag
        {
            font-size:20px; 
            color:#6E6E6E; 
            width:150px;
            float:right;
        }
        hr
        {
            margin:0px !important;
        }
    </style>

    <style type="text/css">
        .table {width: 100%; font-size:8pt; box-sizing:border-box; border-collapse:collapse;}
        .table thead tr{ background-color:#ddd; }
        .table th{padding:8px;}

        .table th, .table td{ 
            text-align:center;          
            vertical-align: middle;                        
        }
        .table tr{}
        .table td{ padding:1px; border-top:1px solid #ddd; }
        .table .btn-fd{padding:3px 5px; margin:5px 0;}
        .table input[type="checkbox"]{border:1px solid #000; visibility:visible;}
    </style>

    <!--************************ Pravin 31-5-13 Script for Product Angle **************************************-->
    <script type="text/javascript">
        $(function () {
            $('#thumbs-fd').carouFredSel({
                synchronise: ['#images-fd', false, true],
                auto: false,                
                items: {
                    visible: 3,
                    width: 'variable',
                    start: -1
                },
                direction: 'up',
                align: 'center',
                scroll: {
                    onBefore: function (data) {
                        //data.items.old.eq(1).removeClass('selected');
                        //data.items.visible.eq(1).addClass('selected');
                    },
                    items: 1

                },
                prev: '#prev-fd',
                next: '#next-fd'
            });

            $('#images-fd').carouFredSel({
                auto: false,
                align: 'center',
                width: 320, height: 320,
                items: 1,
                scroll: {
                    fx: 'fade'
                }
            });

            $('#thumbs-fd img').click(function () {
                $('#thumbs-fd').trigger('slideTo', [this, -1]);
            });
            //$('#thumbs-fd img:eq(1)').addClass('selected');
        });
    </script>

<!-- ******************************* Pravin 1-6-13 Customize Widget ************************* -->
<script type="text/javascript">
    /******************************* Customize Widget *************************/
    $(function () {
        $('#customize-list .customize-item').each(function () {
            var currentItem = $(this);
            $('.customize-item-heading, .btn', currentItem).on('click', function (e) {
                e.preventDefault();
                currentItem.siblings().slideToggle('fast');
                currentItem.find('dl').toggleClass('active').find('span[class^="title"]').toggleClass('active');
                currentItem.find('.customize-item-description').slideToggle('slow');
            });

            $('i[class^="swatch-"]', currentItem).on('mouseover mouseout click', function (e) {
                e.preventDefault();
                var curText = $(this).text();
                var selStoneName = $(".title2", currentItem);
                var swatchWrap = $(".swatch-wrap", currentItem);

                if (e.type === 'mouseover') {
                    $(".item-details").text(curText);
                    $(swatchWrap).on('mouseover', 'i', function () {
                        $(this).siblings().css({ 'opacity': '0.2' });
                    });
                }
                if (e.type === 'mouseout') {
                    $(".item-details").text(selStoneName.text());
                    $(swatchWrap).on('mouseout', 'i', function () {
                        $(this).siblings().css({ 'opacity': '1' });
                    });
                }
                if (e.type === 'click') {
                    selStoneName.text(curText);
                    $(this).clone().appendTo($('dd', currentItem).empty());
                }
            });
        });
    });    
    
    
        // -------------------------Added by sumit on 07-06-2013---------------------

        function validate() {
        $("#spanMsg").text('');
            $("#spanMsg").css("color","red");
        if (document.getElementById("<%=txtFirstName.ClientID %>").value== "") {
            $("#spanMsg").text('Please enter first name.');
            return false;
        }
        else if (document.getElementById("<%=txtLastName.ClientID %>").value == "") {
            $("#spanMsg").text('Please enter last name.');
            return false;
        }
       else if(!(/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/).test(document.getElementById("<%=txtEmail.ClientID %>").value))
        {           
           $("#spanMsg").text('Please enter valid email.');
           return false;
          }  
         else if (document.getElementById("<%=txtTelephone.ClientID %>").value == "") {
            $("#spanMsg").text('Please enter telephone no.');
            return false;
        }
        else if (document.getElementById("<%=txtMessage.ClientID %>").value == "") {
            $("#spanMsg").text('Please enter message.');
            return false;
        }

         else if (document.getElementById("<%=txtEmail.ClientID %>").value == "") {
            $("#spanMsg").text('Please enter email');
            return false;
        }       
        else {
            return true;
        }
    } 
    
            function btnSave_onclick() {
            try {               
                    if (validate()) {
                        //access the controls 
                        var queriesid=0;
                        var product_id = <%=_PRODUCT_ID %>;
                        var FirstName =$("#<%= txtFirstName.ClientID  %>").val();
                        var lastName =$("#<%= txtLastName.ClientID  %>").val();
                        var email =$("#<%= txtEmail.ClientID  %>").val();
                        var telephone =$("#<%= txtTelephone.ClientID  %>").val();
                        var message =$("#<%= txtMessage.ClientID  %>").val(); 
                        var status=false; 
                        var queries_model = {ProductQueriesId:queriesid,ProductId: product_id, FirstName: FirstName, LastName: lastName, Email: email, Telephone: telephone,Message:message,Status:status};
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/Service.asmx/SaveUpdateQueriesOnProduct",
                            data: JSON.stringify({ model: queries_model}),
                            dataType: "json",
                            success: function (successResult) {
                                $("#spanMsg").html(successResult.d);
                                $("#spanMsg").css("color", "green");
                                $("#spanMsg").text("Thank you for contacting us.");
                            },
                            error: function (errorResult) {
                            }
                        });
                    }
              
            }
            catch (e) {
                alert(e);
            }
        }

      
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container push-below-header">
  
        <div class="row push10">
            <div class="span12">
                <div class="row">
                    <div class="span9">
                      <div class="row-fluid">
                            <div class="page-header-fd">
                                <h2 class="span10 section-heading product-heading small-text-for-product-title"><asp:Literal ID="ltrlProductTitle" runat="server"></asp:Literal></h2>
                                <h2 class="span2 text-right section-heading longer product-heading primary.big">
                                    <span id="price_tag" class="primary uber-text dark one-liner phone-block">$<asp:Literal ID="ltrlPrice" runat="server"></asp:Literal></span>
                                </h2>
                            </div>
                        </div>

               <!--Image Content-->

        <div class="push20 phone-full-width">
      <div class="row push15">
      <div class="span2" >
      <span id="prev-fd">prev</span>
       <div id="thumbs-fd">
                                <%
                                    if (_lstProductImageManager != null)
                                    {
                                        if (_TOTAL_IMAGE > 0)
                                        {
                                            for (int i = 0; i < _TOTAL_IMAGE; i++)
                                            {
                                                %>
                                                <div class="image-holder small">
                                                 <img class="lazy" data-angle="A<%= (i+1)  %>"  src="/assets/themes/img/icon/loading_55.gif" alt="Image" data-original="/Handler/ImageManager.ashx?GUID=<%= _lstProductImageManager[i].GUID %>&height=120" id="imgSideThumb_<%= (i+1) %>" />
                                                </div>
                                               
                                                <%
                                            }
                                        }
                                    }
                                 %>
                                </div>
     <span id="next-fd">next</span>
      </div>

      <div class="span7">
       
       <p class="normal push10 phone-full-width">
       <center>

       <%
                                    if (_lstProductImageManager != null && _lstProductImageManager.Count>0)
                                    {
                                        _DEF_IMAGE_GUID = _lstProductImageManager[0].GUID;
                                         %>
                                 <img class="lazy" src="/assets/themes/img/icon/loading_55.gif" data-original="/Handler/ImageManager.ashx?GUID=<%= _lstProductImageManager[0].GUID %>&height=470" alt="product" id="centerImage">
                                 <%
                                    } %>


</center>

       </p>
       <div class="image-controls transparent phone-block" style="float:right;">
        <a href="#" class="noMargin" id="p-facebook">Facebook</a>
        <a href="#" id="p-gplus">G+</a>
        <a href="#" id="p-print">Print</a>
       </div>
      </div>
     </div>
     </div>
                    </div>
                    
                    <div class="span3">
                        <div id="prod-customize">
                            <h5 class="hdr">Customize</h5>
                            

                            <ul id="customize-list">
                            <asp:Literal ID="ltrlCustomizeTab" runat="server"></asp:Literal>
                                
                            </ul>
                        </div>                        
                       
                        <div id="description">
                       <h5 style="font-family: 'LaneNarrowRegular',serif; font-size:20px; color:#CE686D;">SKU : <%= _SKU %></h5>
                        <p  style="font-family:'EB Garamond', serif; font-size:18px; text-align:justify;"><%= _PRODUCT_DESC%></p>
                    </div>    


                     
                    

                        <div class="row-fluid">
                            <input type="button" class="btn-addtocart-fd  push40" value="Add to Cart" onclick="add_to_cart(this)" /><%--<span class="icon-addtocart"> </span>--%>
                            <input type="button" class="btn-wishlist btn-fd  btn-block-fd btn-white text-center push10" value="Add to Wishlist" />  <%--<span class="heart-icon"></span> --%>


                            <a href="#" class="lnk-care push20">QUESTIONS? CUSTOMER CARE IS HERE 24/7</a>
                        </div>


                       <%--   <div class="row-fluid">
                            <input type="button" class="btn-addtocart-fd" value="Add to Cart" onclick="add_to_cart(this)" />
                            <input type="button" class="btn-fd btn-12-fd btn-block-fd" value="Add to Wishlist" />
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        <!--Tab Controls--> 
        <div class="row push20" id="tabProduct">

        <div style="margin: 0 auto; width:96%;">
        <ul class="tabs" persist="true">
            <% if (_DEF_CENTER_STONE_ID > 0)
               { %>
            <li><a href="#" rel="view1">Center Stone</a></li>
            <%} %>
            <li><a href="#" rel="view2">Overview</a></li>
            <li><a href="#" rel="view3">Why FD</a></li>
            <li><a href="#" rel="view4">Reviews</a></li>
            <li><a href="#" rel="view5">Recently Purchased</a></li>
            <li><a href="#" rel="view6">Questions</a></li>
        </ul>

        <div class="tabcontents">
            <% if (_DEF_CENTER_STONE_ID > 0)
               { %>
            <div id="view1" class="tabcontent">
             <div id="centerStone-wrap">
                    <div class="row-fluid">
                        <div id="left-col" class="span6">
                            <div class="row-fluid" id="centerStone-shape">
                                <div class="span2 centerStone-label">Stone: </div>
                                <div id="shape-wrap" class="span10">
                                <%
                                var lstStoneShape = GetStoneShapeList();
                                if (lstStoneShape != null)
                                {
                                    string css = "";
                                    int total_item = lstStoneShape.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                        css = _DEFSHAPE == lstStoneShape[i].Shape ? "selected" : "";
                                    %>
                                    <i class="icon-shape-large-<%= lstStoneShape[i].Shape.ToLower() %> <%=css %>" data-toggle="popover" data-title="<%= lstStoneShape[i].Shape  %>" data-content="" data-id="<%= lstStoneShape[i].StoneShapeId %>"><%= lstStoneShape[i].Shape %></i>
                                    <%
}
                                }
                                 %>
                                </div>
                            </div>
                            <div class="row-fluid" id="centerStone-color">
                                <div class="span2 centerStone-label">Color: </div>
                                <div id="color-wrap" class="span10">                                                   
                                        <%
                                var lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Color);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class=""  data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
                            </div>

                            <div class="row-fluid" id="centerStone-clarity">
                                <div class="span2 centerStone-label">Clarity: </div>
                                <div id="clarity-wrap" class="span10">                                                   
                                        <%
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Clarity);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class=""  data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
                            </div>
                        </div>

                        <div id="center-col" class="span6">
                            <div class="row-fluid" id="centerStone-cut">
                                <div class="span2 centerStone-label">Cut: </div>
                                <div id="cut-wrap" class="span10">    
                                <%                                               
                                lstSpecification = GetStoneSpecificationList(EJewel.Model.Admin.Master.Stone.StoneSpecificationModel.PageName.Cut);
                                if (lstSpecification != null)
                                {
                                    int total_item = lstSpecification.Count;
                                    for (int i = 0; i < total_item; i++)
                                    {
                                    %>
                                    <i class="" data-toggle="popover" data-title="" data-id="<%= lstSpecification[i].AutoID %>"><%= lstSpecification[i].Name%></i>
                                    <%
}
                                }
                                 %>
                                </div>
                            </div>

                            <div class="row-fluid" id="centerStone-carat">
                                <div class="span2 centerStone-label">Carat: </div>
                                <div id="carat-wrap" class="span10">       
                                    <div id="carat-slider"></div>                                            
                                        <div class="row-fluid">
                                            <div class="span12 range-wrap">
                                                <span class="range pull-left" id="carat-range-1"><%= _MINCARAT %></span>
                                                <span class="range pull-right" id="carat-range-2"><%= _MAXCARAT %></span>
                                            </div>
                                        </div>                                        
                                </div>
                            </div>

                            <div class="row-fluid" id="centerStone-price">
                                <div class="span2 centerStone-label">Price: </div>
                                <div id="price-wrap" class="span10">       
                                    <div id="price-slider"></div>                                            
                                        <div class="row-fluid">
                                            <div class="span12 range-wrap">
                                                <span class="range pull-left" id="price-range-1">$<%= _MINPRICE %></span>
                                                <span class="range pull-right" id="price-range-2">$<%= _MAXPRICE %></span>
                                            </div>
                                        </div>                                        
                                </div>
                            </div>
                        </div>

                        
                    </div>
                    <div class="row-fluid">
                        <div class="span8">
                            <dl id="sel-filter" class="pull-left">
                                <dt><strong>Your Selection: </strong> </dt>
                                <dd>rounded F color diamond</dd>
                            </dl>
                            <a href="#" id="reset" class="pull-right"><i class="icon-reset"></i></a>
                        </div>

                        <div class="span4 text-center" id="knowmore">
                            <p><a href="#">Know More About Diamonds</a></p>
                        </div>
                    </div>
                </div>
             <uc1:LooseDiamondContent ID="LooseDiamondContent1" runat="server" />

            </div>
            <%} %>

            <div id="view2" class="tabcontent">
                


                	<div class="row-fluid">
					
                    <!--For Setting Information-->
                 <div class="span6">
                    <h3 class="overviewHeading">SETTING INFORMATION</h3>
                     <asp:Panel ID="panSettingInfo" runat="server">
                     </asp:Panel>
					</div>

                    <!--For Center Stone-->
                    <% if (_DEF_CENTER_STONE_ID > 0)
                       { %>
                 <div class="span6">
						<h3 class="overviewHeading">CENTER STONE INFORMATION</h3>
                        <asp:Panel ID="panCenterStone" runat="server"></asp:Panel>
                 </div>
                 <%} %>
                 
               
				</div>

                <div class="row-fluid">
                
                  <!--For Side Stone Info-->
                 <%if (_DEF_SIDE_STONE_ID > 0)
                   { %>
					<div class="span6">
                        <h3  class="overviewHeading">ACCENT STONE INFORMATION</h3>
                        <div id="panSideStone"></div>
					</div>
                    <%} %>

                    <!--For Matching Band-->
                    <% if (_DEF_MATCHING_BAND_SIDE_STONE_ID>0){ %>
                    <div class="span6" >
                        <h3  class="overviewHeading">MATCHING BAND INFROMATION</h3>
                        <div id="panMatchingBand"></div>
					</div>
					<%} %>
                
                
                </div>
            </div>

            <div id="view3" class="tabcontent">

					       <b>WHY BUY FROM FD?</b>
                <p>Fascinating Diamonds gives a unique never experienced shopping experience. We strive to provide an enjoyable yet professional online store for diamonds and jewellery based on our company’s fundamental policy and a dream founded upon unwavering conviction in Customer Service & Satisfaction; Exceptional Quality; Value & Education. We continuously make every effort to make Fascinating Diamonds your first choice for the best diamond jewelry items, superior customer care and super fast shipping service. We along with world leaders in technology and security, provide you with a user-friendly, fully interactive and protected online shopping experience.
</p>
              <div class="row"> 

              <div class="span4">
              <p>EXCEPTIONAL SERVICES</p>
 <p>Excellent Quality and Lowest Price Guaranteed</p>
 <p>Expert Diamond and Fine Jewelry Guidance</p>
 <p>Finely Hand Crafted Pre-Designed Rings Available</p>
 <p>‘Design Your Ring’ Option Available</p>
 <p>GIA Certified Diamonds</p>
 <p>100% Secure Online Shopping</p>
 <p>30-Days Return cum Money Back </p>
              </div>
              
              <div class="span3">
              <p> FREE SERVICES</p>
 <p>Free Shipping</p>
 <p>Free Insurance till Your Door Steps</p>
 <p>Free Diamond Certification</p>
 <p>1 Year Free Rhodium Dipping,</p>
 <p>1 Year Free Polishing</p>
 <p>1 Year Free Prong Tightening</p>
              </div>
              
              
              <div class="span3">
               <p>VALUE ADDED SERVICES</p>
 <p>In-depth Education and Information on Diamonds</p>
 <p>All our jewelry is exclusively made in the USA</p>
 <p>1 Year Warranty</p>
 <p>Exceptional Packaging in a Gift-worthy Jewelry Box</p>
              </div> 
              
              
              </div>
           
            </div>
            
           <div id="view4" class="tabcontent">
                <b><a href="javascript:void(0)" onclick="popitup('/ProductReview.aspx?id=<%=_PRODUCT_ID %>')">Create Review</a></b>
                
              
                <span id="spnReview" runat="server" style="overflow:auto;"></span> 
                        
            </div>

            <div id="view5" class="tabcontent">
                <b>Opened by a link from another page</b>
                <p>Link from another page can select a tab on the target page when loaded.</p>                
            </div>

            <div id="view6" class="tabcontent">

            <div class="span6">
					<div class="row push10">
						<div class="span6">
							<p class="primary long phone-block">
								Get in touch.we aim to guide you at every step !
							</p>
						</div>
					</div>

					<div class="row push20 phone-block">
						<div class="span3">
							<p>First Name: <span class="validation_cls">*</span></p>
						</div>
                        
						<div class="span3">
							<p>Last Name: <span class="validation_cls">*</span></p>
						</div>
					</div>

					<div class="row">
						<div class="span3">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>                
							
						</div>
						<div class="span3">
							
                         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
						</div>
					</div>

					<div class="row phone-block">
						<div class="span3">
							<p>E-mail:<span class="validation_cls">*</span></p>
						</div>
						<div class="span3">
							<p>Telephone:<span class="validation_cls">*</span></p>
						</div>
					</div>

					<div class="row">
						<div class="span3">
						
                           <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
						</div>
						<div class="span3">
					
                               <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
						</div>
					</div>

					<div class="row phone-block">
						<div class="span6">
							<p>Message:<span class="validation_cls">*</span></p>
						</div>
					</div>

					<div class="row">
						<div class="span6">
							
                             <asp:TextBox ID="txtMessage" TextMode="MultiLine" runat="server"></asp:TextBox>
						</div>
					</div>

					<div class="row">
						<div class="span6 push40">						
                             
                                <input type="button" id="btnSave" onclick="btnSave_onclick()" value="Submit"  class="simple-submit secondary" /><span id="spanMsg"></span>
                               
						</div>
					</div>
				</div>
                                    

                                    <div class="span3 push10 lister phone-block">
						<p class="primary long phone-block">Our Stores</p>
					<p class="secondary push20">Address</p>
					<p class="push10"> 42 West 48th St. Suite 1603,</p>
					<p>New York,</p>
					<p>NY 10036 </p>
			
				
					<p class="secondary push20">Call Us Now</p>
					<p class="push10">USA (NY): 212.840.1811</p>


                  <p class="secondary push20">  Leave a message</p>

<p class="push10">Drop in a voice message on our office numbers and we will call you back.</p>
                    <p class="secondary push20">Email Us</p>
					<p>Mail us your queries or complaints and we will revert back to you within two business days.</p>
					
					<p class="push10">info@fascinatingdiamonds.com</p>

                    <p class="secondary push20">Chat Now </p>

                  <p>  Chat with us and get the answer to your questions instantly.</p>

                  <p class="push10">Chat Now</p>
					
				</div>
                                </div>
        </div>
        </div>
        </div>   
        
        <div class="span12 push20"></div>
         </div>
   


    <% if (_DEF_CENTER_STONE_ID > 0)
       { %>
        <!---- CSS for JQUERY Range Slider -->
    <link href="/assets/controls/jquery_ui/css/smoothness/jquery-ui-1.10.3.custom.min.css"
        rel="stylesheet" type="text/css" />
    <!---- PLUGIN for JQUERY Range Slider -->
    <script src="/assets/controls/jquery_ui/js/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="/assets/themes/js/extra/loose_diamond.js" type="text/javascript"></script>

    <script type="text/javascript">
        var FIRST_TIME_LOAD = true;
        var PER_PAGE=10;
        var CURRENT_PAGE=0;
        var minCarat=<%= _MINCARAT %>;var maxCarat=<%= _MAXCARAT %>;
        var minPrice=<%= _MINPRICE %>;var maxPrice=<%= _MAXPRICE %>;

        $(document).ready(function () {
        //for carat slider
            $("#carat-slider").slider({
                range: true,
                min: <%= _MINCARAT %>,
                max: <%= _MAXCARAT %>,
                values: [<%= _MINCARAT %>, <%= _MAXCARAT %>],
                step:0.01,
                stop: function (event, ui) {
                    minCarat=parseFloat(ui.values[0]);
                    maxCarat=parseFloat(ui.values[1]);
                    do_fillter(true);
                },
                slide:function(event,ui){
                    $("#carat-range-1").text(ui.values[0]);
                    $("#carat-range-2").text(ui.values[1]);
                }

            });

            //Price slider
            $("#price-slider").slider({
                range: true,
                min: <%= _MINPRICE %>,
                max: <%= _MAXPRICE %>,
                values: [<%= _MINPRICE %>, <%= _MAXPRICE %>],
                step:1,
                slide: function (event, ui) {
                    $("#price-range-1").text("$" + ui.values[0]);
                    $("#price-range-2").text("$" + ui.values[1]);
                },
                stop:function (event, ui) {
                    minPrice=parseFloat(ui.values[0]);
                    maxPrice=parseFloat(ui.values[1]);
                    do_fillter(true);
                }
            });

       //fire after active & in active event
       $("i").on('active', function () {
                do_fillter(true);
            });

       $("i").on('inactive', function () {
                do_fillter(true);
            });

            //for page size
            $("#ddlPerpage").change(function()
            {
                PER_PAGE=parseInt($(this).val());
                do_fillter(true);
            });
            //load the init data
            do_fillter(true);
    });
        //should be define
        function getPagingOption() {
    var opt = { callback: pagingCallback };
    opt['items_per_page'] = PER_PAGE;
    opt['num_display_entries'] = 5;
    opt['num_edge_entries'] = 2;
    return opt;
    }
        //paging call back
        function pagingCallback(page_index, jq) {
        // Get number of elements per pagionation page from form
        CURRENT_PAGE = page_index;
        do_fillter(false);
    }

        //custom function
        function get_selected_element(formated_id, data_id_attribute) {
            var content_object = $("#" + formated_id + " i.selected");
            var selected_data = [];
            $.each(content_object, function (index, value) {
                selected_data.push(value.getAttribute(data_id_attribute));
            });
            return selected_data;
        }
        //for fillter
        function do_fillter(status) {
            //paging varibales
            FIRST_TIME_LOAD=status;
            //get cut
            var cuts = get_selected_element("cut-wrap", "data-id");
            var color = get_selected_element("color-wrap", "data-id");
            var clarity = get_selected_element("clarity-wrap", "data-id");
            var shape = get_selected_element("shape-wrap", "data-id");
            load_center_stone("tblLooseDiamondData", shape.join(','), cuts.join(','), color.join(','), clarity.join(','), minPrice, maxPrice, minCarat, maxCarat,CURRENT_PAGE,PER_PAGE);
        }

</script>
    <%} %>
    <script src="/assets/themes/js/extra/loose_diamond.js" type="text/javascript"></script>
    <!--For Photo-->
    <script type="text/javascript">
        //get default details of the product
        var productSKU = "<%= _SKU %>";
        var PRODUCT_INIT_PRICE=<%= _INITIAL_PRICE %>
        var METAL_PRICE=0;
        var CENTER_STONE_PRICE=<%= _CENTER_STONE_PRICE %>
        var SIDE_STONE_PRICE=0;
        var METAL_TYPE_ID = <%=_DEF_METAL_TYPE_ID %>;
        var CENTER_STONE_ID=<%= _DEF_CENTER_STONE_ID %>;
        var CENTER_STONE_SKU="<%= _CENTER_STONE_SKU %>";
        var CENTER_STONE_SHAPE_ID=<%= _DEF_CENTER_STONE_SHAPE_ID %>;
        var SIDE_STONE_ID=<%= _DEF_SIDE_STONE_ID %>;
        var MATCHING_BAND_SIDE_STONE_ID=<%= _DEF_MATCHING_BAND_SIDE_STONE_ID %>;
        var SIDE_STONE_CATEGORY_ID=<%= _DEF_SIDE_STONE_CATEGORY_ID %>;
        var IMAGE_GUID="<%= _DEF_IMAGE_GUID %>";
        //decalre varibale for options
        $(document).ready(function () {
        //lazy loading
        $("img.lazy").lazyload({ effect: "fadeIn"});
        //for i event
            $("i").click(function()
            {
                //get associated data atribute
                var data_event=this.getAttribute('data-event');
                if(data_event==null)
                {
                    return;
                }
                switch(data_event)
                {
                    case 'metal':
                    {
                        //get name of the metal
                        var name=this.getAttribute('data-metal-name');
                        var id=parseInt(this.getAttribute('data-metal-id'));
                        var css=this.getAttribute('data-metal-css');
                        //set the value of the
                        METAL_TYPE_ID=id;
                        //set the label data of metal type
                        $("#spanMetal").html(name);
                        //set sub heading name
                        $("#sub_default_metal_select").html(name);
                        $("#default_metal_select").removeClass();
                        $("#default_metal_select").addClass(css+" span2");
                        //call the service
                        set_price();
                        //get the fresh image
                        refreshImage();
                    }
                    break;
                    case 'centerstone':
                    {
                        //for center stone
                        //get name of the metal
                        var name=this.getAttribute('data-centerstone-name');
                        var id=parseInt(this.getAttribute('data-centerstone-id'));
                        var css=this.getAttribute('data-centerstone-css');
                        //
                        CENTER_STONE_SHAPE_ID=id;
                        //set sub heading name
                        $("#sub_default_centerstone_select").html(name);
                        $("#default_centerstone_select").removeClass();
                        $("#default_centerstone_select").addClass(css+" span2");
                        //call the service
                        //select the button groups
                        var content_object = $("#shape-wrap i");
                        $.each(content_object, function (index, value) {
                        var data_id=value.getAttribute("data-id");
                        if(id==parseInt(data_id))
                        {
                            //select the style
                            value.setAttribute('class','icon-shape-large-'+name.toLowerCase()+' selected');
                        }
                        else
                        {
                            //remove the style
                            //value.setAttribute('class','icon-shape-large-'+name.toLowerCase()+'');
                        }
                        });
                        do_fillter(true);
                        //get the fresh image
                        refreshImage();
                        //go after 3 second
                        setTimeout(goto_center_stone,3000);
                    }break;
                    case 'sidestone':
                    {
                        //get name of the metal
                        var name=this.getAttribute('data-sidestone-name');
                        var id=parseInt(this.getAttribute('data-sidestone-id'));
                        var css=this.getAttribute('data-sidestone-css');
                        var stone_category_id=parseInt(this.getAttribute('data-stone-category'));
                        //set the value of the
                        SIDE_STONE_ID=id;
                        SIDE_STONE_CATEGORY_ID=stone_category_id;
                        //call the service
                        set_price();
                        //show the side stone gem stone details
                        side_stone_gem_stone_details(id);
                        //show the side stone info
                        if(SIDE_STONE_ID>0)
                        {
                            //1 for side stone
                            side_stone_gem_stone_details(SIDE_STONE_ID,'panSideStone',1);
                        }
                        if(MATCHING_BAND_SIDE_STONE_ID>0)
                        {
                            //2 for matching band
                            side_stone_gem_stone_details(SIDE_STONE_ID,'panMatchingBand',2);
                        }
                        $("#sub_default_sidestone_select").html(name);
                        $("#default_sidestone_select").removeClass();
                        $("#default_sidestone_select").addClass(css+" span2");
                        //get the fresh image
                        refreshImage();
                    }
                    break;
                }
            });

            //show the side stone info
            if(SIDE_STONE_ID>0)
            {
                //1 for side stone
                side_stone_gem_stone_details(SIDE_STONE_ID,'panSideStone',1);
            }
            if(MATCHING_BAND_SIDE_STONE_ID>0)
            {
                //2 for matching band
                side_stone_gem_stone_details(MATCHING_BAND_SIDE_STONE_ID,'panMatchingBand',2);
            }
        });
        //got to center stone on click
        function goto_center_stone(){
            $('html, body').animate({'scrollTop':$("#tabProduct").offset().top}, 'slow');
        }
        //refresh image
        function refreshImage(){
            var total_image_angles=<%= _TOTAL_IMAGE %>;
            //input METAL_TYPE_ID,CENTER_STONE_SHAPE_ID,SIDE_STONE_ID
            //create a combination image
            //access the image from the handler
            if(total_image_angles>0)
            {
                for(var i=1;i<=total_image_angles;i++)
                {
                    var GUID=productSKU+"-"+METAL_TYPE_ID+"-"+CENTER_STONE_SHAPE_ID;
                    if(SIDE_STONE_CATEGORY_ID==1)
                    {
                        //for diamond case
                        GUID+="-0";
                    }
                    else
                    {
                        //for gemstone case
                        GUID+="-"+SIDE_STONE_ID;
                    }
                    GUID+="-A"+i;
                    if(i==1)
                    {
                        //set the default image
                        IMAGE_GUID=GUID;
                    }
                    var COMBINE_URL="/Handler/ImageManager.ashx?GUID="+GUID;
                    //console.log(COMBINE_URL);
                    //set the image url of the side image
                    document.getElementById("imgSideThumb_"+i+"").src=COMBINE_URL+"&height=120";
                    if(i==1)
                    {
                        //set the center image as first image
                        document.getElementById("centerImage").src=COMBINE_URL+"&height=470";
                    }
                }
            }
        }
        //show side stone info
        function side_stone_gem_stone_details(side_stone_id,control_id,pageNameId){
            $("#"+control_id).empty();
            //
            try {
                $.ajax({
                    type: "POST",
                    async: true,
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/Service.asmx/GetSideStoneInfo",
                    data: "{SKU:"+JSON.stringify(productSKU)+",sideStoneId:"+side_stone_id+",pageNameId:"+pageNameId+"}",
                    dataType: "json",
                    success: function (successData) {
                        $("#"+control_id).html(successData.d);
                    },
                    error: function (errorData) {
                    }
                });
            }
            catch (e) {
                alert(e);
            }
        }
        //set the price of the product
        function set_price() {
            try {
                //console.log(SIDE_STONE_ID);
                $.ajax({
                    type: "POST",
                    async: false,
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/Service.asmx/GetProductCustomizeProductPrice",
                    data: "{SKU:" + JSON.stringify(productSKU) + ",metal_type_id:" +
METAL_TYPE_ID + ",center_stone_sku:" + JSON.stringify(CENTER_STONE_SKU) + ",side_stone_id:" +
SIDE_STONE_ID + "}",
                    dataType: "json",
                    success: function (successData) {
                        if (successData.d != null) {
                            var data =parseFloat(successData.d);
                            if (!isNaN(data) && data>=0) {
                                /*var splt = data.split(',');
                                METAL_PRICE = parseFloat(splt[0]);
                                CENTER_STONE_PRICE=parseFloat(splt[1]);
                                SIDE_STONE_PRICE = parseFloat(splt[2]);
                                //show the price in the price box
                                //console.log(METAL_PRICE+"-"+CENTER_STONE_PRICE+"-"+SIDE_STONE_PRICE);
                                var total_price = METAL_PRICE + CENTER_STONE_PRICE +SIDE_STONE_PRICE;*/
                                $("#price_tag").html('$' + data);
                            }
                        }
                    },
                    error: function (errorData) {
                    }
                });
            }
            catch (e) {
                alert(e);
            }
        }
        //center stone row mouse over
        function on_center_stone_row_mouse_hover (SKU,row){
            $("#loose_diamond_overview").empty();
            //get the center details from the center stone table
            var model=get_sku_from_list(CENTER_STONE_OBJECT,SKU);
            if(model==false)
            {
             return;
            }
             //append the data in the popup
                show_diamond_details_on_right(model);
        }
        //compare row
        function on_center_stone_compare_row_mouse_hover(SKU,row){
            $("#loose_diamond_overview").empty();
            //get the center details from the center stone table
            var model=get_sku_from_list(CENTER_STONE_COMPARE_OBJECT,SKU);
            if(model==false)
            {
             return;
            }
             //append the data in the popup
             show_diamond_details_on_right(model);
        }
        //show diamond on right
        function show_diamond_details_on_right(model){
                var area=$("#loose_diamond_overview");
                //SKU
                area.append("<b>SKU :</b> "+model.SKU);
                //depth
                area.append("<br/><b>Depth : </b>"+model.CertificateDepth+" %");
                //table
                area.append("<br/><b>Table : </b>"+model.CertificateTable+" %");
                //gridle
                area.append("<br/><b>Gridle : </b>"+model.CertificateGridle);
                //Symmetry
                area.append("<br/><b>Symmetry : </b>"+model.CertificateSymmetry);
                //Polish
                area.append("<br/><b>Polish : </b>"+model.CertificatePolish);
                //Culet
                area.append("<br/><b>Culet : </b>"+model.CertificateCulet);
                //Fluorescence
                area.append("<br/><b>Fluorescence : </b>"+model.CertificateFlouresence);
                //Measurements
                area.append("<br/><b>Measurements : </b>"+model.CertificateMeasurement+" mm.");
                //Price
                area.append("<br/><b>Price : </b>"+model.StonePrice);
                //add add to setting
                area.append("<br/><b><a href='javascript:void(0)' onclick='add_to_setting(\""+model.SKU+"\")'>Add To Ring</a></b>");
        }
        //add to setting
        function add_to_setting(SKU){
            $("#loose_diamond_overview").empty();
            //get sku info
            var model=get_sku_from_list(CENTER_STONE_OBJECT,SKU);
            if(model==false)
            {
                return;
            }
            //change the detais of the center Stone
            //show the details
            show_center_stone_details("tblCenterStoneDetails",model);
            //change the sku
            CENTER_STONE_SKU=model.SKU;
            //set price
            set_price();
            //scroll to up 
            $('html, body').animate({'scrollTop':$("#prod-customize").offset().top}, 'slow');
        }
        //
        function add_to_cart(btn){
              try {
                btn.setAttribute('disabled','disabled');
                //console.log(SIDE_STONE_ID);
                $.ajax({
                    type: "POST",
                    async: false,
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    url: "/Services/Service.asmx/AddToCart",
                    data: "{ProductSKU:" + JSON.stringify(productSKU) + ",metalTypeId:" +
METAL_TYPE_ID + ",CenterStoneSKU:" + JSON.stringify(CENTER_STONE_SKU) + ",sideStoneId:" +
SIDE_STONE_ID + ",imageGUID:"+JSON.stringify(IMAGE_GUID)+"}",
                    dataType: "json",
                    success: function (successData) {
                        if (successData.d != null) {
                            var data =parseInt(successData.d);
                            if (data==1) {
                                location.href="/cart";
                            }
                            else
                            {
                                
                            }
                        }
                    },
                    error: function (errorData) {
                    }
                });
            }
            catch (e) {
                alert(e);
            }
        }
    </script>
</asp:Content>

