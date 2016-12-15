using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace bgs.Models
{
    /// <summary>
    /// This class is used to represent 
    /// a CMYK color.
    /// </summary>
    public class CMYK
    {
        /// <summary>
        /// The value of cyan.
        /// </summary>
        public int Cyan { get; set; }

        /// <summary>
        /// The value of magenta.
        /// </summary>
        public int Magenta { get; set; }

        /// <summary>
        /// The value of yellow.
        /// </summary>
        public int Yellow { get; set; }

        /// <summary>
        /// The value of the key(color).
        /// </summary>
        public int KeyColor { get; set; }

        /// <summary>
        /// Returns the computer color that represents the CMYK color. 
        /// </summary>
        /// <returns></returns>
        public Color GetColor()
        {
            return Color.Black;
        }
    }
}