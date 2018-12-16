using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLib
{
    /// <summary>
    /// Provides method to compare two elements of specified type
    /// </summary>
    /// <typeparam name="T">Type of elements</typeparam>
    public interface IComparer<T>
    {
        /// <summary>
        /// Compares two elements
        /// </summary>
        /// <param name="firstElemet">First element</param>
        /// <param name="secondElement">Second element</param>
        /// <returns>Returns 1 if first element is less than second element.
        /// 0 if elements are equal. -1 if first elements is greater than second element.</returns>
        int Compare(T firstValue, T secondValue);
    }
}
