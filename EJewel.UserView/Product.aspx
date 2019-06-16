<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="EJewel.UserView.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--script-->
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Lazy loading-->
<script src="/assets/controls/jquery.lazyload.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $(".morelink").each(function () {
            var currentList = $(this);
            var Items = $("li", currentList);
            var totalItems = $("li", currentList).length;
            var visibleItem = 5;

            if (totalItems > visibleItem) {
                $("li", currentList).eq(visibleItem - 1).nextAll().css({ display: 'none' });
                currentList.append("<a href='javascript:void(0)' class='readmore'>more</a><span class='arrowmore'>&nbsp;></span>");
            }

            //, 
            $("a.readmore",currentList).on('click', function () {
                var txt = $(this).text();
                if (txt == 'more') {
                    $("li", currentList).eq(visibleItem-1).nextAll("li").css({ display: 'block' });
                    $(this).text('less');
                    $(this).next().removeClass('arrowmore').addClass('arrowless');
                }
                else if (txt == 'less') {
                    $("li", currentList).eq(visibleItem-1).nextAll("li").css({ display: 'none' });
                    $(this).text('more');
                    $(this).next().removeClass('arrowless').addClass('arrowmore');
                }
            });
        });
    });
</script>
<div class="container push-below-header">
			<div class="row">
				<div class="span3 side-options phone-span-diff">
                    <asp:Literal ID="ltrlFilter" runat="server"></asp:Literal>
				</div>
                <!--Product Details-->
				<div class="span9">
					<div class="row">
						<div class="span9">
							<div class="breadcrumbs-big phone-center">
                                <asp:Literal ID="ltrlBreadCumb" runat="server"></asp:Literal>
							</div>
						</div>
					</div>

                    <%
                        if (_lstProduct != null)
                        {
                            string productCustomizeUrl = "";
                            int break_counter = 0;
                            int total_product = _lstProduct.Count;
                            for (int i = 0; i < total_product; i++)
                            {
                                productCustomizeUrl = "/product/" + ProductCustomizeEncodeUrl(_lstProduct[i].SKU, _lstProduct[i].PrimaryCategoryName, _lstProduct[i].SubCategoryName, _lstProduct[i].ProductTitle);
                                if (break_counter == 0)
                                {
                                    %>
                                    <div class="row">
                                    <%
                        }
                                
                                break_counter++;
                                %>
                                <div class="span3 product">

							    <div class="product-overflow-keeper">
                                <img class="product-image lazy" src="/assets/themes/img/icon/loading_55.gif" data-original="/Handler/ImageManager.ashx?view=def&SKU=<%= _lstProduct[i].SKU %>&height=260" alt="product">
								<div class="product-hover">
                                <%
                                    if (_lstProduct[i].OnSale)
                                    {
                                 %>
                                <span class="product-price" style="text-decoration:line-through;">$ <%= TotalPrice(_lstProduct[i].ProductID, _lstProduct[i].ProductDefaultPrice)%></span>
                                <span class="product-price">$ <%= SalesPrice(_lstProduct[i]) %></span>
                                <%
                                    }
                                    else
                                    {
                                        %>
                                        <span class="product-price">$ <%= TotalPrice(_lstProduct[i].ProductID, _lstProduct[i].ProductDefaultPrice)%></span>
                                        <%
                                    } %>

                                <br />
                                 <br />
                                 <% if (_lstProduct[i].IsExtraOrdinary)
                                    { %>
                                    <a href="javascript:void(0)">+ Quickview</a> <br /> <br />
                                    <a href="javascript:void(0)" class="product-name"><%= _lstProduct[i].ProductTitle %></a>
                                 <%}
                                    else
                                    {%>
                                <a href="<% = productCustomizeUrl %>">+ Customize</a>
                                <br /> <br />
                                <a href="<% = productCustomizeUrl %>" class="product-name"><%= _lstProduct[i].ProductTitle %></a>
                                <%} %>
                                    	
								</div>
							</div>

                            <%
                                if (_lstProduct[i].NewProduct && !_lstProduct[i].OnSale)
                                {
                                 %>
                            <div class="product-badge rotate290">
								<span>new arrival</span>
							</div>
                           <%
                                } %>
                           
						</div>
                                    <%
                        if (break_counter == 3)
                        {
                            break_counter = 0;
                                    %>
                                    </div>
                                    <%
                        }
                            }
                            if (break_counter > 0)
                            {
                                Response.Write("</div>");
                            }
                        }
                         %>
				

				</div>
                 <div id="Pagination" style="float:right;" class="pagination"></div>
			</div>
            </div>

        <script type="text/javascript">
            var perPage=<%= _PAGING_PER_PAGE %>;
            $(document).ready(function () {
                $("img.lazy").lazyload({ effect: "fadeIn"});
                var total_product=<%= _TOTAL_RECORD %>;
                if(total_product>0 && total_product>perPage)
                {
                    $("#Pagination").pagination(total_product, getPagingOption());
                }
            });

            //should be define
            function getPagingOption() {
                var opt = { callback: pagingCallback };
                opt['items_per_page'] = perPage;
                opt['num_display_entries'] = 5;
                opt['num_edge_entries'] = 2;
                return opt;
            }
            //paging call back
            function pagingCallback(page_index, jq) {
                // Get number of elements per pagionation page from form
            }
        </script>
</asp:Content>

