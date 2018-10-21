using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortLib.Tests
{
    class SortByMaxElementAsc : IComparer
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int firstMax = FindMax(firstArray);
            int secondMax = FindMax(secondArray);

            return firstMax.CompareTo(secondMax);
        }

        private int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }
    }
}
