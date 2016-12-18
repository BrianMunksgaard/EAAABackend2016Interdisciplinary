using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to represent
    /// a shopping cart.
    /// </summary>
    public class Cart
    {
        #region PrivateFields
        private Order order;
        #endregion

        #region Properties

        /// <summary>
        /// The order in the cart.
        /// </summary>
        public Order Order
        {
            get
            {
                return order;
            }
        }

        /// <summary>
        /// Whether or not there are items
        /// in the cart.
        /// </summary>
        public bool HasItems
        {
            get
            {
                return Order.OrderItems.Count > 0;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Cart()
        {
            order = new Order();
        }

        /// <summary>
        /// Add item to the cart.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            order.AddItem(product, quantity);
        }

        /// <summary>
        /// Remove product from the cart.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveItem(Product product)
        {
            order.RemoveItem(product);
        }

        /// <summary>
        /// Clear the shopping cart.
        /// </summary>
        public void ClearCart()
        {
            order.RemoveAllItems();
        }

        /// <summary>
        /// Perform order checkout.
        /// </summary>
        /// <param name="customer"></param>
        public void Checkout(Person customer)
        {
            order.Customer = customer;
            order.CustomerId = customer.PersonId;
        }
    }
}