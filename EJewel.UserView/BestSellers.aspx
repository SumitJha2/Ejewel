<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BestSellers.aspx.cs" Inherits="EJewel.UserView.BestSellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/assets/themes/css/app.css" rel="stylesheet" type="text/css" />
    <script src="/assets/themes/bootstrap/js/jquery.carouFredSel-6.2.1-packed.js" type="text/javascript"></script>
    <!--custom slideshow-->
    <script>
        $(function ()
         {
            $('#thumbs').carouFredSel({
                synchronise: ['#images', false, true],
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
                prev: '#prev',
                next: '#next'
            });

            $('#images').carouFredSel({
                auto: false,
                items: 1,
                scroll: {
                    fx: 'fade'
                }
            });

            $('#thumbs img').click(function () {
                $('#thumbs').trigger('slideTo', [this, -1]);
            });
            $('#thumbs img:eq(1)').addClass('selected');
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container push-below-header">


    <section id="product">
        <div class="container  clearfix">
            <div class="row-fluid">
                <section id="prod-detail" class="span9">
                    <div class="row-fluid">
                        <div class="page-header clearfix">
                            <h3 class="span9">Alyssa Ring</h3>
                            <h4 class="span3 text-right">$592</h4>
                        </div>                        
                    </div>

                    <div class="row-fluid">
                        <div id="prod-angle-wrap" class="span2">
                            <span id="prev">prev</span>
                            <div id="thumbs">
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(1).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(2).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(3).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(4).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(5).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire%20(6).jpg" />
                                <img src="img/prod_thumbs/14k-white-gold-ring-with-pink-sapphire.jpg" />
			                </div>
			                <span id="next">next</span>
                        </div>

                        <div id="prod-img" class="span8 offset2">
                            <div id="images">
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(1).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(2).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(3).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(4).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(5).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire%20(6).jpg" />
                                <img src="img/prod/14k-white-gold-ring-with-pink-sapphire.jpg" />
			                </div>
                        </div>
                    </div>
                </section>
                <aside id="sidebar" class="span3">
                    <div id="prod-customize">
                        <h5 class="hdr well-small">Customize</h5>                
                        <div class="accordion" id="customize-wid">                    
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#customize-wid" href="#collapseOne">
                                        <div class="row-fluid">
                                            <span class="span10">Accent Stone 1 <span class="clearfix">Ruby</span> </span>
                                            <i class="swatch-stone-1 span2"></i>
                                        </div>                                    
                                    </a>
                                </div>
                                <div id="collapseOne" class="accordion-body collapse ">
                                    <div class="accordion-inner">
                                        <div class="row-fluid well-small">
                                            <i class="swatch-stone-1">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-2">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i> 
                                        </div> 
                                        <div class="row-fluid clearfix">
                                            <button class="btn btn-small">Cancel</button>
                                            <button class="btn btn-small btn-primary pull-right">Continue</button>
                                        </div>                                                                                                             
                                    </div>
                                </div>
                            </div>
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#customize-wid" href="#collapseTwo">
                                        <div class="row-fluid">
                                            <span class="span10">Accent Stone 2 <span class="clearfix">Sapphire</span> </span>
                                            <i class="swatch-stone-1 span2"></i>
                                        </div>  
                                    </a>
                                </div>
                                <div id="collapseTwo" class="accordion-body collapse">
                                    <div class="accordion-inner">
                                        <div class="row-fluid well-small">
                                            <i class="swatch-stone-1">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-2">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i>
                                            <i class="swatch-stone-3">ssss</i><i class="swatch-stone-3">ssss</i> 
                                        </div> 
                                        <div class="row-fluid clearfix">
                                            <button class="btn btn-small">Cancel</button>
                                            <button class="btn btn-small btn-primary pull-right">Continue</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                       
                        </div>
                    </div>                
                    <div id="description">
                        <h5>Pear Amethyst 14K White Gold Ring with Diamond</h5>
                        <p>like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy. like one perfect tier of joy.</p>
                    </div>    
                    <a href="#myModal" role="button" data-toggle="modal" class="btn btn-inverse btn-block" > SELECT THIS RING</a>
                    
                    <button class="btn btn-block" > <i class="icon-heart"></i> ADD TO WISH LIST</button>
                    <!-- Modal -->
                    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                            <h3 id="myModalLabel">What would you like to do?</h3>
                        </div>
                        <div class="modal-body ">
                            <ul class="thumbnails">
                                <li class="span6">
                                    <a class="btn btn-inverse thumbnail">ADD A DIAMOND</a>
                                </li>
                                <li class="span6">
                                    <a class="btn btn-inverse thumbnail"></i>PURCHASE SETTING ONLY</a>
                                </li>
                                <li class="span11">
                                    <a class="btn btn-inverse  btn-block thumbnail"><i class="icon-shopping-cart icon-white"></i>ADD TO CART</a>
                                </li>                               
                            </ul>
                        </div>
                    </div>

                </aside>
            </div>
        </div>
    </section>

    <section id="overview">
        <div class="container clearfix"><br /><br />
            <div class="row-fluid">
                <div id="tabs-wrap" class="span12 well-small tabbable">
                    <ul class="nav nav-tabs">
                      <li class="active"><a href="#tab1" data-toggle="tab">OVERVIEW</a></li>
                      <li><a href="#tab2" data-toggle="tab">THE DETAILS</a></li>
                      <li><a href="#tab3" data-toggle="tab">REVIEWS</a></li>
                        <li><a href="#tab4" data-toggle="tab">THE FASINATING DIAMONDS</a></li>
                        <li><a href="#tab5" data-toggle="tab">QUESTIONS</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active well-small fade in" id="tab1">
                          <p>OVERVIEW</p>
                        </div>
                        <div class="tab-pane well-small fade in" id="tab2">
                          <p>THE DETAILS</p>
                        </div>
                        <div class="tab-pane well-small fade in" id="tab3">
                          <p>REVIEWS</p>
                        </div>
                        <div class="tab-pane well-small fade in" id="tab4">
                          <p>THE FASINATING DIAMONDS</p>
                        </div>
                        <div class="tab-pane well-small fade in" id="tab5">
                          <p>Questions</p>
                        </div>
                  </div>
                </div>
            </div>
        </div>

</div>
       

    </section>
</asp:Content>
