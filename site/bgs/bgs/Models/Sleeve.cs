using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Size")]
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

        /// <summary>
        /// Indicates the CMYK colors of the sleeve package.
        /// </summary>
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

        /// <summary>
        /// Indicates the RGB colors of the sleeve package.
        /// </summary>
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

        /// <summary>
        /// The weight of the sleeve package.
        /// </summary>
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

        /// <summary>
        /// The dimensions of cards
        /// that fit inside the sleeves.
        /// </summary>
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

        /// <summary>
        /// The dimensions of the display.
        /// </summary>
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

        /// <summary>
        /// The dimensions of the outer carton.
        /// </summary>
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

        /// <summary>
        /// The dimensions of ??
        /// </summary>
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

        /// <summary>
        /// The dimensions of ??
        /// </summary>
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

        /// <summary>
        /// The dimensions of ??
        /// </summary>
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Sleeve() : base()
        {

        }

    }
}