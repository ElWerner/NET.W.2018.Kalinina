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
            int actual =  GreatestCommonDivision.EuclideanAlgorithm(numbers);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void EuclideanAlgorithm_NullParams_ArgumentNullExceptionExpected()
        {
            int[] numbers = null;

            Assert.Throws<ArgumentNullException>(() => GreatestCommonDivision.EuclideanAlgorithm(numbers));
        }

        [Test]
        public void EuclideanAlgorithm_EmptyParams_ArgumentExceptionExpected()
        {
            int[] numbers = { };

            Assert.Throws<ArgumentException>(() => GreatestCommonDivision.EuclideanAlgorithm(numbers));
        }

        [Test]
        public void EuclideanAlgorithm_OneNumber_ArgumentExceptionExpected()
        {
            int numbers = 5;

            Assert.Throws<ArgumentException>(() => GreatestCommonDivision.EuclideanAlgorithm(numbers));
        }

        [Test, TestCaseSource("GCDAlgorithmCases")]
        public void BinaryEuclideanAlgorithmTest(int expectedResult, params int[] numbers)
        {
            int actual = GreatestCommonDivision.BinaryEuclideanAlgorithm(numbers);

            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void BinaryEuclideanAlgorithm_NullParams_ArgumentNullExceptionExpected()
        {
            int[] numbers = null;

            Assert.Throws<ArgumentNullException>(() => GreatestCommonDivision.BinaryEuclideanAlgorithm(numbers));
        }

        [Test]
        public void BinaryEuclideanAlgorithm_EmptyParams_ArgumentExceptionExpected()
        {
            int[] numbers = { };

            Assert.Throws<ArgumentException>(() => GreatestCommonDivision.BinaryEuclideanAlgorithm(numbers));
        }

        [Test]
        public void BinaryEuclideanAlgorithm_OneNumber_ArgumentExceptionExpected()
        {
            int numbers = 5;

            Assert.Throws<ArgumentException>(() => GreatestCommonDivision.BinaryEuclideanAlgorithm(numbers));
        }

        static object[] GCDAlgorithmCases =
        {
            new object[] {9, new[] { 9, 27, 90, 99, 63}},
            new object[] {24, new[] { 24, 24 }},
            new object[] {0, new[] {0, 0, 0}},
            new object[] {5, new[] { 5, 0 } },
            new object[] {28, new[] { 0, 28 } },
            new object[] {5, new[] { -15, 20, 35 }},
            new object[] {1, new[] {96, 56, 27, 33}}
        };
    }
}
