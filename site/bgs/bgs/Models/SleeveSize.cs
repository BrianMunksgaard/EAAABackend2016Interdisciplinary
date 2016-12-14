using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bgs.Models
{
    /// <summary>
    /// SleeveSize is a specialization of a ProductSize and hence
    /// contains a lot of properties that only applies to
    /// sleeves size.
    /// </summary>
    [Table("SleeveSize")]
    public class SleeveSize : ProductSize
    {
        #region Private variables

        private Dimension fitCardDim;
        private Dimension displayDim;
        private Dimension outerCartonDim;
        private Dimension ngSleeveDim;
        private Dimension standardSleeveDim;
        private Dimension ngBoxDim;

        #endregion

        #region Public properties

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
        public SleeveSize()
        {

        }

    }
}