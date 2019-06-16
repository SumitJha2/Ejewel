<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="EJewel.UserView.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script src="/assets/controls/jquery.lazyload.js" type="text/javascript"></script>

<div class="container push-below-header">
			<div class="row">
				<div class="span12">
					<h2 class="section-heading">Shopping Cart</h2>
				</div>
			</div>
            <%
                if (_lstCartProduct != null)
                {
                    int counter = 0;
                    int totalRingSize = 0;
                    int totalItems = _lstCartProduct.Count;

                    if (totalItems > 0)
                    {
                        %>
			<div class="row hidden-phone">
				<div class="span8">
					<p class="secondary">product / </p>
				</div>
				<div class="span2">
					<p class="secondary">quantity / </p>
				</div>
				<div class="span2">
					<p class="secondary">price / </p>
				</div>
			</div>

                    <% 
                        for (int i = 0; i < totalItems; i++)
                        {
                            var productDetails = ProductDetailsFromSKU(_lstCartProduct[i].ProductId);
                            if (productDetails != null)
                            {
                        %>
                        <div class="row push30">
				<div class="span8">
					<div class="mid-thumb floated">
						<img class="lazy" src="/assets/themes/img/icon/loading_55.gif" data-original="/Handler/ImageManager.ashx?GUID=<%= _lstCartProduct[i].ImageGUID %>&height=110" alt="product">
					</div>
					<div class="cart-det floated push30">
						<span class="primary"><%= productDetails.ProductTitle%></span>
						<span>Product SKU: <%= productDetails.SKU%></span>
                        <% 
                                //metal info
                                var metalInfo=MetalTypeInfo(_lstCartProduct[i].MetalTypeId);
                           if (metalInfo != null)
                           {
                               %>
                               <span>Metal : <%= metalInfo.MetalTypeName %></span>
                               <%
                           }
                                //show center stone
                                   var centerStoneInfo = CenterStoneInfo(_lstCartProduct[i].CenterStoneSKU);
                                   if (centerStoneInfo != null)
                                   {
                                       %>
                                       <span><b>Center Stone Information</b></span>
                                       <span>SKU : <%= centerStoneInfo.SKU %></span>
                                       <span>Shape : <%= centerStoneInfo.StoneShape %></span>
                                       <span>Weight : <%= centerStoneInfo.StoneCarate %> ct.</span>
                                       <span>Clarity : <%= centerStoneInfo.StoneClarity %></span>
                                       <span>Color : <%= centerStoneInfo.StoneColor %></span>
                                       <span>Cut : <%= centerStoneInfo.StoneCut %></span>
                                       <span>Certification : <%= centerStoneInfo.CertificateCertificationLab %></span>
                                           <%
                                   }
                                 %>
                        <% 
                              //show the extra attribute in product  
                var subCategoryDetails = SubCategoryDetails(productDetails.SubCategoryID);
                if (subCategoryDetails != null)
                {
                    //check for the ring size;
                    if (subCategoryDetails.HasRing && _lstRingSize != null)
                    {
                        //_lstCartProduct[i].RingSize;
                        //_lstCartProduct[i].Engraving;
                        totalRingSize = _lstRingSize.Count;
                                   %>
                                   <span>
                                   <select id="ddlRingSize_<%= i  %>"  onchange="updateRingSize(this.value,<%= _lstCartProduct[i].CartId %>)">
                                   <option value="0">SELECT A RING SIZE</option>
                                   <% for (counter = 0; counter < totalRingSize; counter++)
                                      {
                                          string selected = _lstCartProduct[i].RingSize == _lstRingSize[counter].AutoID ? "selected=\"selected\"" : "";
                                          %>
                                          <option value="<%= _lstRingSize[counter].AutoID %>" <%= selected %>><%= _lstRingSize[counter].Name%> </option>
                                          <%
                                      } %>
                                   </select>
                                   </span>
                                   <%
                }
                    //sub category
                    if (subCategoryDetails.HasEngraving)
                    {
                        //for engraving
                                   %>
                                   <span>
                                   <input type="text" id="txtEngraving_<%= i %>" value="<%= _lstCartProduct[i].Engraving  %>" maxlength="25" style="width:250px;height:auto;" placeholder="ADD Free Engraving" /> &nbsp;
                                   <input type="button" value="Set Engraving" onclick="setEngraving(<%=i %>,<%= _lstCartProduct[i].CartId %>)" />
                                    </span>
                                   <%
                }
                }
                               
                            %>
					</div>
				</div>
				<div class="span2 push50 quant">
					<p class="mid-text floated"><% = _lstCartProduct[i].Quanity %></p>
				</div>
				<div class="span2 push50 relative v-stretch">
					<p class="mid-text">$<%= _lstCartProduct[i].Price%></p>
					<a href="javascript:void(0)" onclick="removeCart(<%= _lstCartProduct[i].CartId %>)" class="remove secondary absolute">-remove</a>
				</div>
			</div>
                        <%
                }
                            else
                            {
                                //for other types of product
                            }
                        }
                    %>
                    <div class="row push20">
				<div class="span7">
					<div class="row">
						<div class="span7 phone-block">
							<div class="breadcrumbs-big phone-block">
								<a href="index.html" class="cur-bread">Promotion Code</a>
								
							</div>
							
						</div>
					</div>
					<div class="row push20">
						<div class="span7">
							<div class="overflown">
								<span class="secondary phone-block">Enter code:</span>
								<input type="text" class="quotes secondary">
								<input type="submit" class="simple-submit secondary" value="Apply">
							</div>
						</div>
					</div>
				</div>
				<div class="span5">
					<div class="row push30">
						<div class="span2 offset1">
							<span class="secondary big phone-block">sub-total:</span>
						</div>
						<div class="span2">
							<span class="small-text phone-block"> $ <% =_SubTotal%></span>
						</div>
					</div>
					<div class="row push30">
						<div class="span2 offset1">
							<span class="secondary big phone-block">shipping:</span>
						</div>
						<div class="span2">
							<span class="small-text phone-block">free</span>
						</div>
					</div>
					<div class="row push30">
						<div class="span2 offset1">
							<span class="secondary big phone-block">VAT (10%):</span>
						</div>
						<div class="span2">
							<span class="small-text phone-block">$ 519</span>
						</div>
					</div>
					<div class="row push30 block-diagonal">
						<div class="span2 offset1">
							<span class="primary big phone-block">Total:</span>
						</div>
						<div class="span2">
							<span class="mid-text highlight phone-block">$ 5709</span>
						</div>
					</div>
					<div class="row push30">
						<a href="/home" class="primary push20 floated">&lt; Continue Shopping</a>
						<a href="/login" class="checkout">Checkout</a> 
					</div>
				</div>
			</div>
                    <%

                }
                }
                 %>

		</div>

        <script type="text/javascript">
            $(document).ready(function () {
                $("img.lazy").lazyload({ effect: "fadeIn" });
            });
            function updateRingSize(ringSizeId,cartId) {
                try {
                    if (ringSizeId > 0) {
                        //console.log(SIDE_STONE_ID);
                        $.ajax({
                            type: "POST",
                            async: false,
                            cache: false,
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/Service.asmx/UpdateCartRingSize",
                            data: "{cartId:" + cartId + ",ringSizeId:" +
ringSizeId + "}",
                            dataType: "json",
                            success: function (successData) {
                                if (successData.d != null) {
                                }
                            },
                            error: function (errorData) {
                            }
                        });
                    }
                }
                catch (e) {
                    alert(e);
                }
            }

            //set engraving
            function setEngraving(cont_id, cart_id) {
                try {
                    var text = document.getElementById("txtEngraving_" + cont_id).value;
                    $.ajax({
                        type: "POST",
                        async: false,
                        cache: false,
                        contentType: "application/json; charset=utf-8",
                        url: "/Services/Service.asmx/UpdateCartEngraving",
                        data: "{cartId:" + cart_id + ",text:" +
 JSON.stringify(text) + "}",
                        dataType: "json",
                        success: function (successData) {
                            if (successData.d != null) {
                            }
                        },
                        error: function (errorData) {
                        }
                    });
                }
                catch (e) {
                }
            }

            //remove cart
            function removeCart(cart_id) {
                if (confirm('Do you want to remove ?')) {
                    try {
                        $.ajax({
                            type: "POST",
                            async: false,
                            cache: false,
                            contentType: "application/json; charset=utf-8",
                            url: "/Services/Service.asmx/RemoveCart",
                            data: "{cartId:" + cart_id + "}",
                            dataType: "json",
                            success: function (successData) {
                                if (successData.d != null) {
                                    window.location.href = '/cart';
                                }
                            },
                            error: function (errorData) {
                            }
                        });
                    }
                    catch (e) {
                    }
                }
            }
        </script>
</asp:Content>
