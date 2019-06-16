using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace EJewel.UserView
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoot(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        public static void RegisterRoot(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("RootForDefault", "home", "~/Default.aspx");

            routeCollection.MapPageRoute("RootForProductCategory", "product/{primary_category}", "~/Product.aspx");
            routeCollection.MapPageRoute("RootForProductSubCategory", "product/{primary_category}/{sub_category}", "~/Product.aspx");

            routeCollection.MapPageRoute("RootForProductCustomize", "product/{primary_category}/{sub_category}/{product_title}/{sku}", "~/ProductCustomize.aspx");
            routeCollection.MapPageRoute("RootForLooseDiamondShape", "diamond/{shape_name}", "~/LooseDiamonds.aspx");
            routeCollection.MapPageRoute("RootForLooseDiamond", "diamond", "~/LooseDiamonds.aspx");
            routeCollection.MapPageRoute("RootForCustomRingDesign", "custom-ring-design", "~/CustomRingDesign.aspx");
            //
            routeCollection.MapPageRoute("RootForShopingCart", "cart", "~/ShoppingCart.aspx");

            //image manager
            //routeCollection.MapPageRoute("RootForProductImageManager", "productimage/{sku}/{custom}/{angle}/{height}", "~/Handler/ImageManager.ashx");
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
