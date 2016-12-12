using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    public class Product
    {
        #region Private variables

        private int productId;
        private string productName;
        private string productCode;
        private decimal price;

        private IEnumerable<ProductGame> fitsGames;

        #endregion

        #region Public properties

        /// <summary>
        /// Unique product id. This property is primarily
        /// used when storing the data in the database.
        /// </summary>
        [Key]
        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        /// <summary>
        /// Product name/description.
        /// </summary>
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    productName = value;
                }
            }
        }

        /// <summary>
        /// Unique product code used to identify the
        /// product.
        /// </summary>
        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    productCode = value;
                }
            }
        }

        public virtual IEnumerable<ProductGame> FitsGames
        {
            get
            {
                return fitsGames;
            }
        }

        /// <summary>
        /// Product Unit Price.
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        #endregion

        public Product()
        {
            fitsGames = new List<ProductGame>();
        }

    }
}