namespace bgs.Models
{
    public class ProductCategory
    {
        #region Private variables

        private int categoryId;
        private string categoryText;
        private string categoryCode;

        private int categoryPropertiesId;
        private CategoryProperties properties;

        #endregion

        #region Public properties

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

        public virtual CategoryProperties Properties { get; set; }

        #endregion

    }
}