using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    class Roulette
    {
        private Random rand;

        public Roulette()
        {
            rand = new Random();
        }

        public Tuple<int, string> GetNumber()
        {
            int number = rand.Next(0, 36);
            string color;

            bool isEven = ((number % 2) == 0) ? true : false;
            switch (isEven)
            {
                case true:
                    if (number == 0)
                        color = "white";
                    else
                        color = "black";
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
