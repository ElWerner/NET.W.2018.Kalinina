using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeSort.Test
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void MergeSort_10NegativeNumbers_SortedArray()
        {
            int[] testArray = { -6, -37, -15, -49, -1, -111, -8, -6, -23, -4 };
            int[] expectedArray = { -111, -49, -37, -23, -15, -8, -6, -6, -4, -1 };

            int[] actualArray = MergeSortAlgorithm.MergeSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_10PositiveNumbers_SortedArray()
        {
            int[] testArray = { 6, 15, 2, 9, 28, 63, 48, 6, 15, 3 };
            int[] expectedArray = { 2, 3, 6, 6, 9, 15, 15, 28, 48, 63 };

            int[] actualArray = MergeSortAlgorithm.MergeSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_10PositiveAndNegativeNumbers_SortedArray()
        {
            int[] testArray = { -9, 15, 0, -89, 13, 8, -46, -7, 7, 12 };
            int[] expectedArray = { -89, -46, -9, -7, 0, 7, 8, 12, 13, 15 };

            int[] actualArray = MergeSortAlgorithm.MergeSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void MergeSort_SortedArray_SortedArray()
        {
            int[] testArray = new int[10];
            int[] expectedArray = new int[10];

            for(int i = 1; i < 11; i++)
            {
                testArray[i - 1] = i;
                expectedArray[i - 1] = i;
            }

            int[] actualArray = MergeSortAlgorithm.MergeSort(testArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
