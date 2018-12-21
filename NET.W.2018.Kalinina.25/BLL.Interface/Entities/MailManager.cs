using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides a class representing message sender
    /// </summary>
    public class MailManager
    {
        /// <summary>
        /// Delegate type whose type must matches receiver's method
        /// </summary>
        /// <param name="sender">Message sender</param>
        /// <param name="e">Message arguments</param>
        public delegate void NewMailEventHandler(object sender, NewMailEventArgs e);

        /// <summary>
        /// Occurs when a mail manager send new message to account owners
        /// </summary>
        public event NewMailEventHandler NewMail;

        /// <summary>
        /// Generates new message to send
        /// </summary>
        protected virtual void OnNewMail(object sender, NewMailEventArgs e)
        {
            if (NewMail != null)
            {
                NewMail(sender, e);
            }
        }

        /// <summary>
        /// Sends new message to subscribers
        /// </summary>
        /// <param name="sender">Message sender</param>
        /// <param name="e">Message arguments</param>
        public void SimulateNewMail(decimal depositAmount, decimal withdrawAmount, double bonusScores)
        {
            OnNewMail(this, new NewMailEventArgs(depositAmount, withdrawAmount, bonusScores));
        }
    }
}
