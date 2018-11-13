using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RouletteLib;

namespace RouletteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rulettsManager = new RouletteManager();

            var player1 = new Player(15);
            player1.Register(rulettsManager);


            var player2 = new Player(0);
            player2.Register(rulettsManager);

            var player3 = new Player("red");
            player3.Register(rulettsManager);

            var player4 = new Player(35);
            player4.Register(rulettsManager);

            rulettsManager.SimulateNewMsg();

            Thread.Sleep(100);
        }
    }
}
