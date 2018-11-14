using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLib.Tests
{
    class CompareIntegers : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x < y)
            {
                return 1;
            }
            else
            if(x > y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    class CompareStrings : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return -string.Compare(x, y);
        }
    }

    class CompareObjects : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            if(ReferenceEquals(x, y))
            {
                return 0;
            }

            if(x.GetHashCode() == y.GetHashCode())
            {
                return 0;
            }
            else
            if (x.GetHashCode() < y.GetHashCode())
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
