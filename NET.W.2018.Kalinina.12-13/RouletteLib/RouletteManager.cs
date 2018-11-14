using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteLib
{
    /// <summary>
    /// Provides a class representing message sender
    /// </summary>
    public class RouletteManager
    {
        /// <summary>
        /// Delegate type whose type must matches receiver's method
        /// </summary>
        /// <param name="sender">Message sender</param>
        /// <param name="e">Message arguments</param>
        public delegate void NewMsgEventHandler(object sender, RouletteEventArgs e);

        /// <summary>
        /// Occurs when a roulette manager send new message to players
        /// </summary>
        public event NewMsgEventHandler NewMessage;

        /// <summary>
        /// Sends new message to subscribers
        /// </summary>
        /// <param name="sender">Mesage sender</param>
        /// <param name="e">Message arguments</param>
        protected virtual void OnNewMsg(object sender, RouletteEventArgs e)
        {
            NewMessage?.Invoke(sender, e);
        }

        /// <summary>
        /// Generates new message to send
        /// </summary>
        public void SimulateNewMsg()
        {
            Roulette ruletts = new Roulette();
            Tuple<int, string> numberAndColor = ruletts.GetNumber();
            OnNewMsg(this, new RouletteEventArgs(numberAndColor.Item2, numberAndColor.Item1));
        }
    }
}
