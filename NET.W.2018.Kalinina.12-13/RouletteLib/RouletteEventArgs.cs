using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    /// <summary>
    /// Represents a class containing roulette events argumnets
    /// </summary>
    public sealed class RouletteEventArgs : EventArgs
    {
        /// <summary>
        /// A filed to hold winning color
        /// </summary>
        private string color;

        /// <summary>
        /// A field to hold winning number
        /// </summary>
        private int number;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouletteEventArgs"/> with specified color and number
        /// </summary>
        /// <param name="color">Winning color</param>
        /// <param name="number">Winning number</param>
        public RouletteEventArgs(string color, int number)
        {
            Color = color;
            Number = number;
        }

        /// <summary>
        /// Gets or sets the winning number
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number is less than 0 and greater than 36</exception>
        public int Number
        {
            get
            {
                return number;
            }

            private set
            {
                if (value < 0 || value > 36)
                {
                    throw new ArgumentOutOfRangeException("Number must be less than 36 and equal or greater than 0.");
                }

                number = value;
            }
        }

        /// <summary>
        /// Gets or sets the winning color
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when color string is null or empty</exception>
        /// <exception cref="ArgumentException">Thrown when color is wrong</exception>
        public String Color
        {
            get
            {
                return color;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Color string is not initialized.");
                }

                if (value.ToLower() != "red" || value.ToLower() != "black" || value.ToLower() != "green")
                {
                    throw new ArgumentException("Color is wrong.");
                }

                color = value;
            }
        }
    }
}
