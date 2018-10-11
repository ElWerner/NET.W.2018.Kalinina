using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    /// <summary>
    /// Merge sorting algorithm in ascending order
    /// </summary>
    public static class MergeSortAlgorithm
    {
        /// <summary>
        /// Sorting the array in ascending order
        /// </summary>
        /// <param name="array">An array that you want to sort</param>
        /// <returns>Sorted array</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized");
            }

            return MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Partitioning the array into two parts using pivot element index
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="leftBoundary">Left boundary of the partitioned part of the array</param>
        /// <param name="rightBoundary">Right boundary of the partitioned part of the array</param>
        /// <returns></returns>
        private static int[] MergeSort(int[] array, int leftBoundary, int rightBoundary)
        {
            if (leftBoundary < rightBoundary)
            {
                int pivotIndex = leftBoundary + (rightBoundary - leftBoundary) / 2;

                MergeSort(array, leftBoundary, pivotIndex);
                MergeSort(array, pivotIndex + 1, rightBoundary);
                Merge(array, leftBoundary, pivotIndex, rightBoundary);
            }

            return array;
        }

        /// <summary>
        /// Merging two sorted parts of the array
        /// </summary>
        /// <param name="array">An array to merge</param>
        /// <param name="leftBoundary">Left boundary of the first sorted part of the array</param>
        /// <param name="pivotIndex">The pivot index that delimits two sorted parts of the array</param>
        /// <param name="rightBoundary">Right boundary of the second sorted part of the array</param>
        private static void Merge(int[] array, int leftBoundary, int pivotIndex, int rightBoundary)
        {
            int i, j, k;

            int left = pivotIndex - leftBoundary + 1;
            int right = rightBoundary - pivotIndex;

            int[] leftTempArray = new int[left];
            int[] rightTempArray = new int[right];

            for (i = 0; i < left; i++)
                leftTempArray[i] = array[leftBoundary + i];

            for (i = 0; i < right; i++)
                rightTempArray[i] = array[pivotIndex + 1 + i];

            i = j = 0;
            k = leftBoundary;
            while (i < left && j < right)
            {
                if (leftTempArray[i] < rightTempArray[j])
                {
                    array[k] = leftTempArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightTempArray[j];
                    j++;
                }
                k++;
            }

            while (i < left)
            {
                array[k] = leftTempArray[i];
                i++; k++;
            }

            while (j < right)
            {
                array[k] = rightTempArray[j];
                j++; k++;
            }
        }
    }
}
