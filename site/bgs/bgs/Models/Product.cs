using System.Collections.Generic;

namespace bgs.Models
{
    public class Product
    {
        #region Private variables

        private int productId;
        private string productName;
        private string productCode;

        private IEnumerable<ProductGame> fitsGames;

        #endregion

        #region Public properties

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

        #endregion

        public Product()
        {
            fitsGames = new List<ProductGame>();
        }

    }
}