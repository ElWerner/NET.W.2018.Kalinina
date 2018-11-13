using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BinarySearchLib
{
    public static class BinarySearch
    {
        public static int BinarySearchAlgorithm<T>(T[] sortedArray, T targetValue, IComparer comparer)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            int iterationsMade = 0;

            while (left <= right)
            {
                iterationsMade++;

                int middle = (left + right) / 2;

                if (comparer.Compare(sortedArray[middle], targetValue) == 0)
                {
                    return middle;
                }

                if (comparer.Compare(sortedArray[middle], targetValue) > 0)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return -1;
        }
    }
}
