using bgs.DAL;
using bgs.Models;
using bgs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bgs.Areas.Public.Controllers
{
    /// <summary>
    /// (Shopping) Cart controller.
    /// </summary>
    public class CartController : Controller
    {
        #region PrivateFields

        private UnitOfWork uow;

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CartController()
        {
            uow = new UnitOfWork();
        }

        /// <summary>
        /// Return shopping cart information to the 
        /// index view.
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Add product to the shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl, int Qty)
        {
            Product product = uow.ProductRepository.GetItem(productId);
            if (product != null)
            {
                cart.AddItem(product, Qty);
            }

            return RedirectToAction("Index", "Catalogue", new { area = "Public" });
        }

        /// <summary>
        /// Remove product from the shopping cart.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = uow.ProductRepository.GetItem(productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }

            return RedirectToAction("Index", "Cart", new { area = "Public" });
        }

        /// <summary>
        /// Used for displaying a shopping cart summary.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        /// <summary>
        /// Used for displaying the checkout view.
        /// </summary>
        /// <returns></returns>
        public ViewResult Checkout()
        {
            //return View(new ShippingDetails());
            return null;
        }

        /*
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            // If everything is OK, display the completion view.
            // Otherwise display the shipping details again.
            if (ModelState.IsValid)
            {
                // order processing logic
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
            
            return null;
        }
        */
    }
}