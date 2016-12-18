using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        private string barcode;
        private string imageUrl;

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
        [Required]
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
        [Required]
        [Index("ProductIndex", IsUnique = true)]
        [MaxLength(15)]
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
        [Range(1, 200)]
        [DataType(DataType.Currency)]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Category id (foreign key reference).
        /// </summary>
        [Required]
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

        /// <summary>
        /// Id of related product size.
        /// </summary>
        public int ProductSizeId
        {
            get { return productSizeId; }
            set { productSizeId = value; }
        }

        /// <summary>
        /// Product size navigation property.
        /// </summary>
        [Display(Name = "Size")]
        public virtual ProductSize ProductSize
        {
            get { return productSize; }
            set { productSize = value; }
        }

        /// <summary>
        /// Product weight in kg.
        /// </summary>
        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Product barcode.
        /// </summary>
        public string Barcode
        {
            get { return barcode == null ? barcode = string.Empty : barcode; }
            set { barcode = value; }
        }

        /// <summary>
        /// Product image URL.
        /// </summary>
        [Display(Name = "Image url")]
        public string ImageUrl
        {
            get { return imageUrl == null ? imageUrl = string.Empty : imageUrl; }
            set { imageUrl = value; }
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