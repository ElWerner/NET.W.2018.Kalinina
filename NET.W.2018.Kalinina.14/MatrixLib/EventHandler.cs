using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixLib
{
    class EventHandler
    {
        internal void OnNewMessage(MatrixEventArgs arg)
        {
            MessageBox.Show($"Element changed on index [{arg.I}, {arg.J}].");
        }
    }
}
