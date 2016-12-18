﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to hold data about
    /// an order.
    /// </summary>
    public class Order : BgsEntity
    {
        #region PrivateFields
        private int orderId;
        private List<OrderItem> orderItems;
        private DateTime orderDate;
        private Person customer;
        private int personId;

        #endregion

        #region Properties

        /// <summary>
        /// Unique order id.
        /// </summary>
        [Key]
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        /// <summary>
        /// Items on the order.
        /// </summary>
        [NotMapped]
        public List<OrderItem> OrderItems
        {
            get
            {
                return orderItems == null ? orderItems = new List<OrderItem>() : orderItems;
            }
        }

        /// <summary>
        /// Order date.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime OrderDate
        {
            get
            {
                return orderDate == DateTime.MinValue ? orderDate = DateTime.Now : orderDate;
            }
            set { orderDate = value; }
        }

        /// <summary>
        /// The customer.
        /// Navigation property.
        /// </summary>
        [NotMapped]
        public Person Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        /// <summary>
        /// Person id (foreign key reference).
        /// </summary>
        public int PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        /// <summary>
        /// Total order price.
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal d = OrderItems.Sum(item => item.TotalPrice);
                return d;
            }
        }

        /// <summary>
        /// Total number of item on the order.
        /// </summary>
        public int TotalNoOfItems
        {
            get
            {
                int i = OrderItems.Sum(x => x.Quantity);
                return i;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Order()
        {
            this.orderDate = DateTime.Now;
            orderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Init order with specified date.
        /// </summary>
        /// <param name="orderDate"></param>
        public Order(DateTime orderDate)
        {
            this.orderDate = orderDate;
            orderItems = new List<OrderItem>();
        }

        /// <summary>
        /// Add product to the order. If the item is already
        /// on the order, only the quantity is updated.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public void AddItem(Product product, int quantity)
        {
            OrderItem oi = OrderItems.SingleOrDefault(item => item.Product.ProductId == product.ProductId);
            if (oi == null)
            {
                OrderItems.Add(new OrderItem(product, quantity));
            }
            else
            {
                oi.Quantity += quantity;
            }
        }

        /// <summary>
        /// Remove product from the cart.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveItem(Product product)
        {
            OrderItems.RemoveAll(item => item.Product.ProductId == product.ProductId);
        }

        /// <summary>
        /// Remove all products from the order.
        /// </summary>
        public void RemoveAllItems()
        {
            OrderItems.Clear();
        }
    }
}