using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortLib
{
    /// <summary>
    /// Represent a class providing jagged array sort algorithm
    /// </summary>
    public class JaggedArraySorting
    {
        #region Public API
        /// <summary>
        /// Sorts jagged array in specified order
        /// </summary>
        /// <param name="array">The array to sort</param>
        /// <param name="comparer">Order of sorting</param>
        /// <exception cref="ArgumentNullException">Thrown when array or comparer
        /// is not initialized</exception>
        /// <exception cref="NullReferenceException">Thrown inner array
        /// is not initialized</exception>
        public static void SortJaggedArray(int[][] array, IComparer comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Sorting order is not specified");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new NullReferenceException("Inner array is not initialized.");
                }
            }

            SortJaggedArrayRows(array, comparer);
        }

        /// <summary>
        /// Sorts jagged array in specified order using delegate
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="comparer">Order of sorting</param>
        /// <exception cref="ArgumentNullException">Thrown when array or comparer
        /// is not initialized</exception>
        /// <exception cref="NullReferenceException">Thrown inner array
        /// is not initialized</exception>
        public static void SortJaggedArrayWithDelegates(int[][] array, IComparer comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Sorting order is not specified");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new NullReferenceException("Inner array is not initialized.");
                }
            }

            SortJaggedArrayWithDelegates(array, (a, b) => comparer.Compare(a, b));
        }

        /// <summary>
        /// Sorts jagged array in specified order using delegate 
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="comparison">Order of sorting</param>
        /// <exception cref="ArgumentNullException">Thrown when array or comparer
        /// is not initialized</exception>
        /// <exception cref="NullReferenceException">Thrown inner array
        /// is not initialized</exception>
        public static void SortJaggedArrayWithDelegates(int[][] array, Comparison<int[]> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is not initialized.");
            }

            if (comparison == null)
            {
                throw new ArgumentNullException("Sorting order is not specified");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new NullReferenceException("Inner array is not initialized.");
                }
            }

            SortArrayWithDelegates(array, comparison);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Sorts jagged array in specified order using delegate 
        /// </summary>
        /// <param name="array">An array to sort</param>
        /// <param name="comparison">Order of sorting</param>
        private static void SortArrayWithDelegates(int[][] array, Comparison<int[]> comparison)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]) >= 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts jagged array in specified order using interface
        /// </summary>
        /// <param name="array">The array to sort</param>
        /// <param name="comparer">Order of sorting</param>
        private static void SortJaggedArrayRows(int[][] array, IComparer comparer)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) >= 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swaps two arrays by references
        /// </summary>
        /// <param name="firstArray">Reference to the first array</param>
        /// <param name="secondArray">Reference to the second array</param>
        private static void Swap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] temp = firstArray;
            firstArray = secondArray;
            secondArray = temp;
        }

        #endregion
    }
}
