using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLib
{
    public interface IComparer<T>
    {
        int Compare(T firstValue, T secondValue);
    }
}
