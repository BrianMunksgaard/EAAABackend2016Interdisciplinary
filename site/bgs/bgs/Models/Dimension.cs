using System.ComponentModel.DataAnnotations;

namespace bgs.Models
{
    /// <summary>
    /// The Dimension class contains the different dimensions
    /// of a single sleeve.
    /// 
    /// A single instance of this class might not have all values
    /// set, but could possible only have a few set.
    /// </summary>
    public class Dimension : BgsEntity
    {
        #region Private variables

        private int dimensionId;
        private int width;
        private int height;
        private int length;
        private int units;
        private int gapWidth;
        private int gapHeight;
        private int gapLength;
        private Dimension holds;

        #endregion

        #region Public properties

        /// <summary>
        /// A unique dimension id.
        /// </summary>
        [Key]
        public int DimensionId
        {
            get { return dimensionId; }
            set { dimensionId = value; }
        }

        /// <summary>
        /// The width of the sleeve.
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        /// <summary>
        /// The height of the sleeve.
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        /// <summary>
        /// The length of the sleeve.
        /// </summary>
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        /// <summary>
        /// This is an indication of whether the 
        /// dimensions are given in cm or inches.
        /// </summary>
        public int Units
        {
            get
            {
                return units;
            }
            set
            {
                units = value;
            }
        }

        /// <summary>
        /// The width of an possible gap.
        /// </summary>
        public int GapWidth
        {
            get
            {
                return gapWidth;
            }
            set
            {
                gapWidth = value;
            }
        }

        /// <summary>
        /// The height of a possible gap.
        /// </summary>
        public int GapHeight
        {
            get
            {
                return gapHeight;
            }
            set
            {
                gapHeight = value;
            }
        }

        /// <summary>
        /// The length of a possible gap.
        /// </summary>
        public int GapLength
        {
            get
            {
                return gapLength;
            }
            set
            {
                gapLength = value;
            }
        }

        /// <summary>
        /// A reference to another dimension to 
        /// indicate that this dimension is capable
        /// of containing some other dimension.
        /// </summary>
        public Dimension Holds
        {
            get
            {
                return holds;
            }
            set
            {
                if (value != null)
                {
                    holds = value;
                }
            }
        }

        #endregion
    }
}