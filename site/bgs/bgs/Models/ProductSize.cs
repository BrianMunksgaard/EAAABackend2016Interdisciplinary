using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to hold various product sizes.
    /// </summary>
    public class ProductSize : BgsEntity
    {
        private int productSizeId;
        private string productSizeText;

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
    }
}