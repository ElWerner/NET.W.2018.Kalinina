using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    /// <summary>
    /// Represent a class providing person entity
    /// </summary>
    public class Player
    {
        /// <summary>
        /// A field to hold color on which player bet on
        /// </summary>
        private string color;

        /// <summary>
        /// A field to hold number on which player bet on
        /// </summary>
        private int number;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> with specified color
        /// </summary>
        /// <param name="color">The color on which player bet on</param>
        public Player(string color)
        {
            Color = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with specified number
        /// </summary>
        /// <param name="number">The number on which player bet on</param>
        public Player(int number)
        {
            Number = number;
        }

        /// <summary>
        /// Gets or sets the number on which player bet on
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
                if(value < 0 || value > 36)
                {
                    throw new ArgumentOutOfRangeException("Number must be less than 36 and equal or greater than 0.");
                }

                number = value;
            }
        }

        /// <summary>
        /// Gets or sets the color on which player bet on
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

                if(value.ToLower() != "red" || value.ToLower() != "black" || value.ToLower() != "green")
                {
                    throw new ArgumentException("Color is wrong.");
                }

                color = value;
            }
        }

        /// <summary>
        /// Gets message from sender
        /// </summary>
        /// <param name="sender">Message sender</param>
        /// <param name="eventArgs">Message arguments</param>
        private void PlayerMsg(Object sender, RouletteEventArgs eventArgs)
        {
            Console.WriteLine("Winner combination: {0} - {1}", eventArgs.Color, eventArgs.Number);

            if (eventArgs.Color == this.Color || eventArgs.Number == this.Number)
            {
                Console.WriteLine("I'm a winner!");
            }
            else
            {
                Console.WriteLine("Better luck next time.");
            }

        }

        /// <summary>
        /// Unregisters player from recieving messages
        /// </summary>
        /// <param name="manager">Message sender</param>
        public void Unregister(RouletteManager manager)
        {
            manager.NewMessage -= PlayerMsg;
        }

        /// <summary>
        /// Registers player on recieving messages
        /// </summary>
        /// <param name="manager">Message sender</param>
        public void Register(RouletteManager manager)
        {
            manager.NewMessage += PlayerMsg;
        }
    }
}
