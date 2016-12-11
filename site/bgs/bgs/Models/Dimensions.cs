namespace bgs.Models
{
    public class Dimensions
    {
        #region Private variables

        private int width;
        private int height;
        private int length;
        private int units;
        private int gapWidth;
        private int gapHeight;
        private int gapLength;
        private Dimensions holds;

        #endregion

        #region Public properties

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

        public Dimensions Holds
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