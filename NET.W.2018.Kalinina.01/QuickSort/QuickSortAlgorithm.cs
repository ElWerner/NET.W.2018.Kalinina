using System;

namespace QuickSort
{
    /// <summary>
    /// Quick sorting algorithm in ascending order
    /// </summary>
    public static class QuickSortAlgorithm
    {
        #region Public API

        /// <summary>
        /// Sorting the array in ascending order
        /// </summary>
        /// <param name="array">An array that you want to sort</param>
        /// <returns>Sorted array</returns>
        public static int[] QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized");
            }

            return QuickSort(array, 0, array.Length - 1);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Partitioning the array into two parts using pivot element
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="leftBoundary">Left boundary of the sorted part of the array</param>
        /// <param name="rightBoundary">Right boundary of the sorted part of the array</param>
        /// <returns>Sorted array</returns>
        private static int[] QuickSort(int[] array, int leftBoundary, int rightBoundary)
        {
            if (leftBoundary < rightBoundary)
            {
                int pivot = Partition(array, leftBoundary, rightBoundary);

                QuickSort(array, leftBoundary, pivot - 1);
                QuickSort(array, pivot + 1, rightBoundary);
            }

            return array;
        }

        /// <summary>
        /// Reordering elements between left and right boundaries
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="leftBoundary">Left boundary inside the array</param>
        /// <param name="righBoundary">Right boundary inside the array</param>
        /// <returns></returns>
        private static int Partition(int[] array, int leftBoundary, int righBoundary)
        {
            int pivotIndex = righBoundary;

            int i = leftBoundary;
            for (int j = leftBoundary; j <= righBoundary; j++)
            {
                if (array[j] < array[pivotIndex])
                {
                    Swap(array, j, i);
                    i++;
                }
            }

            Swap(array, i, pivotIndex);

            return i;
        }

        /// <summary>
        /// Swapping two elements in the array
        /// </summary>
        /// <param name="array">The array in which you want to swap elements</param>
        /// <param name="firstElementIndex">The index of the first element</param>
        /// <param name="secondElementIndex">The index of the second element</param>
        private static void Swap(int[] array, int firstElementIndex, int secondElementIndex)
        {
            int temp = array[firstElementIndex];
            array[firstElementIndex] = array[secondElementIndex];
            array[secondElementIndex] = temp;
        }

        #endregion
    }
}
