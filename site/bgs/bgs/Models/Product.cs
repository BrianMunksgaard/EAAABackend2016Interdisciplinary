﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace bgs.Models
{
    /// <summary>
    /// A super class for all the products in the system.
    /// This class holds the properties that are common for all products.
    /// </summary>
    public class Product : BgsEntity
    {
        #region Private variables

        private int productId;
        private string productName;
        private string productCode;
        private decimal price;

        private int categoryId;
        private Category category;

        private ICollection<ProductFitGame> fitsGames;

        private int productSizeId;
        private ProductSize productSize;

        private decimal weight;
        private Color color;

        #endregion

        #region Public properties

        /// <summary>
        /// Unique product id. This is primarily
        /// an internal/db property.
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
        [Display(Name = "Product name")]
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
        /// product. This is the product code used
        /// by the business.
        /// </summary>
        [Index("ProductIndex", IsUnique = true)]
        [MaxLength(20)]
        [Display(Name = "Product code")]
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

        /// <summary>
        /// A collection of games that this product fits.
        /// </summary>
        public virtual ICollection<ProductFitGame> FitsGames
        {
            get
            {
                return fitsGames == null ? fitsGames = new List<ProductFitGame>() : fitsGames;
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

        /// <summary>
        /// Category id (foreign key reference).
        /// </summary>
        [Display(Name = "Category")]
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        /// <summary>
        /// The category.
        /// Navigation property.
        /// </summary>
        public virtual Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public int ProductSizeId
        {
            get { return productSizeId; }
            set { productSizeId = value; }
        }

        public ProductSize ProductSize
        {
            get { return productSize == null ? productSize = new ProductSize() : productSize; }
            set { productSize = value; }
        }

        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Product()
        {

        }

    }
}