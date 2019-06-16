<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="EJewel.AdminView.Usercontrol.Menu" %>

<%
    if (Session["UType"] != null)
    {
        if (Convert.ToInt32(Session["UType"]) == 1)
        {
         %>
<ul id="mainNav">			
			<li class="nav"><a href="/Dashboard.aspx">Dashboard</a></li>

             <!--Category-->	
            <li class="nav"><a href="/Master/Category/ListCategory.aspx">Category &amp; Sub Category</a></li>
            <!--Product-->	
            <li class="nav"><a href="/Product/ProductList.aspx">Manage Product</a></li>
            <!--Order------------------>          
			<li  class="nav">
				<a href="javascript:;">Orders/Billing/Shipping</a>
				<ul class="subNav">
					<li><a href="/Order/ManageShipping.aspx">Assign Shipping Charges</a></li>    
                    
                    <li><a href="Order/OrderManagement.aspx">Order Management </a></li>    
                    <li><a href="/Order/ListPromotionalcodeManagement.aspx">List Promotionalcode Management </a></li>                     
                  
				</ul>						
			</li>
			<!--Metal-->	
			<li  class="nav">
				<a href="javascript:;">Metal</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=metal_weight">Metal Weight</a></li>
					<li><a href="/Common/Sfm/SfmList.aspx?view=metal_name">Metal Name</a></li>
					<li><a href="/Master/Metal/ListMetalType.aspx">Metal Type</a></li>
				</ul>						
			</li>
            <!--Setting-->	
			<li  class="nav">
				<a href="javascript:;">Setting</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=setting_type">Setting Type</a></li>
					<li><a href="/Master/Setting/ListStoneCategorySettingType.aspx">Setting Category</a></li>
                    <li><a href="/Common/Sfm/SfmList.aspx?view=ring_size">Ring Size</a></li>
					<li><a href="/Master/Setting/ListRingSize.aspx">Category Ring Size</a></li>
				</ul>						
			</li>
             <!--Chain-->	
			<li  class="nav">
				<a href="javascript:;">Chain</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=chain_style">Chain Style</a></li>
					<li><a href="/Common/Sfm/SfmList.aspx?view=chain_length">Chain Length</a></li>
				</ul>						
			</li>
            <!--Certificate-->	
			<li  class="nav">
				<a href="javascript:;">Certificate</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=cert_gridle">Gridle</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_culet">Culet</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_polish">Polish</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_symmetry">Symmerty</a></li>  
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_flouresence">Flouresence</a></li>  
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_lab">Lab</a></li>       
				</ul>						
			</li>
            <!--Stone-->	
			<li  class="nav">
				<a href="javascript:;">Stone</a>
				<ul class="subNav">
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=cut">Cut</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=color">Color</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=clarity">Clarity</a></li>    
                    <li><a href="/Master/Stone/ListStoneShape.aspx">Shape</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=type">Type</a></li>    
					<li><a href="/Master/Stone/ListCenterStone.aspx?provider=def">Center Stone (FD)</a></li>
                    <li><a href="/Master/Stone/ListCenterStone.aspx?provider=rapnet">Center Stone (Rapnet)</a></li>
                    <li><a href="#">Supplier</a></li>
                    <li><a href="/Master/Stone/ListSideStone.aspx">Side Stone</a></li>                         
				</ul>						
			</li>
      
            <li  class="nav">
				<a href="javascript:;">Extras</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=news_category">News Category</a></li>             
                  
			
					<li><a href="/Extras/ListNews.aspx">News & Events</a></li>                  
                    
			
					<li><a href="/Extras/ListProposalStory.aspx">Proposal Stories</a></li> 
                    	<li><a href="/Extras/ListContactDetails.aspx">Contact Details</a></li>                            
                    
				</ul>							
			</li>
            
            

             <li  class="nav">
				<a href="javascript:;">Manage Customers </a>
				<ul class="subNav">

                     <li><a href="/Customers/CustomerAccounts.aspx">Customer Accounts</a></li> 
                     <li><a href="/Customers/NewsletterSubscriptions.aspx">Newsletter Subscriptions </a></li> 
                     <li><a href="/Customers/QueriesOnProduct.aspx">Queries On Products </a></li> 
                     <li><a href="/Customers/ContactUsQueries.aspx">Contact Us(Queries)</a></li>
                       <li><a href="/Customers/ProductReviewStatus.aspx">Product Review Status (Active to be viewed in frontend)</a></li>
	            </ul>						
		    </li>
             <li  class="nav">
				<a href="javascript:;">Site Settings</a>
				<ul class="subNav">

                     <li><a href="/SiteSetting/ListAdminUser.aspx">Manage Administrative Users</a></li> 
                   
                     
	            </ul>						
		    </li>

             <li  class="nav">
				<a href="javascript:;">Manage Location</a>
				<ul class="subNav">

                     <li><a href="/Master/Location/ListCountry.aspx">Country</a></li> 
                     <li><a href="/Master/Location/ListState.aspx">State</a></li> 
                     <li><a href="/Master/Location/ListCity.aspx">City</a></li> 
                     <li><a href="/Master/Location/ListZipCode.aspx">ZipCode</a></li> 
	            </ul>						
		    </li>
              <li class="nav"><a href="/SiteSetting/ChangePassword.aspx">Change Password</a></li> 
               <li class="nav"><a href="/SiteSetting/LoggedUserDetails.aspx">Logged User</a></li> 
            <li class="nav">
            <a href="/Default.aspx">Logout</a>
            <%--<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" onclick="lnkBtnLogout_Click"></asp:LinkButton>--%></li>
		</ul>
        <%
        }
        else
        {
            %>
        <ul id="mainNav">		
			<li class="nav"><a href="/Dashboard.aspx">Dashboard</a></li>

               
            <!--Product-->	
            <li class="nav"><a href="/Product/ProductList.aspx">Manage Product</a></li>
            <!--Order------------------>          
			<li  class="nav">
				<a href="javascript:;">Orders/Billing/Shipping</a>
				<ul class="subNav">
					<li><a href="/Order/ManageShipping.aspx">Assign Shipping Charges</a></li>    
                    
                    <li><a href="Order/OrderManagement.aspx">Order Management </a></li>                     
                  
				</ul>						
			</li>
			<!--Metal-->	
			<li  class="nav">
				<a href="javascript:;">Metal</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=metal_weight">Metal Weight</a></li>
					<li><a href="/Common/Sfm/SfmList.aspx?view=metal_name">Metal Name</a></li>
					<li><a href="/Master/Metal/ListMetalType.aspx">Metal Type</a></li>
				</ul>						
			</li>
            <!--Setting-->	
			<li  class="nav">
				<a href="javascript:;">Setting</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=setting_type">Setting Type</a></li>
					<li><a href="/Master/Setting/ListStoneCategorySettingType.aspx">Setting Category</a></li>
                    <li><a href="/Common/Sfm/SfmList.aspx?view=ring_size">Ring Size</a></li>
					<li><a href="/Master/Setting/ListRingSize.aspx">Category Ring Size</a></li>
				</ul>						
			</li>
             <!--Chain-->	
			<li  class="nav">
				<a href="javascript:;">Chain</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=chain_style">Chain Style</a></li>
					<li><a href="/Common/Sfm/SfmList.aspx?view=chain_length">Chain Length</a></li>
				</ul>						
			</li>
            <!--Certificate-->	
			<li  class="nav">
				<a href="javascript:;">Certificate</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=cert_gridle">Gridle</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_culet">Culet</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_polish">Polish</a></li> 
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_symmetry">Symmerty</a></li>  
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_flouresence">Flouresence</a></li>  
                    <li><a href="/Common/Sfm/SfmList.aspx?view=cert_lab">Lab</a></li>       
				</ul>						
			</li>
            <!--Stone-->	
			<li  class="nav">
				<a href="javascript:;">Stone</a>
				<ul class="subNav">
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=cut">Cut</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=color">Color</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=clarity">Clarity</a></li>    
                    <li><a href="/Master/Stone/ListStoneShape.aspx">Shape</a></li>    
                    <li><a href="/Master/Stone/ListStoneSpecification.aspx?view=type">Type</a></li>    
					<li><a href="/Master/Stone/ListCenterStone.aspx?provider=def">Center Stone (FD)</a></li>
                    <li><a href="/Master/Stone/ListCenterStone.aspx?provider=rapnet">Center Stone (Rapnet)</a></li>
                    <li><a href="#">Supplier</a></li>
                    <li><a href="/Master/Stone/ListSideStone.aspx">Side Stone</a></li>                         
				</ul>						
			</li>
      
            <li  class="nav">
				<a href="javascript:;">Extras</a>
				<ul class="subNav">
					<li><a href="/Common/Sfm/SfmList.aspx?view=news_category">News Category</a></li>             
                  
			
					<li><a href="/Extras/ListNews.aspx">News & Events</a></li>                  
                    
			
					<li><a href="/Extras/ListProposalStory.aspx">Proposal Stories</a></li> 
                    	<li><a href="/Extras/ListContactDetails.aspx">Contact Details</a></li>                            
                    
				</ul>							
			</li>
          
             <li  class="nav">
				<a href="javascript:;">Manage Location</a>
				<ul class="subNav">

                     <li><a href="/Master/Location/ListCountry.aspx">Country</a></li> 
                     <li><a href="/Master/Location/ListState.aspx">State</a></li> 
                     <li><a href="/Master/Location/ListCity.aspx">City</a></li> 
                     <li><a href="/Master/Location/ListZipCode.aspx">ZipCode</a></li> 
	            </ul>						
		    </li>
           <li class="nav"><a href="/SiteSetting/ChangePassword.aspx">Change Password</a></li> 
               <li class="nav">
                   <a href="/Default.aspx">Logout</a>
               <%--<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" 
                    onclick="lnkBtnLogout_Click"></asp:LinkButton>--%></li>
		</ul>
            <%
        }

        }
     %>