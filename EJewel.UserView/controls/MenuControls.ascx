<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControls.ascx.cs" Inherits="EJewel.UserView.controls.MenuControls" %>
<link href="/assets/themes/css/menu.css" rel="stylesheet" type="text/css" />
<style type="text/css">

#pscroller1{


}

#pscroller2{
width: 100%;
 height:20px;
 


}

#pscroller2 a{
text-decoration: none;
}

.someclass{ 
}

</style>


<style type="text/css">
        #call-email {
            font-weight: normal;
            width: 285px!important;
            overflow: hidden;
            color: #5A5A5A;
            font-size: 10pt;
            height: 20px;
            float: right;
            position: relative;
            top: 1px;
            text-align: right;
            white-space: nowrap;
            	font-family:'Cinzel Decorative',serif;
        }

            #call-email ul li {
                float: left;
                clear: both;
            }

            #call-email ul, #call-email ul li {
                margin: 0;
                list-style: none;
            }

            #call-email li.phone {
            background: url("/assets/themes/img/icon/Telephone.png") no-repeat center left;
                padding-left: 18px;
                padding-top: 0px;
            }

            #call-email li.emailto {
                background: url("/assets/themes/img/icon/mail.png") no-repeat center left;
                padding-left: 18px;
                padding-top: 0px;
            }
    </style>



   <!---------------------- Script for phone and email slider ------------------------------------------>
    <script type="text/javascript">
        $(function () {
            $("#call-email ul").cycle({ fx: "scrollVert", speed: 500, timeout: 3000, easing: "linear", pause: 1 });
        });
    </script>

<div class="row">
					<div class="span12">
						<div class="header">
							<div class="row">
								<div class="span3">
                                 
									<p class="login-s"><asp:Label ID="lblUserType" runat="server"></asp:Label></p>
								</div>
								<div class="span4 offset1 control-box">
									<div>
										<input type="text"  /><%-- placeholder="search..."--%>
										<a href="#" id="search">search</a>
										<a href="/cart" id="shopping-cart">Cart <asp:Literal ID="ltrlTotalItem" runat="server"></asp:Literal></a>
										<a href="#" id="wishlist">wishlist</a>
									</div>
								</div>
                               
								<div class="span3 offset1">
									<div class="top-options" >
                                   
                                    <div class="drop-down-scroll" id="currency-drop-down">
                                     <%--<a href="../Testimonials.aspx">Testimonial</a> --%>   
                                  </div>
										<div class="top-options-meta" >
                                      
                                        
											<%--<a href="../RegisterAccount.aspx">Signup</a><span>/</span>
											 <div class="login-p"><a href="#">login</a></div>--%>

                                             <div id="call-email">
                            <ul>
                                <li class="phone"> 212-840-1811 </li>
                                <li class="emailto">&nbsp;info@fasinatingdiamonds.com</li>
                            </ul>
                        </div>

                                         

										</div>

                           

                                         
										<%--<div class="drop-down" id="language-drop-down">
											<a href="#" class="language dd-active" id="english">British English</a>
											<a href="#" class="down-arrow rotate90">&gt;</a>
											<div class="none">
												<a href="#" class="language" id="us">try</a>
												<a href="#" class="language" id="de">try</a>
												<a href="#" class="language" id="fr">try</a>
											</div>
										</div>--%>
										<%--<div class="drop-down" id="currency-drop-down">
											<a href="#" class="currency dd-active">&pound;</a>
											<a href="#" class="down-arrow rotate90">&gt;</a>
											<div class="none">
												<a href="#" class="currency">$</a>
												<a href="#" class="currency">&euro;</a>
											</div>
										</div>--%>

                                       


									</div>
                                  



                                   








								</div>
							</div>

							<div class="row">
								<div class="span3">
									<a href="/Default.aspx" id="logo"></a>
								</div>


                                <div class="span8 offset1">
                                <ul id="menu">
    
    <li><a href="/diamond" class="drop">Diamonds</a><!-- Begin Home Item -->
    
        <div class="dropdown_2columns"><!-- Begin 2 columns container -->
    
            <div class="col_2">
                <h2>CUSTOMIZE YOUR OWN JEWELRY</h2>
            </div>


<table  cellpadding="3px" cellspacing="3px"><tr><td>

                                               
                                               <table style="font-family:Verdana;" cellpadding="3px" cellspacing="3px" >
                                               <tr>
                                               <td style="width:15px;">
                                               <img alt="Round" src="/assets/Diamond/round.png" />
                                               </td>
                                               <td align="left" style="padding-left:10px;">
                                               <a href="/diamond/round">Round</a>
                                               </td>
                                               </tr>
                                                       <tr>
                                                       <td style="width:15px;">
                                                       <img alt="Princess" src="/assets/Diamond/princess.png" />
                                                       </td>
                                                       <td  align="left" style="padding-left:10px;">
                                                       <a href="/diamond/princes" >Princes</a>
                                                       </td>
                                                       </tr>
                                                        <tr>
                                                        <td style="width:15px;">
                                                        <img alt="Emerald" src="/assets/Diamond/emerald.png" ></td>
                                                        <td  align="left" style="padding-left:10px;">
                                                        <a href="/diamond/emerald" >Emerald</a></td>
</tr><tr><td style="width:15px;"><img alt="Asscher" src="/assets/Diamond/asscher.png" /></td><td  align="left" style="padding-left:10px;"><a href="/diamond/asscher" >Asscher</a></td></tr><tr><td style="width:15px;"><img  alt="Oval" src="/assets/Diamond/ovel.png" /></td><td  align="left" style="padding-left:10px;"><a href="/diamond/oval" >Oval</a></td></tr></table>
														
													
                                                
                                                </td>
                                                
                                                <td style="padding-left:60px;">
                                                
                                                
                                           
                                                        <table cellpadding="3px" cellspacing="3px">
                                                        <tr><td style="width:15px;">
                                                        <img alt="Radiant" src="/assets/Diamond/radiant.png" /></td>
                                                        <td align="left" style="padding-left:10px;"><a href="/diamond/radiant">Radiant</a></td></tr>
                                                     <tr><td style="width:15px;"><img alt="Pear" src="/assets/Diamond/pear.png" /></td>
                                                         <td align="left" style="padding-left:10px;"><a href="/diamond/pear">Pear</a></td></tr>
                                                     <tr><td style="width:15px;"><img alt="Heart" src="/assets/Diamond/heart.png" /></td><td align="left" style="padding-left:10px;"><a href="/diamond/heart">Heart</a></td></tr>
                                                        <tr><td style="width:15px;"><img alt="Marquise" src="/assets/Diamond/marquse.png" /></td><td align="left" style="padding-left:10px;"><a href="/diamond/marquise">Marquise</a></td></tr>
                                                        <tr><td style="width:15px;"><img alt="Cushion" src="/assets/Diamond/cushion.png" /></td><td align="left" style="padding-left:10px;"><a href="/diamond/cushion">Cushion</a></td></tr>
                                                        </table>
                                                        
                                                        
                                                        
                                              
                                                </td>
                                                
                                                </tr></table>


    
            
          
        </div><!-- End 2 columns container -->
    
    </li><!-- End Home Item -->

   <li><a href="/product/engagement-rings" class="drop">Engagement Rings</a><!-- Begin Home Item -->
    
        <div class="dropdown_2columns"><!-- Begin 2 columns container -->


         <div class="col_2">
                <h2>CUSTOMIZE YOUR OWN RING</h2>
            </div>
    
           <table   cellpadding="3px" cellspacing="3px"><tr><td>


<table><tr><td>
                                               <table cellpadding="3px" cellspacing="3px" >
                                               <tr>
                                                <td><img width="26px" height="9px" alt="Solitaire Ring" src="/assets/Diamond/Solitaire_ring.png" /></td>
                                                <td align="left" style="padding-left:10px;"><a href="/product/engagement-rings/solitaire-ring">Solitaire Ring</a></td>
                                               </tr>
                                               <tr>
                                               <td><img width="26px" height="9px" alt="Three Stone Ring" src="/assets/Diamond/Three_Stone_Ring.png" /></td>
                                               <td align="left" style="padding-left:10px;"><a href="/product/engagement-rings/three-stone-ring">Three Stone Ring </a></td>
                                               </tr>
                                               <tr><td><img width="26px" height="9px" alt="Rings With Side Stone" src="/assets/Diamond/Ring_With_Side_Stone.png" /></td>
                                               <td align="left" style="padding-left:10px;"><a href="/product/engagement-rings/rings-with-side-stone">Rings With Side Stone</a></td>
                                               </tr>
                                               <tr>
                                               <td><img width="26px" height="9px" alt="Wedding Sets" src="/assets/Diamond/Wedding_Sets.png" /></td>
                                               <td  align="left" style="padding-left:10px;"><a href="/product/engagement-rings/wedding-sets">Wedding Sets </a></td>
                                               </tr>                            
                                               <tr>
                                               <td><img width="26px" height="9px" alt="Vintage Ring" src="/assets/Diamond/Vintage_Ring.png" /></td>
                                               <td  align="left" style="padding-left:10px;"><a href="/product/engagement-rings/vintage-ring">Vintage Ring </a></td>
                                               </tr>
                                               <tr>
                                               <td><img width="26px" height="9px"  alt="Halo Ring" src="/assets/Diamond/Halo_Ring.png" /></td>
                                               <td  align="left" style="padding-left:10px;"><a href="/product/engagement-rings/halo-ring">Halo Ring</a></td>
                                               </tr>
                                               </table>
                                                         
														
													
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table></td>
                                           
                                                
                                                
                                                
                                                
                                                </tr>
                                                
                </table>
                                                
                                               

	

                                             
            
          
        </div><!-- End 2 columns container -->
    
    </li><!-- End Home Item -->



     <li><a href="/product/wedding" class="drop">Wedding</a><!-- Begin Home Item -->
    
        <div class="dropdown_2columns"><!-- Begin 2 columns container -->
      <div class="col_2">
                <h2>CUSTOMIZE YOUR OWN</h2>
            </div>
          

                                                     <table cellpadding="3px" cellspacing="3px" ><tr><td>
                                             <table><tr><td ><img width="26px" height="9px" alt="Wedding Band" src="/assets/Diamond/Wedding_Band.png" /></td><td align="left" style="padding-left:10px;"><a href="/product/wedding/wedding-Band">Wedding Band </a></td></tr>
                                                       <tr><td><img width="26px" height="9px" alt="Eternity Band" src="/assets/Diamond/Eternity_Band.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/weeding/mens-gifts">Eternity Band </a></td>
                                                        </tr></table>
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table>


                                                     <table cellpadding="3px" cellspacing="3px" ><tr><td>
                                             <table><tr><td ><img width="26px" height="9px" alt="Men'S Wedding Ring" src="/assets/Diamond/Mens_Ring.png" /></td><td align="left" style="padding-left:10px;">
                                             <a href="/product/wedding/men-wedding-ring">Men's Wedding Ring		


 </a></td></tr>
                                                       <tr><td><img width="26px" height="9px" alt="Men's Wedding Band	" src="/assets/Diamond/Mens_Wedding_Band.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/wedding/mens-wedding-band">Men's Wedding Band	

 </a></td>
                                                        </tr>
                                                        
                                                      <tr><td><img width="26px" height="9px" alt="Mens Gifts" src="/assets/Diamond/Mens_Ring.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/weeding/mens-gifts">Mens Gifts


 </a></td>
                                                        </tr>
                                                        
                                                             
                                                        
                                                        
                                                        
                                                        </table>
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table>

                                                
    
            
          
        </div><!-- End 2 columns container -->
    
    </li><!-- End Home Item -->

    <li><a href="/product/earrings" class="drop">Earrings
</a>
<div class="dropdown_2columns"><!-- Begin 2 columns container -->
      <div class="col_2">
                <h2>CUSTOMIZE YOUR OWN EARRING</h2>
            </div>
          

                                                     <table cellpadding="3px" cellspacing="3px" ><tr><td>
                                             <table><tr><td ><img  alt="Studs" src="/assets/Diamond/Studs.png" /></td><td align="left" style="padding-left:10px;"><a href="/product/earrings/studs">Studs
 </a></td></tr>
                                                       <tr><td align="center"><img alt="Hoops" src="/assets/Diamond/hoop.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/earrings/hoops">Hoops
 </a></td>
                                                        </tr>
                                                        
                                                      <tr><td align="center"><img  alt="Drop" src="/assets/Diamond/drop.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/earrings/drop">Drop

 </a></td>
                                                        </tr>
                                                        
                                                          <tr><td align="center"><img  alt="Dangle" src="/assets/Diamond/Earrings_Dangle.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/earrings/dangle">Dangle

 </a></td>
                                                        </tr>    
                                                        
                                                        
                                                        
                                                        </table>
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table>

                                                
    
            
          
        </div>



</li>


   <li><a href="/product/pendant" class="drop">Pendant

</a>

<div class="dropdown_2columns align_right"><!-- Begin 2 columns container -->
      <div class="col_2">
                <h2>CUSTOMIZE YOUR OWN PENDANT</h2>
            </div>
          

                                                     <table cellpadding="3px" cellspacing="3px" ><tr><td>
                                             <table><tr><td ><img  alt="Round" src="/assets/Diamond/Solitaire_Pendants.png" /></td><td align="left" style="padding-left:10px;">
                                             <a href="/product/pendant/solitaire">Solitaire

 </a></td></tr>
                                                       <tr><td><img  alt="Heart" src="/assets/Diamond/Heart_Pendants.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/pendant/heart">Heart

 </a></td>
                                               </tr>
                                                        
                                                      <tr><td><img  alt="Religious" src="/assets/Diamond/Religious.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/pendant/religious">Religious


 </a></td>
                                               </tr>
                                                        
                                                          <tr><td><img alt="Fancy" src="/assets/Diamond/Fancy.png" /></td><td  align="left" style="padding-left:10px;"><a href="/product/pendant/fancy">Fancy


 </a></td>
                                                        </tr>    
                                                        
                                                        
                                                        
                                                       </table>
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table>

                                                
    
            
          
        </div>

</li>



  
 
    <li class="menu_right"><a href="/product/browse/sales"  class="drop">OUR PICKS</a>
    
    <div class="dropdown_2columns align_right"><!-- Begin 2 columns container -->
      <div class="col_2">
                <h2>OUR TOP PICKS</h2>
            </div>
          

                                                     <table cellpadding="3px" cellspacing="3px" ><tr><td>
                                             <table><tr><td ><img  alt="Sale" src="/assets/Diamond/Solitaire_Pendants.png" /></td><td align="left" style="padding-left:10px;">
                                             <a href="/product/browse/sales">Sale

 </a></td></tr>
                                                       <tr><td><img  alt="Heart" src="/assets/Diamond/Heart_Pendants.png" /></td><td  align="left" style="padding-left:10px;"><a href="#">Extraordinary Products

 </a></td>
                                               </tr>
                                                        
                                                   
                                                        
                                                        
                                                       </table>
                                                
                                                </td>
                                                
                                                
                                                
                                                </tr></table>

                                                
    
            
          
        </div>
    
    
    
    </li>
    
    <!-- End 3 columns Item -->


</ul>

                                 </div>

								<%--<div class="span8 offset1">
									<ul id="main-nav">
										<li><a href="#">men</a> /
											<div class="child-nav none">
												<div class="child-menu">
													<ul class="child-menu-main">
														<li>/ <a href="category.html">Suits &amp; Tailoring</a></li>
														<li>/ <a href="category.html">Trousers</a></li>
														<li>/ <a href="category.html">Jeans</a></li>
														<li>/ <a href="category.html">Shirts</a></li>
														<li>/ <a href="category.html">T-Shirts</a></li>
														<li>/ <a href="category.html">Vests &amp; Knitwear</a></li>
														<li>/ <a href="category.html">Jackets</a></li>
														<li>/ <a href="category.html">Coats</a></li>
													</ul>
													<ul class="child-menu-context">
														<li>+ <a href="category.html">new arrivals</a></li>
														<li>+ <a href="category.html">sale</a></li>
														<li>+ <a href="category.html">view all</a></li>
													</ul>
												</div>
												<div class="child-promo">
													<h2>Special Offer</h2>
													<div class="child-promo-box">
														<img class="child-promo" src="media/drop-down.png" alt="product">
														<div class="child-promo-overlay">
															<a href="category.html">30% off knitwear</a>
															<p>Only this week. Go get it!</p>
														</div>
													</div>
												</div>
											</div>
										</li>
										<li><a href="main_category.html">women</a> /</li>
										<li><a href="main_category.html">juniors</a> /</li>
										<li><a href="main_category.html">kids</a> /</li>
										<li><a href="main_category.html">shoes</a> /</li>
										<li><a href="main_category.html">sale </a><span class="bonus"> /</span></li>
									</ul>
								</div>--%>
							</div>
						</div><!-- end header -->
					</div>
				</div>