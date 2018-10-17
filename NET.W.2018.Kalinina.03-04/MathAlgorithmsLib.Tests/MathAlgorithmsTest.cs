using System;
using NUnit.Framework;
using NUnit.Compatibility;
using MathAlgorithmsLib;
using System.Collections;

namespace MathAlgorithmsLib.Tests
{
    [TestFixture]
    public class MathAlgorithmsTest
    {

        [Test, TestCaseSource("GCDAlgorithmCases")]
        public void EuclideanAlgorithmTest(int expectedResult, params int[] numbers)
        {
            long time;
            int actual = GreatestCommonDivision.EuclideanAlgorithm(out time, numbers);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void EuclideanAlgorithm_NullParams_ArgumentNullExceptionExpected()
        {
            int[] numbers = null;
            long time;

            Assert.Throws<ArgumentNullException>(() =>
                GreatestCommonDivision.EuclideanAlgorithm(out time, numbers));
        }

        [Test]
        public void EuclideanAlgorithm_EmptyParams_ArgumentExceptionExpected()
        {
            int[] numbers = { };
            long time;

            Assert.Throws<ArgumentException>(() =>
                GreatestCommonDivision.EuclideanAlgorithm(out time, numbers));
        }

        [Test]
        public void EuclideanAlgorithm_OneNumber_ArgumentExceptionExpected()
        {
            int numbers = 5;
            long time;

            Assert.Throws<ArgumentException>(() =>
                GreatestCommonDivision.EuclideanAlgorithm(out time, numbers));
        }

        [Test, TestCaseSource("GCDAlgorithmCases")]
        public void BinaryEuclideanAlgorithmTest(int expectedResult, params int[] numbers)
        {
            long time;
            int actual = GreatestCommonDivision.BinaryEuclideanAlgorithm(out time, numbers);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void BinaryEuclideanAlgorithm_NullParams_ArgumentNullExceptionExpected()
        {
            int[] numbers = null;
            long time;

            Assert.Throws<ArgumentNullException>(() =>
                GreatestCommonDivision.BinaryEuclideanAlgorithm(out time, numbers));
        }

        [Test]
        public void BinaryEuclideanAlgorithm_EmptyParams_ArgumentExceptionExpected()
        {
            int[] numbers = { };
            long time;

            Assert.Throws<ArgumentException>(() =>
                GreatestCommonDivision.BinaryEuclideanAlgorithm(out time, numbers));
        }

        [Test]
        public void BinaryEuclideanAlgorithm_OneNumber_ArgumentExceptionExpected()
        {
            int numbers = 5;
            long time;

            Assert.Throws<ArgumentException>(() =>
                GreatestCommonDivision.BinaryEuclideanAlgorithm(out time, numbers));
        }

        static object[] GCDAlgorithmCases =
        {
            new object[] {9, new[] { 9, 27, 90, 99, 63} },
            new object[] {24, new[] { 24, 24 } },
            new object[] {0, new[] {0, 0, 0} },
            new object[] {5, new[] { 5, 0 } },
            new object[] {28, new[] { 0, 28 } },
            new object[] {5, new[] { -15, 20, 35 } },
            new object[] {1, new[] {96, 56, 27, 33} },
            new object[] {26, new[] {1508, 2418, 1924} },
            new object[] {116, new[] {9744, 696, 232, 8584, 464, 348} }
        };
    }
}
