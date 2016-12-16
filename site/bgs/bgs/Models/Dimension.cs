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
    public class Dimension
    {
        #region Private variables

        private decimal width;
        private decimal height;
        private decimal length;
        private decimal depth;

        #endregion

        #region Public properties

        /// <summary>
        /// The width of the sleeve.
        /// </summary>
        public decimal Width
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
        public decimal Height
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
        public decimal Length
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
        /// Depth.
        /// </summary>
        public decimal Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        #endregion

        /// <summary>
        /// Returns the gaps between the length, height and width of this
        /// dimension relative to length, height and width of the relativeDimension
        /// parameter. 
        /// </summary>
        /// <param name="relativeDimension"></param>
        /// <returns></returns>
        public Dimension GetGaps(Dimension relativeDimension)
        {
            Dimension d = new Dimension()
            {
                Length = this.length > relativeDimension.Length ? this.Length - relativeDimension.Length : 0,
                Height = this.Height > relativeDimension.Height ? this.Height - relativeDimension.Height : 0,
                Width = this.Width > relativeDimension.Width ? this.Height - relativeDimension.Width : 0,
                Depth = this.Depth > relativeDimension.Depth ? this.Depth - relativeDimension.Depth : 0
            };
            return d;
        }
    }
}