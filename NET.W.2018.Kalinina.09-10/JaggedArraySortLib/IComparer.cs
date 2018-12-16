using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortLib
{
    /// <summary>
    /// Provides method to compare two array
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares two arrays
        /// </summary>
        /// <param name="firstArray">First array</param>
        /// <param name="secondArray">Second array</param>
        /// <returns>Returns 1 if first element is less than second element.
        /// 0 if elements are equal. -1 if first elements is greater than second element.</returns>
        int Compare(int[] firstArray, int[] secondArray);
    }
}
