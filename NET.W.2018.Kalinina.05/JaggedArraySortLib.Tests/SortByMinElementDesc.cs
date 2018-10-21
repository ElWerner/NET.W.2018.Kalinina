using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortLib.Tests
{
    class SortByMinElementDesc : IComparer
    {
        public int Compare(int[] firstArray, int[] secondArray)
        {
            int firstMin = FindMin(firstArray);
            int secondMin = FindMin(secondArray);

            return secondMin.CompareTo(firstMin);
        }

        private int FindMin(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }
    }
}
