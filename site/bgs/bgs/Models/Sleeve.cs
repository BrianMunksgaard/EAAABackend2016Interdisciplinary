using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// Sleeve is a specialization of a product and hence
    /// contains a lot of properties that only applies to
    /// sleeves.
    /// </summary>
    [Table("Sleeve")]
    public class Sleeve : Product
    {
        #region Private variables

        private Size sleeveSize;
        private string cmyk;
        private string rgb;
        private int weight;
        private Dimension fitCardDim;
        private Dimension displayDim;
        private Dimension outerCartonDim;
        private Dimension ngSleeveDim;
        private Dimension standardSleeveDim;
        private Dimension ngBoxDim;

        #endregion

        #region Public properties

        /// <summary>
        /// Sleeve size as in large, medium etc.
        /// </summary>
        public Size SleeveSize
        {
            get
            {
                return sleeveSize;
            }
            set
            {
                sleeveSize = value;
            }
        }

        public string CMYK
        {
            get
            {
                return cmyk;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    cmyk = value;
                }
            }
        }

        public string RGB
        {
            get
            {
                return rgb;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    rgb = value;
                }
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public Dimension FitCardDim
        {
            get
            {
                return fitCardDim;
            }
            set
            {
                if (value != null)
                {
                    fitCardDim = value;
                }
            }
        }

        public Dimension DisplayDim
        {
            get
            {
                return displayDim;
            }
            set
            {
                if (value != null)
                {
                    displayDim = value;
                }
            }
        }

        public Dimension OuterCartonDim
        {
            get
            {
                return outerCartonDim;
            }
            set
            {
                if (value != null)
                {
                    outerCartonDim = value;
                }
            }
        }

        public Dimension NGSleeveDim
        {
            get
            {
                return ngSleeveDim;
            }
            set
            {
                if (value != null)
                {
                    ngSleeveDim = value;
                }
            }
        }

        public Dimension StandardSleeveDim
        {
            get
            {
                return standardSleeveDim;
            }
            set
            {
                if (value != null)
                {
                    standardSleeveDim = value;
                }
            }
        }

        public Dimension NGBoxDim
        {
            get
            {
                return ngBoxDim;
            }
            set
            {
                if (value != null)
                {
                    ngBoxDim = value;
                }
            }
        }

        #endregion

        public Sleeve() : base()
        {

        }

    }
}