using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to hold various product sizes.
    /// </summary>
    public class ProductSize : BgsEntity
    {
        #region PrivateFields

        private int productSizeId;
        private string productSizeText;
        private CMYK productSizeColorCode;

        #endregion

        #region Properties

        /// <summary>
        /// Unique size id. Primarily an internal/db property.
        /// </summary>
        public int ProductSizeId
        {
            get { return productSizeId; }
            set { productSizeId = value; }
        }

        /// <summary>
        /// The description of the size.
        /// </summary>
        [Display(Name = "Size")]
        public string ProductSizeText
        {
            get { return productSizeText == null ? productSizeText = string.Empty : productSizeText; }
            set { productSizeText = value; }
        }

        /// <summary>
        /// The color of the physical package given as a CMYK object.
        /// </summary>
        [Display(Name = "Color code")]
        public CMYK ProductSizeColorCode
        {
            get { return productSizeColorCode; }
            set { productSizeColorCode = value; }
        }

        #endregion
    }
}