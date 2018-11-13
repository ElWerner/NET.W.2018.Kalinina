using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    internal sealed class RouletteEventArgs : EventArgs
    {
        private string color;
        private int number;

        public RouletteEventArgs(string color, int number)
        {
            this.color = color;
            this.number = number;
        }

        public string Color
        {
            get
            {
                return color;
            }

            private set
            {
                color = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            private set
            {
                number = value;
            }
        }
    }
}
