using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSort.Test
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void QuickSort_10NegativeNumbers_SortedArrayExpected()
        {
            int[] testArray = { -6, -37, -15, -49, -1, -111, -8, -6, -23, -4 };
            int[] expectedArray = { -111, -49, -37, -23, -15, -8, -6, -6, -4, -1 };

            int[] actualArray = QuickSortAlgorithm.QuickSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_10PositiveNumbers_SortedArrayExpected()
        {
            int[] testArray = { 6, 15, 2, 9, 28, 63, 48, 6, 15, 3 };
            int[] expectedArray = { 2, 3, 6, 6, 9, 15, 15, 28, 48, 63 };

            int[] actualArray = QuickSortAlgorithm.QuickSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_10PositiveAndNegativeNumbers_SortedArrayExpected()
        {
            int[] testArray = { -9, 15, 0, -89, 13, 8, -46, -7, 7, 12 };
            int[] expectedArray = { -89, -46, -9, -7, 0, 7, 8, 12, 13, 15 };

            int[] actualArray = QuickSortAlgorithm.QuickSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void QuickSort_SortedArray_SortedArrayExpected()
        {
            int[] testArray = new int[10];
            int[] expectedArray = new int[10];

            for (int i = 1; i < 11; i++)
            {
                testArray[i - 1] = i;
                expectedArray[i - 1] = i;
            }

            int[] actualArray = QuickSortAlgorithm.QuickSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NotInitializedArray_ArgumentNullExceptionExpected()
        {
            int[] testArray = null;

            int[] actualArray = QuickSortAlgorithm.QuickSort(testArray);
        }

    }
}
