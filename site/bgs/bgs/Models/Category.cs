using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    public class Category
    {
        #region Private variables

        private int categoryId;
        private string categoryText;
        private string categoryCode;

        private ICollection<Product> products;

        #endregion

        #region Public properties

        [Key]
        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
            }
        }

        public string CategoryText
        {
            get
            {
                return categoryText;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    categoryText = value;
                }
            }
        }

        public string CategoryCode
        {
            get
            {
                return categoryCode;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    categoryCode = value;
                }
            }
        }

        public ICollection<Product> Products
        {
            get
            {
                return products == null ? products = new List<Product>() : products;
            }
        }


        #endregion

    }
}