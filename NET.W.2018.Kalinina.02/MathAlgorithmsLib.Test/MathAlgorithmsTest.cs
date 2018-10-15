using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathAlgorithmsLib.Test
{
    [TestClass]
    public class MathAlgorithmsTest
    {
        [TestMethod]
        public void InsertNumber_Source15Inserted15From0To0_15Expected()
        {
            int sourceNumer = 15;
            int insertedNumber = 15;
            int fromBit = 0;
            int toBit = 0;

            int actual = MathAlgorithms.InsertNumber(sourceNumer, insertedNumber, fromBit, toBit);

            int expected = 15;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_Source8Inserted15From0To0_9Expected()
        {
            int sourceNumer = 8;
            int insertedNumber = 15;
            int fromBit = 0;
            int toBit = 0;

            int actual = MathAlgorithms.InsertNumber(sourceNumer, insertedNumber, fromBit, toBit);

            int expected = 9;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_Source8Inserted15From3To8_120Expected()
        {
            int sourceNumer = 8;
            int insertedNumber = 15;
            int fromBit = 3;
            int toBit = 8;

            int actual = MathAlgorithms.InsertNumber(sourceNumer, insertedNumber, fromBit, toBit);

            int expected = 120;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_Source15Inserted15From9To0_ArgumentExceptionExpected()
        {
            MathAlgorithms.InsertNumber(15, 15, 9, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_Source15Inserted15From3To35_ArgumentOutOfRangeExceptionExpected()
        {
            MathAlgorithms.InsertNumber(15, 15, 3, 35);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_Source8Inserted15FromM6ToM3_ArgumentOutOfRangeExceptionExpected()
        {
            MathAlgorithms.InsertNumber(8, 15, -6, -3);
        }

        [TestMethod]
        public void FindNthRoot_Number1Degree5_1Expected()
        {
            int number = 1;
            int degree = 5;
            double precision = 0.001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 1;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void FindNthRoot_Number8Degree3_2Expected()
        {
            int number = 8;
            int degree = 3;
            double precision = 0.001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 2;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void FindNthRoot_Number0p001Degree3_0p0001Expected()
        {
            double number = 0.001;
            int degree = 3;
            double precision = 0.0001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 0.1;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void FindNthRoot_Number0p04100625Degree4_0p45Expected()
        {
            double number = 0.04100625;
            int degree = 4;
            double precision = 0.0001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 0.45;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void FindNthRoot_Number0p0279936Degree7_0p6Expected()
        {
            double number = 0.0279936;
            int degree = 7;
            double precision = 0.0001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 0.6;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod]
        public void FindNthRoot_Number0p0081Degree4_0p3Expected()
        {
            double number = 0.0081;
            int degree = 4;
            double precision = 0.1;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 0.3;

            Assert.AreEqual(expected, actual, 0.1);
        }

        [TestMethod]
        public void FindNthRoot_NumberM0p0081Degree4_0p3Expected()
        {
            double number = -0.008;
            int degree = 3;
            double precision = 0.1;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = -0.2;

            Assert.AreEqual(expected, actual, 0.1);
        }

        [TestMethod]
        public void FindNthRoot_Number0p004241979Degree9_0p545Expected()
        {
            double number = 0.004241979;
            int degree = 9;
            double precision = 0.00000001;

            double actual = MathAlgorithms.FindNthRoot(number, degree, precision);

            double expected = 0.545;

            Assert.AreEqual(expected, actual, 0.01);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_Number8Degree5Precision8_ArgumentOutOfRangeExceptionExpected()
        {
            MathAlgorithms.FindNthRoot(1, 5, 8);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRoot_Number1DegreeM8_ArgumentOutOfRangeExceptionExpected()
        {
            MathAlgorithms.FindNthRoot(1, -8, 0.001);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_NumberM8Degree6_ArgumentExceptionExpected()
        {
            MathAlgorithms.FindNthRoot(-8, 6, 0.001);
        }

        [TestMethod]
        public void FilterDigit_Digit7ArrayOf12Numbers_ArrayOf3NumbersExpected()
        {
            int digit = 7;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };

            int[] actual = MathAlgorithms.FilterDigit(digit, numbers);

            int[] expected = { 7, 70, 17 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigit_Digit9ArrayOf11NumbersNotContainsDigit_EmptyArrayExpected()
        {
            int digit = 9;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 68, 70, 15, 17 };

            int[] actual = MathAlgorithms.FilterDigit(digit, numbers);

            int[] expected = { };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterDigit_Digit10ArrayOf11Numbers_ArgumentOutOfRangeExceptionExpected()
        {
            int digit = 10;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 68, 70, 15, 17 };

            MathAlgorithms.FilterDigit(digit, numbers);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void FilterDigit_Digit7NullArray_ArgumentNullExceptionExpected()
        {
            int digit = 9;
            int[] numbers = null;

            MathAlgorithms.FilterDigit(digit, numbers);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number12_21Expected()
        {
            int number = 12;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 21;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number513_531Expected()
        {
            int number = 513;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 531;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number2017_2071Expected()
        {
            int number = 2017;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 2071;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number414_441Expected()
        {
            int number = 414;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 441;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number144_414Expected()
        {
            int number = 144;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 414;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number1234321_1241233Expected()
        {
            int number = 1234321;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 1241233;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number1234126_1234162Expected()
        {
            int number = 1234126;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 1234162;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number3456432_3462345Expected()
        {
            int number = 3456432;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = 3462345;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number10_M1Expected()
        {
            int number = 10;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number20_M1Expected()
        {
            int number = 20;

            int actual = MathAlgorithms.FindNextBiggerNumber(number);

            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_Number3_ArgumentOutOfRangeExceptionExpected()
        {
            MathAlgorithms.FindNextBiggerNumber(3);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number20Miliseconds_M1Expected()
        {
            int number = 20;
            long miliseconds;

            int actual = MathAlgorithms.FindNextBiggerNumber(number, out miliseconds);

            int expected = -1;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FindNextBiggerNumber_Number144Miliseonds_414Expected()
        {
            int number = 144;

            long miliseconds;

            int actual = MathAlgorithms.FindNextBiggerNumber(number, out miliseconds);

            int expected = 414;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number1234321Miliseconds_1241233Expected()
        {
            int number = 1234321;
            long miliseconds;

            int actual = MathAlgorithms.FindNextBiggerNumber(number, out miliseconds);


            int expected = 1241233;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNextBiggerNumber_Number1234126Miliseconds_1234162Expected()
        {
            int number = 1234126;

            long miliseconds;

            int actual = MathAlgorithms.FindNextBiggerNumber(number, out miliseconds);

            int expected = 1234162;

            Assert.AreEqual(expected, actual);
        }
    }
}
