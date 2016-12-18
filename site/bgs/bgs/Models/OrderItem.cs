using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to represent an item
    /// or a line on an invoice.
    /// </summary>
    public class OrderItem : BgsEntity
    {
        #region PrivateFields

        private int orderId;
        private int orderItemId;
        private int productId;
        private Product product;
        private int quantity;

        #endregion

        #region Properties

        [Index("OrderItemIndex", IsUnique = false)]
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        /// <summary>
        /// The current order item id.
        /// </summary>
        [Key]
        public int OrderItemId
        {
            get { return orderItemId; }
            set { orderItemId = value; }
        }

        /// <summary>
        /// The current product id.
        /// </summary>
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        /// <summary>
        /// The actual product.
        /// </summary>
        [NotMapped]
        public Product Product
        {
            get { return product == null ? product = new Product() : product; }
            set { product = value; }
        }


        /// <summary>
        /// The number of items.
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// The total price for the item(s) on this line
        /// of the order.
        /// </summary>
        public decimal TotalPrice
        {
            get { return Product.Price * quantity; }
        }

        #endregion

        /// <summary>
        /// OrderItem constructor.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        public OrderItem(Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException("product", "An initialized product must be specified.");
            if (quantity == 0) throw new ArgumentOutOfRangeException("quantity", "Quantity cannot be zero.");
            this.product = product;
            this.quantity = quantity;
        }

    }
}