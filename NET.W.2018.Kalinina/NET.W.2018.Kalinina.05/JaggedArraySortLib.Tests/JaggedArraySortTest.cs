using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JaggedArraySortLib.Tests
{
    [TestClass]
    public class JaggedArraySortTest
    {
        private int[][] jaggedArray = new int[][]
        {
            new int[] {1, 3, 5, 7},
            new int[] {0, 2, 4, 6, 11},
            new int[] {11, 22, -6, 26, -4},
            new int[] {8, 15}
        };

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMaxRawElementInAscOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {1, 3, 5, 7},
                new int[] {0, 2, 4, 6, 11},
                new int[] {8, 15},
                new int[] {11, 22, -6, 26, -4}
            };

            SortByMaxElementAsc comparer = new SortByMaxElementAsc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }

        }

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMaxRawElementInDescOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {11, 22, -6, 26, -4},
                new int[] {8, 15},
                new int[] {0, 2, 4, 6, 11},
                new int[] {1, 3, 5, 7}
            };

            SortByMaxElementDesc comparer = new SortByMaxElementDesc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }
        }

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMinRawElementInAscOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {11, 22, -6, 26, -4},
                new int[] {0, 2, 4, 6, 11},
                new int[] {1, 3, 5, 7},
                new int[] {8, 15}
            };

            SortByMinElementAsc comparer = new SortByMinElementAsc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }
        }

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMinimalRawElementInDescOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {8, 15},
                new int[] {1, 3, 5, 7},
                new int[] {0, 2, 4, 6, 11},
                new int[] {11, 22, -6, 26, -4}
            };

            SortByMinElementDesc comparer = new SortByMinElementDesc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }

        }

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMaximalRawSumInAscOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {1, 3, 5, 7},
                new int[] {8, 15},
                new int[] {0, 2, 4, 6, 11},
                new int[] {11, 22, -6, 26, -4}
            };

            SortByMaxSumAsc comparer = new SortByMaxSumAsc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }

        }

        [TestMethod]
        public void SortJaggedArray_UnsortedJaggedArray_SortedByMaximalRawSumInDescOrderArray()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {11, 22, -6, 26, -4},
                new int[] {8, 15},
                new int[] {0, 2, 4, 6, 11},
                new int[] {1, 3, 5, 7}
            };

            SortByMaxSumDesc comparer = new SortByMaxSumDesc();
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                CollectionAssert.AreEqual(expectedArray[i], jaggedArray[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortJaggedArray_NullArray_ArgumentNullExceptionExpected()
        {
            SortByMaxSumDesc comparer = new SortByMaxSumDesc();
            JaggedArraySorting.SortJaggedArray(null, comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SortJaggedArray_EmptyArray_ArgumentNullExceptionExpected()
        {
            int[][] emptyJaggedArray = new int[3][];

            SortByMaxSumDesc comparer = new SortByMaxSumDesc();
            JaggedArraySorting.SortJaggedArray(emptyJaggedArray, comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortJaggedArray_EmptyComparer_ArgumentNullExceptionExpected()
        {
            SortByMaxSumDesc comparer = null;
            JaggedArraySorting.SortJaggedArray(jaggedArray, comparer);
        }
    }
}
