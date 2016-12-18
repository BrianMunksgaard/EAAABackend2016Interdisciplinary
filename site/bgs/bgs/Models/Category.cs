using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// This class is used for holding information about 
    /// the product categories in the website.
    /// </summary>
    public class Category : BgsEntity
    {
        #region Private variables

        private int categoryId;
        private string categoryText;
        private string categoryCode;

        private ICollection<Product> products;

        #endregion

        #region Public properties

        /// <summary>
        /// Unique category id. This is primarily an internal/db id.
        /// </summary>
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

        /// <summary>
        /// The description of the category.
        /// </summary>
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

        /// <summary>
        /// A unique category code used to identify the category. This is the category code used by the business.
        /// </summary>
        [Index("CategoryIndex", IsUnique = true)]
        [MaxLength(15)]
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

        #endregion

    }
}