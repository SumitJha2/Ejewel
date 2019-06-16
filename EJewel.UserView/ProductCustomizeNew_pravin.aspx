<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCustomizeNew_pravin.aspx.cs" Inherits="EJewel.UserView.ProductCustomizeNew_pravin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
.page-header{padding-bottom:0;}
#images-fd{ width:400px; height:400px; left:0px!important;}
#thumbs-fd img {
				border: 0px solid #c9c9c9;
				padding: 0px;
				margin: 10px 0px 5px 0px;
				cursor: pointer;
                box-sizing:border-box;
                width:120px;
                height:120px;
			}
#thumbs-fd img.selected, #thumbs-fd img:hover {border:1px solid #888;}
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
background: #fff url('../img/next-prev.png') 50% 0 no-repeat;
width: 122px;
height: 12px;
display: block;
cursor: pointer;
}
#prev-fd{margin-bottom:3px;}
#prev-fd:hover{background-position: 50% -24px;}

#next-fd{background-position: 50% -12px; margin-top:3px;}
#next-fd:hover{background-position: 50% -36px;}

    /*******************customize widget*************************/
    #prod-customize .hdr{ background:#888; color:#fff; font-weight:normal; padding:8px 5px;}

    #customize-list{ border:1px solid #ddd; margin:0; padding:0; margin-top:-20px; box-sizing:border-box;}
    #customize-list .customize-item {margin:0px  0px; padding: 0px 3px; position:relative;}
    #customize-list .customize-item:hover .customize-item-heading dl{background-color:#b4e4fc;}
    .customize-item-heading:hover{cursor:pointer;}
    .customize-item-heading dl{ margin:3px; padding:5px;  border:1px solid #DDD;}
    .customize-item-heading dt, .customize-item-heading dd{display:inline-block;}
    .customize-item-heading dd{float:right; margin-right:1px;}
    .customize-item-heading span[class^='title']{display:block;}
    .customize-item-heading .title1{ text-transform:uppercase;}
    .customize-item-description{display:none; padding: 5px 3px; position:relative;}
    .customize-item-description .swatch-wrap{margin:10px;}
    .customize-item-description .item-details{ outline:1px solid #ddd; min-height:50px; margin:10px; padding:4px;}

    /******************* swatches *************************/

        i[class^="swatch-stone-"] { 
            background :url('img/swatches.png') no-repeat;
            display:inline-block; 
            height: 36px;
            width: 36px;
            text-indent:-999999px;
            margin: 0px 0px 0px 1px;            
            border: 3px solid transparent;
            line-height:10px;
            vertical-align:middle;
            text-align:center;
            -moz-border-radius:20px;
            -moz-border-radius:20px;
            -webkit-border-radius:20px;     
            background-position: 3px -825px;        
        }
        
        i.swatch-stone-diamond{background-position: 3px -501px;}
        i.swatch-stone-ruby{background-position: 3px -825px;}
        i.swatch-stone-emerald{background-position: 3px -682px;}

        i[class^="swatch-stone-"]:hover{ border:3px solid #ddd;}


    /************************* Buttons************************/    
    .btn {
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
    .btn[type='button']:hover{background-color:#d9d4d4;}

    /******************************** General *************************************/
    .pull-right{float:right;}

    </style>

    <script src="/assets/themes/js/tabcontent.js" type="text/javascript"></script>
    <link href="/assets/themes/tabs/tabcontent.css" rel="stylesheet" />
    
    <script src="/assets/themes/js/jquery.carouFredSel-6.2.1-packed.js"></script>
    
    <!--custom slideshow-->
    <script>
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
                scroll: {
                    onBefore: function (data) {
                        data.items.old.eq(1).removeClass('selected');
                        data.items.visible.eq(1).addClass('selected');
                    },
                    items: 1

                },
                prev: '#prev-fd',
                next: '#next-fd'
            });

            $('#images-fd').carouFredSel({
                auto: false,
                width: 400, height: 400,
                items:1,
                scroll: {
                    fx: 'fade'
                }
            });

            $('#thumbs-fd img').click(function () {
                $('#thumbs-fd').trigger('slideTo', [this, -1]);
            });
            $('#thumbs-fd img:eq(1)').addClass('selected');
        });

        /********* Customize Widget *************************/
        $(function () {
            $('#customize-list .customize-item').each(function () {
                $('.customize-item').on('click', '.customize-item-heading', function (e) {
                    $(this).parent().siblings().slideToggle('fast');
                    $('.customize-item-description').stop().slideToggle('fast');
                }).on('click', '.btn', function (e) {
                    e.preventDefault();
                    $(this).parent().parent().slideUp();
                    console.log($(this).parent());
                });

                $('i[class^="swatch-stone"]',$(this)).on('mouseover mouseout click', function (e) {
                    if (e.type === 'mouseover') {
                        $(".item-details").text($(this).text());                        
                    }
                    if (e.type === 'mouseout') {
                        $(".item-details").text($("#sel-stone-name").text());
                    }
                    if (e.type === 'click') {
                        $(".sel-stone-name").text($(this).text());                        
                        $(".sel-stone-img").addClass($(this).attr('class'));                        
                    }                    
                });

            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container push-below-header">
        <div class="row push40">
            <div class="span12">
                <div class="row">
                    <div class="span8 phone-full-width">
                        <div class="row-fluid">
                            <div class="page-header-fd clearfix">
                                <h3 class="span9">Pear Amethyst 14K White Gold Ring with Diamond</h3>
                                <h4 class="span3 text-right">$592</h4>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div id="prod-angle-wrap-fd" class="span2">
                                <span id="prev-fd">prev</span>
                                <div id="thumbs-fd">
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(1).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(2).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(3).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(4).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(5).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(6).jpg" runat="server" />
                                    <img src="~/img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire.jpg" runat="server" />
                                </div>
                                <span id="next-fd">next</span>
                            </div>

                            <div id="prod-img-fd" class="span8 offset2">
                                <div id="images-fd">
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(1).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(2).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(3).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(4).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(5).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire%20(6).jpg"  runat="server"/>
                                    <img src="~/img/prod/14k-white-gold-ring-with-pink-sapphire.jpg"  runat="server"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="span3 offset1">
                        <div id="prod-customize">
                            <h5 class="hdr">Customize</h5>   
                            <ul id="customize-list">
                                <li class="customize-item">
                                    <div class="customize-item-heading"> 
                                        <dl>
                                            <dt> 
                                                <span class="title1">Accent Stone 1</span>  
                                                <span id="" class="title2 sel-stone-name">Ruby</span>
                                            </dt>
                                            <dd> <i id="" class="swatch-stone-1 sel-stone-img">ssss</i> </dd>
                                        </dl>                                        
                                    </div>
                                    <div class="customize-item-description">
                                        <p class="item-details"></p>
                                        <div class="swatch-wrap">
                                            <i class="swatch-stone-diamond" >diamond</i> <i class="swatch-stone-ruby">Ruby</i> <i class="swatch-stone-emerald">Emerald</i>
                                            <i class="swatch-stone-4"></i> <i class="swatch-stone-4">ssss</i> <i class="swatch-stone-6">ssss</i>
                                            <i class="swatch-stone-7"></i> <i class="swatch-stone-8">ssss</i> <i class="swatch-stone-9">ssss</i>
                                            <i class="swatch-stone-10">ssss</i> <i class="swatch-stone-11">ssss</i> <i class="swatch-stone-12">ssss</i>
                                        </div>
                                        <div class="row-fluid">
                                            <button class="btn">Cancel</button>
                                            <button class="btn pull-right">Continue</button>
                                        </div>
                                    </div>
                                </li>
                                <li class="customize-item">
                                    <div class="customize-item-heading"> 
                                        <dl>
                                            <dt> 
                                                <span class="title1">Accent Stone 2</span>  
                                                <span class="title2">Saphire</span>
                                            </dt>
                                            <dd> <i class="swatch-stone-1">ssss</i> </dd>
                                        </dl>                                        
                                    </div>
                                    <div class="customize-item-description">
                                        description 2
                                    </div>
                                </li>
                                <li class="customize-item">
                                    <div class="customize-item-heading"> 
                                        <dl>
                                            <dt> 
                                                <span class="title1">Accent Stone 2</span>  
                                                <span class="title2">Saphire</span>
                                            </dt>
                                            <dd> <i class="swatch-stone-1">ssss</i> </dd>
                                        </dl>                                        
                                    </div>
                                    <div class="customize-item-description">
                                        Description 3
                                    </div>
                                </li>
                            </ul>
                        </div>        
                     

                        <div id="description">
                        <h5>Pear Amethyst 14K White Gold Ring with Diamond</h5>
                        <p>like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy.</p>
                    </div>    


                        <div class="row-fluid"><br />
                           
                            <button class=".btn span12"> Purchase Setting Only</button>

                            <button class=".btn span12"> Add to Cart</button>
                             <button class=".btn span12"> Add to Wishlist</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row push30">
           <div style="margin: 0 auto;font: 0.85em arial;">
        <ul class="tabs" persist="true">
            <li><a href="#" rel="view1">Persistence</a></li>
            <li><a href="#" rel="view2">Multiple</a></li>
            <li><a href="#" rel="view3">Bookmark Support</a></li>
            <li><a href="#" rel="view4">Outside Links</a></li>
        </ul>
        <div class="tabcontents">
            <div id="view1" class="tabcontent">
                <b>Persistence</b>
                <p>Setting &lt;ul class="tabs" <b>persist="ture"</b>&gt;...&lt;/ul&gt; will turn on the <strong>persistence</strong> feature: 
                the most recently clicked tab will be remembered even if the page is reloaded or revisited within the browser session. </p>
                <p style="font-size:small;"><span style="color:red;">Note:</span> If you open this page directly with physical path instead of from web app, you may not see this feature.</p>
                
            </div>
            <div id="view2" class="tabcontent">
                <b>Multiple Tab Contents</b>
                <p>You can have multiple tab contents on the same page, with only one copy of the CSS and JavaScript files.</p>
            </div>
            <div id="view3" class="tabcontent">
                <b>Bookmark Support</b>
                <p>You can also open a tab or a bookmark from a link anywhere on the page.</p>
                <p id="mark4">This is a paragraph with id="mark4".</p>
                <p>By clicking the bookmark link at the bottom of this Tab Content, you will see me with this Tab Content panel being opened at the same time.</p>
            </div>
            <div id="view4" class="tabcontent">
                <b>Opened by a link from another page</b>
                <p>Link from another page can select a tab on the target page when loaded.</p>                
            </div>
        </div>
        
    </div>

        </div>    
    </div>
</asp:Content>
