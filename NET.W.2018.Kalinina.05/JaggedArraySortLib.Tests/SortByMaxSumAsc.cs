using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortLib.Tests
{
    class SortByMaxSumAsc : IComparer
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int firstSum = FindSum(firstArray);
            int secondSum = FindSum(secondArray);

            return firstSum.CompareTo(secondSum);
        }

        private int FindSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
