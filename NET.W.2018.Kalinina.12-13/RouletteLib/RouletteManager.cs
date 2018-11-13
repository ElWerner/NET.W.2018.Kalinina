using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    public class RouletteManager
    {
        public delegate void NewMsgEventHandler(object sender, RouletteEventArgs e);

        public event NewMsgEventHandler NewMsg;

        protected virtual void OnNewMsg(object sender, RouletteEventArgs e)
        {
            if (NewMsg != null)
            {
                NewMsg(sender, e);
            }
        }

        public void SimulateNewMsg()
        {
            Roulette ruletts = new Roulette();
            Tuple<int, string> numberAndColor = ruletts.GetNumber();
            OnNewMsg(this, new RouletteEventArgs(numberAndColor.Item2, numberAndColor.Item1));
        }
    }
}
