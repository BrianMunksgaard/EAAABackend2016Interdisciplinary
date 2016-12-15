using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

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

        public int ProductSizeId
        {
            get { return productSizeId; }
            set { productSizeId = value; }
        }

        public string ProductSizeText
        {
            get { return productSizeText == null ? productSizeText = string.Empty : productSizeText; }
            set { productSizeText = value; }
        }

        public CMYK ProductSizeColorCode
        {
            get { return productSizeColorCode == null ? productSizeColorCode = new CMYK() : productSizeColorCode; }
            set { productSizeColorCode = value; }
        }

        #endregion
    }
}