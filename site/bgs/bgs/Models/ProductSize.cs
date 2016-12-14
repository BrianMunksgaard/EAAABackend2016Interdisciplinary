using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bgs.Models
{
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