namespace bgs.Models
{
    public class Product
    {
        #region Private variables

        private int productId;
        private string productName;
        private string productCode;

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

        #endregion

        public Product()
        {

        }

    }
}