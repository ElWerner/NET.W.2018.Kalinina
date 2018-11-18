using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class MatrixEventArgs : EventArgs
    {
        private readonly int i;
        private readonly int j;

        public MatrixEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int I
        {
            get
            {
                return i;
            }
        }

        public int J
        {
            get
            {
                return j;
            }
        }
    }
}
