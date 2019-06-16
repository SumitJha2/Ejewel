using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EJewel.Model.Cart;
/// <summary>
/// Summary description for ShoppingCart
/// </summary>

namespace EJewel.Controller.Cart
{
    public class CartController
    {

        #region Properties

        public List<CartProductModel> ProductItems { get; private set; }

        #endregion

        #region Singleton Implementation

        // Readonly properties can only be set in initialization or in a constructor
        public static readonly CartController Instance;
        // The static constructor is called as soon as the class is loaded into memory
        static CartController()
        {
            // If the cart is not in the session, create one and put it there
            // Otherwise, get it from the session
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                Instance = new CartController();
                Instance.ProductItems = new List<CartProductModel>();
                HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            }
            else
            {
                Instance = (CartController)HttpContext.Current.Session["ASPNETShoppingCart"];
            }
        }

        // A protected constructor ensures that an object can't be created from outside
        protected CartController() { }

        #endregion

        #region Item Modification Methods

        public void AddItem(int metalTypeid,long productId, string centerStoneSKU, int productTypeId, long sideStoneId, string imageGUID, double price)
        {
            // Create a new item to add to the cart
            ProductItems.Add(new CartProductModel()
            {
                CartId=this.NextCartId,
                CenterStoneSKU = centerStoneSKU,
                ImageGUID = imageGUID,
                Price = price,
                ProductId = productId,
                ProductTypeId = productTypeId,
                Quanity = 1,
                SideStoneId = sideStoneId
            });
        }

        private int NextCartId
        {
            get
            {
                try
                {
                    if(ProductItems!=null)
                    {
                        return ProductItems.Count + 1;
                    }
                }
                catch(Exception ex)
                {
                    
                }
                return 1;
            }
        }

        public void UpdateRingSize(int cartId, int ringSizeid)
        {
            CartProductModel cartProduct = this.GetProductFromCartId(cartId);
            if(cartProduct!=null)
            {
                foreach(CartProductModel cart in ProductItems)
                {
                    if(cart.CartId==cartProduct.CartId)
                    {
                        cart.RingSize = ringSizeid;
                        return;
                    }
                }
            }
        }

        public void UpdateEngraving(int cartId, string text)
        {
            CartProductModel cartProduct = this.GetProductFromCartId(cartId);
            if (cartProduct != null)
            {
                foreach (CartProductModel cart in ProductItems)
                {
                    if (cart.CartId == cartProduct.CartId)
                    {
                        cart.Engraving = text;
                        return;
                    }
                }
            }
        }

        public void RemoveItem(int cartId)
        {
            CartProductModel cartProduct = this.GetProductFromCartId(cartId);
            if (cartProduct != null)
            {
                ProductItems.Remove(cartProduct);
            }
        }

        private CartProductModel GetProductFromCartId(int cartId)
        {
            if(ProductItems!=null)
            {
                int total_item = ProductItems.Count;
                for(int i=0;i<total_item;i++)
                {
                    if (ProductItems[i].CartId == cartId)
                    {
                        return ProductItems[i];
                    }
                }
            }
            return null;
        }
        #endregion

        #region Reporting Methods
        public double GetSubTotal()
        {
            double subTotal = 0;
            foreach (CartProductModel item in ProductItems)
                subTotal += item.Price;

            return subTotal;
        }
        #endregion

    }
}