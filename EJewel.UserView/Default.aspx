<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EJewel.UserView.Default" %>

<%@ Register src="~/controls/MenuControls.ascx" TagName="MenuControls" tagprefix="uc1" %>
<%@ Register Src="~/controls/LoginContainer.ascx" TagName="LoginControls" TagPrefix="uc2" %>
<%@ Register Src="~/controls/FooterControl.ascx" TagName="FooterControls" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta charset="UTF-8" />

		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />

        <title>Heart Shaped Diamond Engagement Rings | Affordable Loose Diamonds Engagement Rings | Princess Cut Wedding Rings | Fascinating Diamonds</title>

          <link href='http://fonts.googleapis.com/css?family=Cinzel+Decorative' rel='stylesheet' type='text/css'>
 <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet' type='text/css'>
        <script src="/assets/themes/js/jquery-1.9.1.min.js" type="text/javascript"></script>
        <link href="~/assets/themes/css/bootstrap.min.css" rel="stylesheet" />
		<link href="~/assets/themes/css/style.css" rel="stylesheet" />
        <script src="/assets/themes/js/jquery.cycle.all.js" type="text/javascript"></script>
		<!--[if lt IE 9]><link rel="stylesheet" type="text/css" href="/assets/themes/css/ie8.css" /><![endif]-->
</head>
<body>
    <form id="form1" runat="server">
  
  <%--Start: This is the login control. All Login / Membership activities starts here.--%>
    <uc2:LoginControls ID="MenuControls2" runat="server" />
    <%--End: This is the login control. All Login / Membership activities starts here.--%>
		<div class="slider-container">


			<div class="top-slider">
				<div class="s1 focus first" id="1"></div>
				<div class="s2 hidden" id="2"></div>
                <div class="s3 hidden" id="3"></div>
				<div class="s4 hidden last" id="4"></div>
			</div>
			<div class="diagonal-holder">
				<div class="slider-diagonal-overflow">
					<div class="slider-diagonal rotate45"></div>
				</div>
			</div>


			<div class="container">
            <%--Start: This is the menu control. --%>
				  <uc1:MenuControls ID="MenuControls1" runat="server" />
              <%--End: This is the menu control. --%>
				<div class="row">
					<div class="span5 offset6 slider-elements-holder">
						<div class="slider-elements cfocus cfirst" id="c1">
							<p class="uber-text" >
								She’ll Surely Love The fact that it is Custom Made Only for Her
							</p>
							<a href="/product/engagement-rings" class="uber-more">Find the Perfect Design &gt; </a>
						</div>
						<div class="slider-elements hidden" id="c2">
							<p class="uber-text" style="color:#5A5A5A;">
								The Most Extensive and Exclusive Range of Bridal Jewelry
							</p>
							<a href="/product/wedding" class="uber-more">Browse Wedding Sets &gt; </a>
						</div>


                        <div class="slider-elements hidden" id="c3">
							<p class="uber-text" >
								Diamonds  Specially Hand-cut to exceptional Standard
							</p>
							<a href="/diamond" class="uber-more">Choose the Best Diamond &gt; </a>
						</div>



						<div class="slider-elements hidden clast" id="c4">
							<p class="uber-text" style="color:#F1F1F1;">
								 Your thoughts are fabricated with our craft to design a ring
							</p>
							<a href="/custom-ring-design" class="uber-more">Design a Custom Ring &gt; </a>
						</div>


					</div>
				</div>

				<div class="row push30">
					<div class="span2 offset10">
						<ul id="slider-nav" style="display:none;">
							<li><a href="#"   class="t1 focused">
                            
                              1
                            
                            </a> /</li>
							<li><a href="#"  class="t2"> 2</a> /</li>
							<li><a href="#" class="t3"> 3</a> /</li>
                            <li><a href="#" class="t4"> 4</a></li>
						</ul>
					</div>
				</div>

				<div class="row">
					<div class="span3 slider-tile">
						<a href="/RecentlySold.aspx" class="slider-tile-thumb" id="slider-tile-thumb-1">thumb</a>
						<a href="/RecentlySold.aspx" class="slider-tile-heading">Recently Sold</a>
						<p>Explore from the array of diamond rings recently sold to our customers.!</p>
					</div>
					<div class="span3 slider-tile">
						<a href="/BestSellers.aspx" class="slider-tile-thumb" id="slider-tile-thumb-2">thumb</a>
						<a href="/BestSellers.aspx" class="slider-tile-heading">Best Sellers</a>
						<p>Showcasing our best selling and breathtaking beauties.!</p>
					</div>
					<div class="span3 slider-tile">
						<a href="/product/browse/all?new-arrival=yes" class="slider-tile-thumb" id="slider-tile-thumb-3">thumb</a>
						<a href="/product/browse/all?new-arrival=yes" class="slider-tile-heading">New Arrival</a>
						<p>Click and see what’s new in store for you this season.!</p>
					</div>
					<div class="span3 slider-tile">
						<a href="/GiftIdeas.aspx" class="slider-tile-thumb" id="slider-tile-thumb-4">thumb</a>
						<a href="/GiftIdeas.aspx" class="slider-tile-heading">Gift Ideas</a>
						<p>Fresh and fascinating  gifting ideas just a click away.!</p>
					</div>
				</div>
			</div><!-- end container -->
		</div>
        <!-- end slider container -->

		<!-- end container -->


		
         <uc3:FooterControls ID="FooterControls1" runat="server" />
        
        <!-- end footer-container -->
    <script type="text/javascript" src="/assets/themes/js/jquery.easing.min.js" ></script>

		<script type="text/javascript" src="/assets/themes/js/respond.min.js"></script>
		<script type="text/javascript" src="/assets/themes/js/hover.intent.js"></script>
		<script type="text/javascript" src="/assets/themes/js/header.js"></script>
		<script type="text/javascript" src="/assets/themes/js/slider.js"></script>
		<script type="text/javascript" src="/assets/themes/js/utils.js"></script>

        <script type="text/javascript">
            $(function () {
                $("#call-email ul").cycle({ fx: "scrollVert", speed: 500, timeout: 3000, easing: "linear", pause: 1 });
            });
    </script>
    </form>
</body>
</html>
