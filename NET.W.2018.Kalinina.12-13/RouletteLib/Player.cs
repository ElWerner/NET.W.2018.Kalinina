using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    public class Player
    {
        private string color;
        private int number;

        public Player(string color)
        {
            this.color = color;
            number = -1;
        }

        public Player(int number)
        {
            this.number = number;

            bool isEven = ((number % 2) == 0) ? true : false;
            switch (isEven)
            {
                case true:
                    if (number == 0)
                        color = "white";
                    else
                        color = "black";
                    break;
                case false:
                    color = "red";
                    break;
            }
        }

        private void PlayerMsg(Object sender, RouletteEventArgs eventArgs)
        {
            Console.WriteLine("Color = {0}, Number = {1}", eventArgs.Color, eventArgs.Number);

            if (number == -1)
            {
                if (eventArgs.Color == color)
                {
                    Console.WriteLine("I'm a winner!");
                }
                else
                {
                    Console.WriteLine("Better luck next time.");
                }
            }
            else
            {
                if (eventArgs.Number == number)
                {
                    Console.WriteLine("I'm a winner!");
                }
                else
                {
                    Console.WriteLine("Better luck next time.");
                }
            }
            Console.WriteLine();


        }

        public void Unregister(RouletteManager manager)
        {
            manager.NewMsg -= PlayerMsg;
        }

        public void Register(RouletteManager manager)
        {
            manager.NewMsg += PlayerMsg;
        }
    }
}
