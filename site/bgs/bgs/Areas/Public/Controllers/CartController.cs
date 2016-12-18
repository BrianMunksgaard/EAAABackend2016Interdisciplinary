using bgs.DAL;
using bgs.Models;
using bgs.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        BgsContext db;

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CartController()
        {
            db = new BgsContext();
            uow = new UnitOfWork(db);
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
            return View(new ShippingDetails());
        }

        /// <summary>
        /// Cart checkout. Save cart content as order.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="shippingDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if(!ModelState.IsValid)
            {
                return View(shippingDetails);
            }

            using (DbContextTransaction dbTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    Repository<Person> personRep = new Repository<Person>(db, true);
                    Repository<Order> orderRep = new Repository<Order>(db, true);
                    Repository<OrderItem> orderItemRep = new Repository<OrderItem>(db, true);

                    Person p = new Person(shippingDetails);
                    int personId = personRep.SaveItem(p);

                    //cart.Order.Customer = p;
                    cart.Order.PersonId = p.PersonId;
                    int orderId = orderRep.SaveItem(cart.Order);

                    foreach (OrderItem oi in cart.Order.OrderItems)
                    {
                        oi.OrderId = orderId;
                        orderItemRep.SaveItem(oi);
                    }

                    db.SaveChanges();
                    dbTransaction.Commit();

                    cart.ClearCart();

                    return View("Completed");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    if (dbTransaction != null)
                    {
                        dbTransaction.Rollback();
                    }
                    return View(shippingDetails);
                }
            }
        }
    }
}