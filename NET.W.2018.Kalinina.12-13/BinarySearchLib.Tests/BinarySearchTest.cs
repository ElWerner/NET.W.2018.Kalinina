using System;
using NUnit.Framework;
using BinarySearchLib;

namespace BinarySearchLib.Tests
{
    [TestFixture]
    public class BinarySearchTest
    {
        [TestCase(new int[] { 0, 8, 15, 26, 31, 44, 96, 115 }, 115, ExpectedResult=7)]
        [TestCase(new int[] { 5512, 87845, 956562, 1212421, 3665224 }, 5512, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 9, ExpectedResult = 9)]
        public int BinarySearch_IntBinarySearch(int[] array, int targetValue)
        {
            IComparer<int> compare = new CompareIntegers();

            return BinarySearch.BinarySearchAlgorithm<int>(array, targetValue, compare);
        }

        [TestCase(new string[] { "a", "b", "c", "d", "e", "f" }, "b", ExpectedResult = 1)]
        [TestCase(new string[] { "abc", "cde", "frt", "por", "tbg" }, "por", ExpectedResult = 3)]
        [TestCase(new string[] { "ERT", "Gnt", "RTGlop", "Tnrkk", "W" }, "ERT", ExpectedResult = 0)]
        public int BinarySearch_StringBinarySearch(string[] array, string targetValue)
        {
            IComparer<string> compare = new CompareStrings();

            return BinarySearch.BinarySearchAlgorithm<string>(array, targetValue, compare);
        }

        [Test]
        public void BinarySearch_ArgumentNullExceptionExpected_UninitializedArray()
        {
            int[] array = null;
            IComparer<int> comparer = new CompareIntegers();

            Assert.Throws<ArgumentNullException>(() => BinarySearch.BinarySearchAlgorithm<int>(array, 3, comparer));
        }

        [Test]
        public void BinarySearch_ArgumentExceptionExpected_EmptryArray()
        {
            int[] array = { };
            IComparer<int> comparer = new CompareIntegers();

            Assert.Throws<ArgumentException>(() => BinarySearch.BinarySearchAlgorithm<int>(array, 3, comparer));
        }

        [Test]
        public void BinarySearch_ArgumentExceptionExpected_UninitializedComparer()
        {
            int[] array = { 4, 8, 12};
            IComparer<int> comparer = null;

            Assert.Throws<ArgumentNullException>(() => BinarySearch.BinarySearchAlgorithm<int>(array, 8, comparer));
        }

        [Test]
        public void BinarySearch_ExceptionExpected_ElementNotFound()
        {
            int[] array = { 4, 8, 12, 16, 89, 213, 562, 4599 };

            int targetValue = 200;

            IComparer<int> comparer = new CompareIntegers();

            Assert.Throws<Exception>(() => BinarySearch.BinarySearchAlgorithm<int>(array, targetValue, comparer));
        }

    }
}
