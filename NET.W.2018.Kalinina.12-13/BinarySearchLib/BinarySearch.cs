using System;

namespace BinarySearchLib
{
    /// <summary>
    /// Represents a class providing generic binary search algorithm
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Provides binary search algorithm of the target value in the sorted array
        /// </summary>
        /// <typeparam name="T">Type of target value and array</typeparam>
        /// <param name="array">Array to search</param>
        /// <param name="targetValue">Target value</param>
        /// <param name="comparer">Compare order</param>
        /// <returns>Index of the founded element</returns>
        /// <exception cref="ArgumentNullException">Thrown when array or comparer is null</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        /// <exception cref="Exception">Thrown when target value was not found in the array</exception>
        public static int BinarySearchAlgorithm<T>(T[] array, T targetValue, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Comparator is not initalized.");
            }

            int result = BinarySearchMethod<T>(array, targetValue, comparer);
            if (result == -1)
            {
                throw new Exception("Target value was not found.");
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Provides binary search algorithm of the target value in the sorted array
        /// </summary>
        /// <typeparam name="T">Type of target value and array</typeparam>
        /// <param name="array">Array to search</param>
        /// <param name="targetValue">Target value</param>
        /// <param name="comparer">Compare order</param>
        /// <returns>Index of the founded element or -1 if the target element was not found</returns>
        private static int BinarySearchMethod<T>(T[] sortedArray, T targetValue, IComparer<T> comparer)
        {
            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (comparer.Compare(sortedArray[middle], targetValue) == 0)
                {
                    return middle;
                }

                if (comparer.Compare(sortedArray[middle], targetValue) > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
