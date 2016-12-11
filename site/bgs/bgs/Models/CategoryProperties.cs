﻿namespace bgs.Models
{
    public class CategoryProperties
    {
        #region Private variables

        private int size;
        private string cmyk;
        private string rgb;
        private int weight;
        private Dimensions fitCardDim;
        private Dimensions displayDim;
        private Dimensions outerCartonDim;
        private Dimensions ngSleeveDim;
        private Dimensions standardSleeveDim;
        private Dimensions ngBoxDim;

        #endregion

        #region Public properties

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
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

        public Dimensions FitCardDim
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

        public Dimensions DisplayDim
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

        public Dimensions OuterCartonDim
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

        public Dimensions NGSleeveDim
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

        public Dimensions StandardSleeveDim
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

        public Dimensions NGBoxDim
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

    }
}