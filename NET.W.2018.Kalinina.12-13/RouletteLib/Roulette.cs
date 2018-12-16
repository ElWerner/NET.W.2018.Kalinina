using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    /// <summary>
    /// Represents a class providing roulette entity
    /// </summary>
    public class Roulette
    { 
        /// <summary>
        /// A filed to hold random numbers generator entity
        /// </summary>
        private Random rand;

        /// <summary>
        /// Initializes a new instance of the <see cref="Roulette"/> class
        /// </summary>
        public Roulette()
        {
            rand = new Random();
        }

        /// <summary>
        /// Generates new winning combination
        /// </summary>
        /// <returns>Tuple of winning number and color</returns>
        public Tuple<int, string> GetNumber()
        {
            int number = rand.Next(0, 36);

            string color = string.Empty;

            bool isEven = ((number % 2) == 0) ? true : false;
            switch (isEven)
            {
                case true:
                    if (number == 0)
                    {
                        color = "green";
                    }
                    else
                    {
                        color = "black";
                    }

                    break;
                default:
                    color = "red";
                    break;
            }

            Tuple<int, string> tuple = new Tuple<int, string>(number, color);

            return tuple;
        }
    }
}
